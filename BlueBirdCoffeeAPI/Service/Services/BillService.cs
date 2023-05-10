using AutoMapper;
using Castle.Core.Internal;
using Data.AppException;
using Data.DataAccessLayer;
using Data.Entities;
using Data.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Service.Services
{
    public interface IBillService
    {
        BillViewModel Checkout(CheckoutModel model, string userId);
        BillViewModel PreCheck(CheckoutModel model, string userId);
        List<BillViewModel> History(int count);
        List<BillMissingItemViewModel> MissingBillItemWithin48Hours();
        List<ChartViewModel> ChartData(bool isBillCountChart);
        StatisticsModels Statistics();
        Guid UpdateReason(BillMissingItemUpdateModel model);
        BilPagingModel ExportData(DateTime? date, DateTime? fromDate, DateTime? toDate, bool isNewest, int? pageIndex, int? pageSize);
    }

    public class BillService : IBillService
    {
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly ICouponService _couponService;

        public BillService(AppDbContext dbContext, IMapper mapper, ICouponService couponService)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _couponService = couponService;
        }

        public StatisticsModels Statistics()
        {
            var items = _dbContext.Items.ToList();

            var thisMonth = GetStatisticsForMonth(DateTime.UtcNow.AddHours(7), items);
            var lastMonth = GetStatisticsForMonth(DateTime.UtcNow.AddHours(7).AddMonths(-1), items);

            var now = DateTime.UtcNow.AddHours(7);

            var todateIncome = GetIncomeByDate(now);
            var lastDateIncome = GetIncomeByDate(now.AddDays(-1));

            var thisWeekIncome = GetIncomeByFromToDate(GetFirstDayOfWeek(now), now);
            var lastWeekIncome = GetIncomeByFromToDate(GetFirstDayOfWeek(now).AddDays(-7), GetFirstDayOfWeek(now).AddDays(-1));

            var lastMonthD = now.AddMonths(-1);
            var thisMonthIncome = GetIncomeByFromToDate(new DateTime(now.Year, now.Month, 1), now);
            var lastMonthIncome = GetIncomeByFromToDate(new DateTime(lastMonthD.Year, lastMonthD.Month, 1), new DateTime(lastMonthD.Year, lastMonthD.Month, DateTime.DaysInMonth(lastMonthD.Year, lastMonthD.Month)));

            return new StatisticsModels()
            {
                Income = thisMonth.Income,
                BestSellerCount = thisMonth.BestSellerCount,
                BestSellerItemName = thisMonth.BestSellerItemName,

                BestSellerLastMonthCount = lastMonth.BestSellerCount,
                BestSellerLastMonthItemName = lastMonth.BestSellerItemName,
                IncomeLastMonth = lastMonth.Income,

                ChartTodateIncome = todateIncome,
                ChartLastDateIncome = lastDateIncome,
                ChartThisWeekIncome = thisWeekIncome,
                ChartLastWeekIncome = lastWeekIncome,
                ChartThisMonthIncome = thisMonthIncome,
                ChartLastMonthIncome = lastMonthIncome
            };
        }

        private DateTime GetFirstDayOfWeek(DateTime date)
        {
            do
            {
                if (date.DayOfWeek == DayOfWeek.Monday) return date;
                date = date.AddDays(-1);
            } while (date.DayOfWeek != DayOfWeek.Monday);
            return date;
        }
        private double GetIncomeByFromToDate(DateTime fromDate, DateTime toDate)
        {
            return _dbContext.Bills.Where(f => f.DateCreated.Date >= fromDate.Date && f.DateCreated.Date <= toDate.Date).Sum(s => s.Total - s.Discount - s.Coupon);
        }
        private double GetIncomeByDate(DateTime date)
        {
            return _dbContext.Bills.Where(f => f.DateCreated.Date == date.Date).Sum(s => s.Total - s.Discount - s.Coupon);
        }
        public StatisticsModels GetStatisticsForMonth(DateTime monthOfYear, List<Item>? items)
        {
            var data = _dbContext.OrderDetails.Where(f => f.DateUpdated.Year == monthOfYear.Year
                && f.DateUpdated.Month == monthOfYear.Month)
               .ToList();

            List<BaseIntModel> itemSells = new();

            double incomeThisMonth = 0;
            foreach (var item in items)
            {
                var currentItem = data.Where(f => f.ItemId == item.Id).ToList();

                itemSells.Add(new BaseIntModel() { Id = item.Id, Data = currentItem.Sum(f => f.FinalQuantity) });
                incomeThisMonth += currentItem.Sum(f => f.FinalQuantity * f.Price);
            }

            var bestSellerThisMonth = itemSells.OrderByDescending(f => f.Data).First();

            return new StatisticsModels()
            {
                Income = incomeThisMonth,
                BestSellerCount = bestSellerThisMonth.Data,
                BestSellerItemName = items.First(f => f.Id == bestSellerThisMonth!.Id).Name!
            };
        }
        public int GetCurrentBillNumber()
        {
            var lastestBill = _dbContext.Bills.OrderByDescending(s => s.DateCreated).FirstOrDefault();

            if (lastestBill != null && lastestBill.DateCreated.Date == DateTime.UtcNow.AddHours(7).Date)
            {
                return lastestBill.BillNumber + 1;
            }

            return 1;
        }
        public BillViewModel Checkout(CheckoutModel model, string userId)
        {
            var trans = _dbContext.Database.BeginTransaction();

            Guid id;
            try
            {
                var orders = _dbContext.Orders.Include(f => f.OrderDetails).Where(f => model.Orders.Contains(f.Id)).ToList();

                var removedOrders = new List<Order>();
                foreach (var order in orders)
                {
                    var check = false;
                    foreach (var item in order.OrderDetails)
                    {
                        var x = model.RemovedItems.FirstOrDefault(f => f.ItemId == item.ItemId);
                        if (x == null || x.Quantity < item.Quantity)
                        {
                            check = true;
                            break;
                        }
                    }
                    if (!check)
                    {
                        removedOrders.Add(order);
                        foreach (var item in order.OrderDetails)
                        {
                            var x = model.RemovedItems.First(f => f.ItemId == item.ItemId);
                            model.RemovedItems.Remove(x);
                            if (x.Quantity > item.Quantity)
                            {
                                x.Quantity -= item.Quantity;
                                model.RemovedItems.Add(x);
                            }
                        }
                        order.IsMissing = true;
                        order.IsCheckout = true;
                        _dbContext.Update(order);
                    }
                }
                foreach (var item in removedOrders)
                {
                    orders.Remove(orders.First(f => f.Id == item.Id));
                }

                orders = orders.OrderByDescending(s => (s.OrderDetails.Select(s => s.ItemId).Intersect(model.RemovedItems.Select(s => s.ItemId))).Count()).ToList();
                var tables = _dbContext.Tables.Where(f => orders.Select(s => s.TableId).ToList().Contains(f.Id)).ToList();

                Bill newBill = new()
                {
                    Discount = model.Discout == null ? 0 : model.Discout.Value,
                    CouponCode = model.Coupon,
                    IsTakeAway = model.IsTakeAway,
                    BillNumber = GetCurrentBillNumber(),
                    CasherId = userId,
                };

                _dbContext.Add(newBill);

                double total = 0;

                foreach (var order in orders)
                {
                    bool isMissing = false;
                    foreach (var item in order.OrderDetails)
                    {
                        var currentRemoveItem = model.RemovedItems.FirstOrDefault(f => f.ItemId == item.ItemId);
                        if (currentRemoveItem == null)
                        {
                            item.FinalQuantity = item.Quantity;
                        }
                        else
                        {
                            model.RemovedItems.Remove(currentRemoveItem);
                            if (currentRemoveItem.Quantity == item.Quantity)
                            {
                                item.FinalQuantity = 0;
                            }
                            else if (currentRemoveItem.Quantity < item.Quantity)
                            {
                                item.FinalQuantity -= currentRemoveItem.Quantity;
                                //model.RemovedItems.Add(currentRemoveItem);
                            }
                            else
                            {
                                item.FinalQuantity = 0;
                                currentRemoveItem.Quantity -= item.Quantity;
                                model.RemovedItems.Add(currentRemoveItem);
                            }
                            isMissing = true;
                        }

                        if (item.FinalQuantity < 0)
                        {
                            item.FinalQuantity = 0;
                        }

                        _dbContext.Update(item);
                        total += item.FinalQuantity * item.Price;
                    }

                    order.IsMissing = isMissing;
                    order.IsCheckout = true;

                    if (order.TableId != null)
                    {
                        var table = tables.First(f => f.Id == order.TableId);
                        if (table.CurrentOrder > 0)
                        {
                            table.CurrentOrder--;
                        }
                        _dbContext.Update(table);
                    }
                    _dbContext.Update(order);

                    BillOrder billOrder = new BillOrder()
                    {
                        BillId = newBill.Id,
                        OrderId = order.Id
                    };
                    _dbContext.Add(billOrder);
                }

                _dbContext.SaveChanges();

                newBill.Total = total;
                if (!string.IsNullOrEmpty(model.Coupon))
                {
                    newBill.Coupon = _couponService.UseCoupon(model.Coupon, total);
                    newBill.CouponCode = model.Coupon;
                }
                else
                {
                    newBill.Coupon = 0;
                }
                _dbContext.Update(newBill);
                _dbContext.SaveChanges();
                id = newBill.Id;

                trans.Commit();
            }
            catch (Exception e)
            {
                trans.Rollback();
                throw new AppException("Error: " + e.Message);
            }
            finally
            {
                trans.Dispose();
            }

            return GetById(id);
        }
        public BillViewModel PreCheck(CheckoutModel model, string userId)
        {
            var orders = _dbContext.Orders.Include(f => f.OrderDetails).Where(f => model.Orders.Contains(f.Id)).ToList();

            var removedOrders = new List<Order>();
            foreach (var order in orders)
            {
                var check = false;
                foreach (var item in order.OrderDetails)
                {
                    var x = model.RemovedItems.FirstOrDefault(f => f.ItemId == item.ItemId);
                    if (x == null || x.Quantity < item.Quantity)
                    {
                        check = true;
                        break;
                    }
                }
                if (!check)
                {
                    removedOrders.Add(order);
                    foreach (var item in order.OrderDetails)
                    {
                        var x = model.RemovedItems.First(f => f.ItemId == item.ItemId);
                        model.RemovedItems.Remove(x);
                        if (x.Quantity > item.Quantity)
                        {
                            x.Quantity -= item.Quantity;
                            model.RemovedItems.Add(x);
                        }
                    }
                    order.IsMissing = true;
                    order.IsCheckout = true;
                }
            }
            foreach (var item in removedOrders)
            {
                orders.Remove(orders.First(f => f.Id == item.Id));
            }

            orders = orders.OrderByDescending(s => (s.OrderDetails.Select(s => s.ItemId).Intersect(model.RemovedItems.Select(s => s.ItemId))).Count()).ToList();
            var tables = _dbContext.Tables.Where(f => orders.Select(s => s.TableId).ToList().Contains(f.Id)).ToList();

            Bill newBill = new()
            {
                Discount = model.Discout == null ? 0 : model.Discout.Value,
                CouponCode = model.Coupon,
                IsTakeAway = model.IsTakeAway,
                BillNumber = 0,
                CasherId = userId,
            };
            
            double total = 0;

            var result = new BillViewModel()
            {
                OrderDetailViewModels = new List<OrderDetailViewModel>(),
                Discount = 0,
                BillNumber = 0,
                Coupon = 0,
                DateCreated = DateTime.Now,
                Id = Guid.NewGuid(),
                IsTakeAway = false
            };
            foreach (var order in orders)
            {
                foreach (var item in order.OrderDetails)
                {
                    var currentRemoveItem = model.RemovedItems.FirstOrDefault(f => f.ItemId == item.ItemId);
                    if (currentRemoveItem == null)
                    {
                        item.FinalQuantity = item.Quantity;
                    }
                    else
                    {
                        model.RemovedItems.Remove(currentRemoveItem);
                        if (currentRemoveItem.Quantity == item.Quantity)
                        {
                            item.FinalQuantity = 0;
                        }
                        else if (currentRemoveItem.Quantity < item.Quantity)
                        {
                            item.FinalQuantity -= currentRemoveItem.Quantity;
                            //model.RemovedItems.Add(currentRemoveItem);
                        }
                        else
                        {
                            item.FinalQuantity = 0;
                            currentRemoveItem.Quantity -= item.Quantity;
                            model.RemovedItems.Add(currentRemoveItem);
                        }
                    }

                    if (item.FinalQuantity < 0)
                    {
                        item.FinalQuantity = 0;
                    }

                    total += item.FinalQuantity * item.Price;

                    result.OrderDetailViewModels.Add(new OrderDetailViewModel() { ItemId = item.ItemId, Quantity = item.FinalQuantity });
                }
            }
            return result;
        }
        public List<BillViewModel> History(int count)
        {
            var bills = _dbContext.Bills.OrderByDescending(o => o.DateCreated).Take(count).ToList();
            return GetByList(bills);
        }
        public List<BillMissingItemViewModel> MissingBillItemWithin48Hours()
        {
            var orderDetails = _dbContext.OrderDetails.Where(s => s.Quantity > s.FinalQuantity).Where(s => DateTime.Compare(s.DateUpdated, DateTime.UtcNow.AddHours(7).AddHours(-48)) > 0).ToList();

            var orders = _dbContext.Orders.Where(f => orderDetails.Select(s => s.OrderId).Distinct().ToList().Contains(f.Id)).ToList();

            var billOrders = _dbContext.BillOrders.Where(s => orders.Select(o => o.Id).ToList().Contains(s.OrderId)).ToList();

            var bills = _dbContext.Bills.Where(s => billOrders.Select(b => b.BillId).ToList().Contains(s.Id)).OrderByDescending(f => f.DateCreated).Take(10).ToList();

            List<BillMissingItemViewModel> result = new();

            foreach (var item in bills)
            {
                BillMissingItemViewModel bill = new()
                {
                    Id = item.Id,
                    DateCreated = item.DateCreated,
                    Orders = new List<OrderMissingItemViewModel>(),
                    ItemMissingReason = item.ItemMissingReason,
                    BillNumber = item.BillNumber
                };

                var currentBillOrders = orders.Where(s => billOrders.Where(b => b.BillId == item.Id).ToList().Select(s => s.OrderId).Contains(s.Id)).ToList();
                foreach (var order in currentBillOrders)
                {
                    OrderMissingItemViewModel missingOrder = new()
                    {
                        Id = order.Id,
                        DateCreated = order.DateCreated,
                        TableId = order.TableId,
                        Items = new List<MissingItemViewModel>(),
                        OrderNumber = order.OrderNumber
                    };

                    var currentItems = orderDetails.Where(s => s.OrderId == order.Id).ToList();
                    foreach (var detail in currentItems)
                    {
                        var missingItem = new MissingItemViewModel()
                        {
                            ItemId = detail.ItemId,
                            FinalQuantity = detail.FinalQuantity,
                            Quantity = detail.Quantity
                        };
                        missingOrder.Items.Add(missingItem);
                    }
                    bill.Orders.Add(missingOrder);
                }
                result.Add(bill);
            }
            return result;
        }
        public List<ChartViewModel> ChartData(bool isBillCountChart)
        {
            var currentMonthData = _dbContext.Bills
                .Where(f => f.DateCreated.Year == DateTime.UtcNow.AddHours(7).Year)
                .Where(f => f.DateCreated.Month == DateTime.UtcNow.AddHours(7).Month)
                .ToList();

            List<ChartViewModel> result = new List<ChartViewModel>();
            for (int i = 1; i <= DateTime.UtcNow.AddHours(7).Day; i++)
            {
                var date = new DateTime(DateTime.UtcNow.AddHours(7).Year, DateTime.UtcNow.AddHours(7).Month, i);

                double total;
                if (isBillCountChart)
                {
                    total = currentMonthData.Where(f => f.DateCreated.Day == i).Count();
                }
                else
                {
                    total = currentMonthData.Where(f => f.DateCreated.Day == i).Sum(f => f.Total - f.Discount - f.Coupon);
                }

                TimeSpan t = date - new DateTime(1970, 1, 1);
                double secondsSinceEpoch = (double)t.TotalMilliseconds;

                ChartViewModel chart = new ChartViewModel()
                {
                    Date = secondsSinceEpoch,
                    Total = total
                };
                result.Add(chart);
            }
            return result;
        }
        public BillViewModel GetById(Guid id)
        {
            var bills = _dbContext.Bills.Where(f => f.Id == id).ToList();
            return GetByList(bills).First();
        }
        private List<BillViewModel> GetByList(List<Bill>? bills)
        {
            var billOrders = _dbContext.BillOrders.Where(s => bills.Select(s => s.Id).Contains(s.BillId)).ToList();

            var orderDetails = _dbContext.OrderDetails.Where(f => billOrders.Select(s => s.OrderId).Contains(f.OrderId)).ToList();

            var result = new List<BillViewModel>();
            foreach (var bill in bills)
            {
                var billData = new BillViewModel()
                {
                    Id = bill.Id,
                    DateCreated = bill.DateCreated,
                    Discount = bill.Discount,
                    IsTakeAway = bill.IsTakeAway,
                    BillNumber = bill.BillNumber,
                    Coupon = bill.Coupon,
                };

                var orders = billOrders.Where(f => f.BillId == bill.Id).ToList();
                var details = orderDetails.Where(f => orders.Select(s => s.OrderId).Contains(f.OrderId)).ToList();
                var orderDetailViewModels = new List<OrderDetailViewModel>();

                foreach (var item in details)
                {
                    var orderDetail = new OrderDetailViewModel()
                    {
                        ItemId = item.ItemId,
                        Quantity = item.FinalQuantity,
                        Description = item.Price.ToString(),
                    };
                    orderDetailViewModels.Add(orderDetail);
                }

                billData.OrderDetailViewModels = orderDetailViewModels;
                result.Add(billData);
            }
            return result;
        }
        public Guid UpdateReason(BillMissingItemUpdateModel model)
        {
            var bill = _dbContext.Bills.FirstOrDefault(f => f.Id == model.Id);
            if (bill == null) throw new AppException("Invalid id");

            bill.ItemMissingReason = model.MissingItemReason;
            bill.DateUpdated = DateTime.UtcNow.AddHours(7);

            _dbContext.Update(bill);
            _dbContext.SaveChanges();

            return bill.Id;
        }
        public BilPagingModel ExportData(DateTime? date, DateTime? fromDate, DateTime? toDate, bool isNewest, int? pageIndex, int? pageSize)
        {
            var querry = _dbContext.Bills.Where(f => date == null || date.Value.Date == f.DateCreated.Date)
                .Where(f => (fromDate == null || toDate == null) || (f.DateCreated.Date >= fromDate.Value.Date && f.DateCreated.Date <= toDate.Value.Date));

            if (isNewest)
            {
                querry = querry.OrderByDescending(f => f.DateCreated);
            }
            else
            {
                querry = querry.OrderBy(f => f.DateCreated);
            }

            var total = querry.Count();
            double estimateIncome = querry.Sum(s => s.Total);
            double income = querry.Sum(s => s.Total - s.Discount - s.Coupon);

            List<Bill> data;
            if (pageIndex != null && pageSize != null)
            {
                data = querry.Skip((pageIndex.Value - 1) * pageSize.Value).Take(pageSize.Value).ToList();
            }
            else
            {
                data = querry.ToList();
            }

            List<BillStatisticModel> result = _mapper.Map<List<BillStatisticModel>>(data);

            var billOrders = _dbContext.BillOrders.Where(f => result.Select(s => s.Id).Contains(f.BillId)).ToList();
            var orders = _dbContext.Orders.Where(f => billOrders.Select(s => s.OrderId).Contains(f.Id)).ToList();

            foreach (var bill in result)
            {
                var currentBillOrders = billOrders.Where(f => f.BillId == bill.Id);

                var currentOrders = orders.Where(f => currentBillOrders.Select(s => s.OrderId).Contains(f.Id)).ToList();
                bill.Orders = _mapper.Map<List<OrderStatisticModel>>(currentOrders);
            }

            return new BilPagingModel() { Data = result, EstimateIncome = estimateIncome, Income = income, Total = total };
        }
    }
}

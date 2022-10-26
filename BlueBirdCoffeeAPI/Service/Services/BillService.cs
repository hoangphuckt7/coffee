using AutoMapper;
using Data.DataAccessLayer;
using Data.Entities;
using Data.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public interface IBillService
    {
        BillViewModel Checkout(CheckoutModel model, string userId);
        List<BillViewModel> History(int count);
        List<BillMissingItemViewModel> MissingBillItemWithin48Hours();
        List<ChartViewModel> ChartData();
        StatisticsModels Statistics();
    }

    public class BillService : IBillService
    {
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;

        public BillService(AppDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public StatisticsModels Statistics()
        {
            var items = _dbContext.Items.ToList();

            var thisMonth = GetStatisticsForMonth(DateTime.UtcNow.AddHours(7), items);

            var lastMonth = GetStatisticsForMonth(DateTime.UtcNow.AddHours(7).AddMonths(-1), items);

            return new StatisticsModels()
            {
                Income = thisMonth.Income,
                BestSellerCount = thisMonth.BestSellerCount,
                BestSellerItemName = thisMonth.BestSellerItemName,

                BestSellerLastMonthCount = lastMonth.BestSellerCount,
                BestSellerLastMonthItemName = lastMonth.BestSellerItemName,
                IncomeLastMonth = lastMonth.Income
            };
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

            Bill newBill = new Bill()
            {
                Discount = model.Discout,
                Coupon = model.Coupon,
                IsTakeAway = model.IsTakeAway,
                BillNumber = GetCurrentBillNumber(),
                CasherId = userId
            };

            _dbContext.Add(newBill);

            foreach (var order in orders)
            {
                bool isMissing = false;
                foreach (var item in order.OrderDetails)
                {
                    var x = model.RemovedItems.FirstOrDefault(f => f.ItemId == item.ItemId);
                    if (x == null)
                    {
                        item.FinalQuantity = item.Quantity;
                    }
                    else
                    {
                        model.RemovedItems.Remove(x);
                        if (x.Quantity == item.Quantity)
                        {
                            item.FinalQuantity = 0;
                        }
                        else if (x.Quantity < item.Quantity)
                        {
                            item.FinalQuantity -= x.Quantity;
                        }
                        else
                        {
                            item.FinalQuantity = item.Quantity;
                            x.Quantity -= item.Quantity;
                            model.RemovedItems.Add(x);
                        }
                        isMissing = true;
                    }
                    _dbContext.Update(item);
                }

                order.IsMissing = isMissing;
                order.IsCheckout = true;

                if (order.TableId != null)
                {
                    var table = tables.First(f => f.Id == order.TableId);
                    if (table.CurrentOrder > 0)
                    {
                        table.CurrentOrder -= 1;
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
            return GetById(newBill.Id);
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
        public List<ChartViewModel> ChartData()
        {
            var currentMonthData = _dbContext.Bills
                .Where(f => f.DateCreated.Year == DateTime.UtcNow.AddHours(7).Year)
                .Where(f => f.DateCreated.Month == DateTime.UtcNow.AddHours(7).Month)
                .ToList();

            List<ChartViewModel> result = new List<ChartViewModel>();
            for (int i = 1; i <= DateTime.Now.Day; i++)
            {
                var date = new DateTime(DateTime.Now.Year, DateTime.Now.Month, i);
                var total = currentMonthData.Where(f => f.DateCreated.Day == i).ToList().Count;

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
                    //Coupon = bill.Coupon,
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
    }
}

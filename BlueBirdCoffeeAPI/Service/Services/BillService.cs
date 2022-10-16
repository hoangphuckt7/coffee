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
        Guid Checkout(CheckoutModel model);
        List<BillViewModel> History(int count);
        List<BillMissingItemViewModel> MissingBillItemWithin48Hours();
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
        public int GetCurrentBillNumber()
        {
            var lastestBill = _dbContext.Bills.OrderByDescending(s => s.DateCreated).FirstOrDefault();

            if (lastestBill != null && lastestBill.DateCreated.Date == DateTime.UtcNow.AddHours(7).Date)
            {
                return lastestBill.BillNumber + 1;
            }

            return 1;
        }
        public Guid Checkout(CheckoutModel model)
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
                BillNumber = GetCurrentBillNumber()
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
            return newBill.Id;
        }
        public List<BillViewModel> History(int count)
        {
            var bills = _dbContext.Bills.OrderByDescending(o => o.DateCreated).Take(count).ToList();

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
    }
}

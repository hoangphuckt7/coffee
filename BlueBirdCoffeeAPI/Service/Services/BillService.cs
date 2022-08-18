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

        public void Checkout(List<OrderViewModel> model, List<OrderDetailViewModel> dataList)
        {
            var orders = _dbContext.Orders.Include(f => f.OrderDetails).Where(f => model.Select(s => s.Id).ToList().Contains(f.Id)).ToList();

            List<Guid> completeOrders = new();
            List<Guid> missingOrders = new();
            foreach (var order in orders)
            {
                var checkMissing = false;
                List<OrderDetail> completedItem = new();
                foreach (var item in order.OrderDetails)
                {
                    var existedItem = dataList.FirstOrDefault(f => f.ItemId == item.ItemId);
                    if (existedItem == null)
                    {
                        checkMissing = true;
                        missingOrders.Add(order.Id);
                        break;
                    }
                    if (item.Quantity > existedItem.Quantity)
                    {
                        checkMissing = true;
                        missingOrders.Add(order.Id);
                        break;
                    }
                    completedItem.Add(item);
                }
                if (!checkMissing)
                {
                    completeOrders.Add(order.Id);
                    foreach (var item in completedItem)
                    {
                        var removeItem = dataList.First(f => f.ItemId == item.ItemId);
                        if (removeItem.Quantity == item.Quantity)
                        {
                            dataList.Remove(removeItem);
                        }
                        else
                        {
                            dataList.Remove(removeItem);
                            removeItem.Quantity -= item.Quantity;
                            dataList.Add(removeItem);
                        }
                    }
                }
            }

            if (dataList != null && dataList.Count > 0)
            {
                foreach (var item in missingOrders)
                {

                }
            }

            foreach (var item in orders)
            {
                //var inputOrder = model.FirstOrDefault(f => f.Id == item.Id);
                //if (inputOrder == null)
                //{
                //    item.IsMissing = true;
                //}

                foreach (var details in item.OrderDetails)
                {
                    var inputDetail = model.First(f => f.Id == item.Id).OrderDetails.FirstOrDefault(f => f.ItemId == details.ItemId);
                    if (inputDetail == null)
                    {
                        //details.IsMissing = true;
                        _dbContext.Update(details);
                    }
                    else
                    {

                    }
                }
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueBirdCoffeManager.Models
{
    public class OrderReceiverModel
    {
        public Guid Id { get; set; }
        public int OrderNumber { get; set; }
        public Guid? TableId { get; set; }
        public DescriptionModel? Table { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
        public List<OrderDetailViewModel> OrderDetails { get; set; }
    }

    public class DescriptionModel
    {
        [Required]
        public string? Description { get; set; }
    }

    public class OrderViewModel
    {
        public Guid Id { get; set; }
        public Guid? TableId { get; set; }
        public DateTime DateCreated { get; set; }
        public List<OrderDetailViewModel> OrderDetails { get; set; }
    }

    public class OrderDetailViewModel
    {
        public Guid ItemId { get; set; }
        public int Quantity { get; set; }
        public string? Description { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.Now;
    }

    public class MaxQuantityOrderModel
    {
        public Guid ItemId { get; set; }
        public int Quantity { get; set; }
    }

    public class OrderDetailModel
    {
        public Guid ItemId { get; set; }
        public int Quantity { get; set; }
        public string? Description { get; set; }
    }

    public class OrderCreateModel
    {
        public Guid? TableId { get; set; }
        public double? Coupon { get; set; }
        public double? Discount { get; set; }
        public List<OrderDetailViewModel> OrderDetail { get; set; } = new List<OrderDetailViewModel>();
    }

    public class OrderHistoryModel : OrderCreateModel
    {
        public DateTime DateCreated { get; set; }
    }

    public class DetailValue
    {
        public int Sugar { get; set; }
        public int Ice { get; set; }
        public string Note { get; set; }
    }

    public class TempOrderDetailModel
    {
        public int Quantity { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
    }

    public class CheckoutModel
    {
        public List<Guid> Orders { get; set; }
        public bool IsTakeAway { get; set; }
        public double Discout { get; set; }
        public string Coupon { get; set; }
        public List<ItemCheckoutModel> RemovedItems { get; set; }
    }

    public class ItemCheckoutModel
    {
        public Guid ItemId { get; set; }
        public int Quantity { get; set; }
    }

    public class SetMissingOrders
    {
        public Guid OrderId { get; set; }
        public string Reason { get; set; }
    }

    public class ChangeOrdersTable
    {
        public List<Guid> OrderIds { get; set; }
        public Guid NewTableId { get; set; }
    }
}

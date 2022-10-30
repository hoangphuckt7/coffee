using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.ViewModels
{
    public class OrderCreateModel
    {
        public Guid? TableId { get; set; }
        public List<OrderDetailModel> OrderDetail { get; set; }
    }

    public class OrderDetailModel
    {
        public Guid ItemId { get; set; }
        public int Quantity { get; set; }
        public string? Description { get; set; }
    }

    public class OrderViewModel
    {
        public Guid Id { get; set; }
        public int OrderNumber { get; set; }
        public Guid? TableId { get; set; }
        public DescriptionModel? Table { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
        public List<OrderDetailViewModel> OrderDetails { get; set; }
    }

    public class OrderDetailViewModel
    {
        public Guid ItemId { get; set; }
        public int Quantity { get; set; }
        public string? Description { get; set; }
        public bool IsMissing { get; set; }
    }

    public class SetMissingOrders
    {
        public List<Guid> OrderIds { get; set; }
    }

    public class SetMissingItem
    {
        public Guid OrderId { get; set; }
        public Guid ItemId { get; set; }
    }

    public class CheckoutModel
    {
        public List<Guid> Orders { get; set; }
        public bool IsTakeAway { get; set; }
        public double? Discout { get; set; }
        public string? Coupon { get; set; }
        public List<ItemCheckoutModel> RemovedItems { get; set; }
    }

    public class ItemCheckoutModel
    {
        public Guid ItemId { get; set; }
        public int Quantity { get; set; }
    }
}

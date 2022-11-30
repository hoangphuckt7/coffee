using Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.ViewModels
{
    public class BillMissingItemUpdateModel
    {
        public Guid Id { get; set; }
        public string MissingItemReason { get; set; }
    }
    public class BillViewModel
    {
        public Guid Id { get; set; }
        public int BillNumber { get; set; }
        public double? Discount { get; set; }
        public bool IsTakeAway { get; set; }
        public double? Coupon { get; set; }
        public DateTime DateCreated { get; set; }
        public List<OrderDetailViewModel> OrderDetailViewModels { get; set; }
    }

    public class BillMissingItemViewModel
    {
        public Guid Id { get; set; }
        public int BillNumber { get; set; }
        public string? ItemMissingReason { get; set; }
        public DateTime DateCreated { get; set; }
        public List<OrderMissingItemViewModel> Orders { get; set; }
    }

    public class OrderMissingItemViewModel
    {
        public Guid Id { get; set; }
        public int OrderNumber { get; set; }
        public Guid? TableId { get; set; }
        public DateTime DateCreated { get; set; }
        public List<MissingItemViewModel> Items { get; set; }
    }

    public class MissingItemViewModel
    {
        public Guid ItemId { get; set; }
        public int Quantity { get; set; }
        public int FinalQuantity { get; set; }
    }

    public class ChartViewModel
    {
        public double Total { get; set; }
        public double Date { get; set; }
    }

    public class BillStatisticModel
    {
        public Guid Id { get; set; }
        public string? Description { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
        public bool IsDeleted { get; set; } = false;
        public string? ItemMissingReason { get; set; }
        public double? Coupon { get; set; }
        public double? Discount { get; set; }
        public bool IsTakeAway { get; set; }
        public int BillNumber { get; set; }
        public double Total { get; set; }
        public string? CouponCode { get; set; }
        public BaseStringModel? Casher { get; set; }
        public BaseStringModel? Customer { get; set; }
        public List<OrderStatisticModel> Orders { get; set; } = new List<OrderStatisticModel>();
    }

    public class OrderStatisticModel
    {
        public Guid Id { get; set; }
        public string? Description { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
        public bool IsDeleted { get; set; } = false;
        public int OrderNumber { get; set; }
        public bool IsCompleted { get; set; } = false;
        public bool IsCheckout { get; set; } = false;
        public bool IsRejected { get; set; } = false;
        public bool IsMissing { get; set; } = false;
        public string? RejectedReason { get; set; }
        public DescriptionViewModel? Table { get; set; }
        public BaseStringModel? Employee { get; set; }
        public BaseStringModel? Bartender { get; set; }
        public BaseStringModel? UserRejected { get; set; }
        public List<OrderDetailStatisticModel> OrderDetails { get; set; } = new List<OrderDetailStatisticModel>();
    }

    public class OrderDetailStatisticModel
    {
        public Guid OrderId { get; set; }
        public DescriptionViewModel? Item { get; set; }

        public DateTime DateUpdated { get; set; }
        public int Quantity { get; set; }
        public int FinalQuantity { get; set; }
        public string? MissingReason { get; set; }
        public double Price { get; set; }
        public string? Description { get; set; }
    }
}

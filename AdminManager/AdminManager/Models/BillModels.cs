namespace AdminManager.Models
{
    public class ChartViewModel
    {
        public double Total { get; set; }
        public double Date { get; set; }
    }

    public class BaseStringModel
    {
        public string Id { get; set; } = null!;
        public string? Description { get; set; }
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

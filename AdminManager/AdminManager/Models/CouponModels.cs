namespace AdminManager.Models
{
    public class CouponViewModel
    {
        public Guid Id { get; set; }
        public string Description { get; set; } = null!;
        public DateTime DateUpdated { get; set; } = DateTime.UtcNow.AddHours(7);
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public int? Limit { get; set; }
        public double? Maximum { get; set; }
        public double? Minium { get; set; }
        public double? Discount { get; set; }
        public bool Default { get; set; }
    }

    public class CouponAddModel
    {
        public string Description { get; set; } = null!;
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public int? Limit { get; set; }
        public double? Maximum { get; set; }
        public double? Minium { get; set; }
        public double? Discount { get; set; }
        public bool Default { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.ViewModels
{
    public class CouponAddModel
    {
        public string Description { get; set; } = null!;
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public int? Limit { get; set; }
        public double? Maximum { get; set; }
        public double? Minium { get; set; }
        public double? Discount { get; set; }
        public bool Default { get; set; } = false;
    }

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
        public bool Default { get; set; } = false;
    }

    public class CouponUseableModel
    {
        public Guid Id { get; set; }
        public string Description { get; set; } = null!;
        public int? Limit { get; set; }
        public double? Maximum { get; set; }
        public double? Minium { get; set; }
        public double? Discount { get; set; }
        public bool Default { get; set; } = false;
    }
}

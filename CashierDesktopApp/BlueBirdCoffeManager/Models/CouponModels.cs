using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueBirdCoffeManager.Models
{
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

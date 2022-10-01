using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.ViewModels
{
    public class BillViewModel
    {
        public Guid Id { get; set; }
        public double Discount { get; set; }
        public bool IsTakeAway { get; set; }
        public double Coupon { get; set; }
        public DateTime DateCreated { get; set; }
        public List<OrderDetailViewModel> OrderDetailViewModels { get; set; }
    }
}

using System;
using System.Collections.Generic;
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
        public int Total { get; set; }
        public double Date { get; set; }
    }
}

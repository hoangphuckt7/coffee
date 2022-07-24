using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueBirdCoffeManager.Models
{
    public class OrderViewModel
    {
        public Guid Id { get; set; }
        public Guid TableId { get; set; }
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

    public class OrderDetailModel
    {
        public Guid ItemId { get; set; }
        public int Quantity { get; set; }
        public string? Description { get; set; }
    }

    public class OrderCreateModel
    {
        public Guid? TableId { get; set; }
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
}

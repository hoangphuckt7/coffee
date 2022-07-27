﻿using System;
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
        public Guid TableId { get; set; }
        public DateTime DateCreated { get; set; }
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
        public Guid OrderIds { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataCenter.Collections
{
    public class Order : BaseMongoCollection
    {
        public int OrderNumber { get; set; }
        public bool IsCompleted { get; set; } = false;
        public bool IsCheckout { get; set; } = false;
        public bool IsRejected { get; set; } = false;
        public bool IsMissing { get; set; } = false;
        public string? RejectedReason { get; set; }
        public Guid? TableId { get; set; }
        public string? EmployeeId { get; set; }
        public string? BartenderId { get; set; }
        public string? UserRejectedId { get; set; }
    }
}

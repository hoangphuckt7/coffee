using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class Order : BaseEntity
    {

        [ForeignKey("Table")]
        public Guid? TableId { get; set; }
        public virtual Table? Table { get; set; }


        [ForeignKey("User")]
        public string? EmployeeId { get; set; }
        public virtual User? Employee { get; set; }
    }
}

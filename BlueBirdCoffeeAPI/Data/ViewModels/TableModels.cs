using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.ViewModels
{
    public class TableAddModel
    {
        public Guid FloorId { get; set; }
        [Required]
        public string? Description { get; set; }
    }

    public class TableViewModel
    {
        public Guid Id { get; set; }
        public string? Description { get; set; }
        public DescriptionViewModel? Floor { get; set; }
    }
}

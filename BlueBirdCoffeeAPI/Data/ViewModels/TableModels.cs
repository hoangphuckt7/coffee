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
        public string Position { get; set; }
        public string Size { get; set; }
        public string Shape { get; set; }
        public Guid FloorId { get; set; }
        public string Description { get; set; }
    }

    public class TableViewModel
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public bool IsAvailable { get; set; }
        public string Position { get; set; }
        public string Size { get; set; }
        public string Shape { get; set; }
        public DescriptionViewModel Floor { get; set; }
    }

    public class TableUpdateModel
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public string Position { get; set; }
        public string Size { get; set; }
        public string Shape { get; set; }
        public Guid FloorId { get; set; }
    }
}

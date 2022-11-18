using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.ViewModels
{
    public class DescriptionModel
    {
        [Required]
        public string? Description { get; set; }
    }

    public class DescriptionViewModel
    {
        public Guid Id { get; set; }
        public string? Description { get; set; }
    }

    public class BaseIntModel
    {
        public Guid Id { get; set; }
        public int Data { get; set; }
    }

    public class BaseStringModel
    {
        public string Id { get; set; }
        public string? Description { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueBirdCoffeManager.Models
{
    public class ItemViewModel
    {
        public string Id { get; set; }
        public string Description { get; set; }
        public object Name { get; set; }
        public double Price { get; set; }
        public bool Available { get; set; }
        public DescriptionViewModel Category { get; set; }
        public List<string> Images { get; set; }
    }
}

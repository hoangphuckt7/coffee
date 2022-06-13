using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueBirdCoffeManager.Sessions
{
    public class ItemSession
    {
        public static List<ItemImages> Items = new List<ItemImages>();
    }
    public class ItemImages
    {
        public Guid Id { get; set; }
        public List<Image> Images { get; set; } = new List<Image>();
    }
}

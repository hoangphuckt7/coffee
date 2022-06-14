using BlueBirdCoffeManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueBirdCoffeManager.Sessions
{
    public class ItemSession
    {
        public static List<ItemImages> Items = new();
        public static List<ItemViewModel> ItemData = new();
    }
    public class ItemImages
    {
        public Guid Id { get; set; }
        public List<Image> Images { get; set; } = new List<Image>();
    }

    public class Order
    {
        public static OrderCreateModel CurrentOrder = new();
    }
}

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
        public static OrderOption Option = new();

        public static List<OrderHistoryModel> OldOrders = new();
    }

    public class Area
    {
        public static List<DescriptionViewModel> Areas = new();
    }

    public class OrderOption
    {
        public bool TakeAway { get; set; }
        public bool Unknow { get; set; }
        public bool Table { get; set; }
    }
}

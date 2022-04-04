using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueBirdCoffeManager.Models
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
        public Guid? Id { get; set; }
        public string? Description { get; set; }
        public int? CurrentOrder { get; set; }
        public string Position { get; set; }
        public string Size { get; set; }
        public string? Shape { get; set; }
        public DescriptionViewModel? Floor { get; set; }
        public Rectangle? Rectangle { get; set; }

        public void ConvertToRectangle()
        {
            string[] pos = this.Position.Split(",");
            string[] size = this.Size.Split(",");
            Rectangle = new Rectangle(int.Parse(pos[0]), int.Parse(pos[1]), int.Parse(size[0]), int.Parse(size[1]));
        }


    }

    public class TableUpdateModel
    {
        public Guid? Id { get; set; }
        public string? Description { get; set; }
        public string Position { get; set; }
        public string Size { get; set; }
        public string? Shape { get; set; }
        public Guid FloorId { get; set; }
    }
}

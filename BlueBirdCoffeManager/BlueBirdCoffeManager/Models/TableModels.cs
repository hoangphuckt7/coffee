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
        public int Rotation { get; set; }
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
        public int Rotation { get; set; } = 0;

        public void ConvertToRectangle()
        {
            var wW = Sessions.Sessions.TABLE_WORK_SPACE.Value.X;
            var wH = Sessions.Sessions.TABLE_WORK_SPACE.Value.Y;
            string[] pos = this.Position.Split("-");
            string[] size = this.Size.Split("-");
            Rectangle = new Rectangle((int)(double.Parse(pos[0]) * wW / 100), (int)(double.Parse(pos[1]) * wH / 100), (int)(double.Parse(size[0]) * wW / 100), (int)(double.Parse(size[1]) * wH / 100));
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
        public int Rotation { get; set; } = 0;
    }
}

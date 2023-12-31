﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class Table : BaseEntity
    {
        public int CurrentOrder { get; set; } = 0;
        public string Position { get; set; }
        public string Size { get; set; }
        public string Shape { get; set; }
        public int Rotation { get; set; }

        [ForeignKey("Floor")]
        public Guid FloorId { get; set; }
        public virtual Floor? Floor { get; set; }
    }
}

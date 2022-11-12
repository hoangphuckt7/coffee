﻿namespace AdminManager.Models
{
    public class ItemViewModel
    {
        public Guid Id { get; set; }
        public string? Description { get; set; }
        public string? Name { get; set; }
        public double Price { get; set; }
        public bool Available { get; set; }
        public DescriptionViewModel? Category { get; set; }
        public List<Guid>? Images { get; set; }
    }

    public class DescriptionViewModel
    {
        public Guid Id { get; set; }
        public string? Description { get; set; }
    }

    public class ItemAddModel
    {
        public string? Description { get; set; }
        public string Name { get; set; } = null!;
        public double Price { get; set; }
        public Guid CategoryId { get; set; }

        public List<IFormFile>? Images { get; set; }
    }
}
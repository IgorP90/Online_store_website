﻿namespace backend.Models
{
    public class NarrowCategory
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Product> Products { get; set; } = new List<Product>();
    }
}

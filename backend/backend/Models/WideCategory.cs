﻿namespace backend.Models
{
    public class WideCategory
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Image { get; set; }

        public List<Product> Products { get; set; }
    }
}

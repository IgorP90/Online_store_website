﻿namespace backend.Models
{
    public class Product : IProduct, INarrowCategory, IWideCategory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public float Price { get; set; }
        public string Image { get; set; }
        public int NumberOfOrders { get; set; }
        public float Rating { get; set; }
        public DateTime DateTime { get; set; }
        public int? NarrowCategoryId { get; set; }
        public int? ShoppingCartId { get; set; }
        public int? OrdertId { get; set; }
        public List<WideCategory> WideCategories { get; set; } = new List<WideCategory>();

        public NarrowCategory? NarrowCategory { get; set; }
        public ShoppingСart? ShoppingCart { get; set; }
        public Order? Order { get; set; }


    }
}

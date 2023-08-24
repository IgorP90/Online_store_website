using backend.CRUD;
using System.ComponentModel.DataAnnotations;

namespace backend.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public float Price { get; set; }
        public string Image { get; set; }
        public int NumberOfOrders { get; set; }
        public float Rating { get; set; }    
        public DateTime DateTime { get; set; }
    }
}

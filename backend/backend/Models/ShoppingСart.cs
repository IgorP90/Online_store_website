using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Models
{
    public class ShoppingСart
    {
        public int Id { get; set; }
        //public int ProductId { get; set; }
        public List<Product>? Product { get; set; }
        public int Quantity { get; set; }
    }
}

namespace backend.Models
{
    public class ShoppingСart
    {
        public int Id { get; set; }
        public List<Product>? Product { get; set; }
        public int Quantity { get; set; }
    }
}

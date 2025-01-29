namespace backend.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int OrderStatus { get; set; }
        public List<Product> Products { get; set; }

    }
}

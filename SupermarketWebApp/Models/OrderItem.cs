namespace SupermarketWebApp.Models
{
    public class OrderItem
    {
        public int orderId { get; set; }
        public int productId { get; set; }
        public Product product { get; set; }
        public Order order { get; set; }
        public int quantity { get; set; }
    }
}

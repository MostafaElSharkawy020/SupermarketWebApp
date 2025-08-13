namespace SupermarketWebApp.Models
{
    public class Order
    {
        public int id { get; set; }
        public int userId { get; set; }
        public User user { get; set; }
        public DateTime orderDate { get; set; }
        public List<OrderItem> orderItems { get; set; } = new List<OrderItem>();
        public decimal totalPrice { get; set; }
    }
}

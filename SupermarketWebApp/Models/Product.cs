namespace SupermarketWebApp.Models
{
    public class Product
    {
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public decimal price { get; set; }
        public string imagePath { get; set; }
        public int quantity { get; set; }
        public int categoryId { get; set; }
        public Category category { get; set; }
    }
}

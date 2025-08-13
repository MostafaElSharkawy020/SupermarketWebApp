namespace SupermarketWebApp.Models
{
    public class Card
    {
        public int id { get; set; }
        public string cardNumber { get; set; } // Masked for security
        public string cardHolderName { get; set; }
        public DateTime expirationDate { get; set; }
        public string cvv { get; set; } // Masked for security
        public User user { get; set; }

    }
}

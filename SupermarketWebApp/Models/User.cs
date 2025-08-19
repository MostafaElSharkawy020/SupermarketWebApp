using System.ComponentModel.DataAnnotations;

namespace SupermarketWebApp.Models
{
    public class User
    {
        public int id { get; set; }

        
        public string firstName { get; set; }

        
        public string lastName { get; set; }

        public string email { get; set; }

   
        public string password { get; set; } //Hashed password
        
       
        public string phoneNumber { get; set; }


        public string address { get; set; }
        public List<Order> orders { get; set; } = new List<Order>();
        public int cardId { get; set; }
        public Card card { get; set; }
    }
}

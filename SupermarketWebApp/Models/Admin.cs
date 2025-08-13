namespace SupermarketWebApp.Models
{
    public class Admin
    {
        public int Id { get; set; }
        public string email { get; set; }
        public string password { get; set; } // Hashed password
        public string username { get; set; }
    }
}

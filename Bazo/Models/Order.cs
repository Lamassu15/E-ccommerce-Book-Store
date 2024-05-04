namespace Bazo.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public string Status { get; set; }
        public DateTime Date { get; set; }
        public List<CartItem> OrderDetails { get; set; }
    }
}
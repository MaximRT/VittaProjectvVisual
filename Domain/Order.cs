namespace Domain
{
    public class Order
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public DateTime DateCreation { get; set; }
        public decimal Price { get; set; }
        public User User { get; set; }
    }
}
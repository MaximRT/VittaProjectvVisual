namespace Domain
{
    public class Order
    {
        public Guid Id { get; set; }
        public DateTime DateCreation { get; set; }
        public decimal Price { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }

        public ICollection<OrderPosition> OrderPositions { get; set; } = new List<OrderPosition>();
    }
}
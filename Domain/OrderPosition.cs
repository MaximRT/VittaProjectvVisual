namespace Domain
{
    public class OrderPosition
    {
        public Guid Id { get; set; }
        public Guid OrderId { get; set; }
        public Guid ProductId { get; set; }
        public int Count { get; set; }

        public Order Order { get; set; }
        public Product Product { get; set; }
    }
}
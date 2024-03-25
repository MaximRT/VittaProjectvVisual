namespace Domain
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Count { get; set; }

        public ICollection<OrderPosition> OrderPositions { get; set; } = new List<OrderPosition>();
    }
}
namespace Domain
{
    public class User
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Login { get; set; }
        public ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}
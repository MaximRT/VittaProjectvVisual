namespace Application.DTOs
{
    public class ListUserOrdersDto
    {
        public Guid Id { get; set; }
        public DateTime DateCreation { get; set; }
        public decimal Price { get; set; }
    }
}
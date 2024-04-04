namespace Application.DTOs
{
    public class OrderDto
    {
        public string UserId { get; set; }
        public decimal Price { get; set; }

        public List<ProductNameDto> Products { get; set; }
    }
}
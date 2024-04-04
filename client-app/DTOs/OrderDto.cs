using System.Collections.Generic;

namespace client_app.DTOs
{
    internal class OrderDto
    {
        public string UserId { get; set; }
        public decimal Price { get; set; }

        public List<ProductNameDto> Products { get; set; }
    }
}

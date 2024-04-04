using client_app.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace client_app.OrderSection
{
    internal interface IOrderService
    {
        Task CreateOrder(string userId, decimal price, List<ProductNameDto> products);
    }
}
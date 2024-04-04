using client_app.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace client_app.ProductSection
{
    internal interface IProductService
    {
        Task<List<ProductToUserDto>> GetListProducts();
    }
}
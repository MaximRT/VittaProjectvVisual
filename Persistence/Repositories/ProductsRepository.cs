using Application.DTOs;
using Application.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repositories
{
    public class ProductsRepository : IProductsRepository
    {
        private readonly DataContext _context;

        public ProductsRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<List<ProductIdDto>> GetListProductsIdByName(List<ProductDto> products)
        {
            List<ProductIdDto> productIds = new List<ProductIdDto>();

            foreach (var product in products)
            {
                var productId =  await _context.Products.Where(x => x.Name == product.Name).Select(x => x.Id).FirstAsync();
                productIds.Add(new ProductIdDto{ Id = productId, Count = product.Count});
            }

            return productIds;
        }
    }
}
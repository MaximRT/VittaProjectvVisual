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

        public async Task<List<ProductToUserDto>> GetListProductsAsync()
        {
            return await _context.Products.Select(x => 
                new ProductToUserDto 
                { 
                    Name = x.Name,
                    Count = x.Count,
                    Price = x.Price
                })
                .ToListAsync();
        }
        public async Task<List<ProductIdDto>> GetListProductsIdByNameAsync(List<ProductNameDto> products)
        {
            List<ProductIdDto> productIds = new List<ProductIdDto>();

            foreach (var product in products)
            {
                var productId =  await _context.Products.Where(x => x.Name == product.Name).Select(x => x.Id).FirstAsync();
                productIds.Add(new ProductIdDto{ Id = productId, Count = product.Count});
            }

            return productIds;
        }

        public async Task UpdateCountProductsAsync(List<ProductIdDto> products)
        {
            var productIdToUpdate = products.Select(x => x.Id);

            var productsToUpdateOld = await _context.Products
                .Where(p => productIdToUpdate.Contains(p.Id)).ToListAsync();

            for (int i = 0; i < productIdToUpdate.Count(); i++)
            {
                var newValueCount = productsToUpdateOld[i].Count - products[i].Count;

                productsToUpdateOld[i].Count = newValueCount;
            }

            await SaveChangesAsync();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
using Domain;

namespace Persistence
{
    public class SeedData
    {
        public static async Task Seed(DataContext context)
        {
            if (context.Users.Any() && context.Products.Any()) return;

            var users = new List<User>  
            {
                new User
                {
                    Name = "Maxim",
                    Login = "maxim@gmail.com"
                },
                new User
                {
                    Name = "Ivan",
                    Login = "ivan@gmail.com"
                },
                new User
                {
                    Name = "Sasha",
                    Login = "sasha@gmail.com"
                }
            };

            var products = new List<Product>
            {
                new Product
                {
                    Name = "Утюг",
                    Price = 1500,
                    Count = 5
                },
                new Product
                {
                    Name = "Карандаш",
                    Price = 50,
                    Count = 15
                },
                new Product
                {
                    Name = "Пенал",
                    Price = 100,
                    Count = 10
                },
                new Product
                {
                    Name = "Компьютерная мышь",
                    Price = 2000,
                    Count = 7
                },
                new Product
                {
                    Name = "Тетрадь",
                    Price = 56,
                    Count = 20
                }
            };

            await context.Users.AddRangeAsync(users);
            await context.Products.AddRangeAsync(products);
            
            await context.SaveChangesAsync();
        }
    }
}
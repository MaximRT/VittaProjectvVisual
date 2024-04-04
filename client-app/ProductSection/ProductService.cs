using client_app.DTOs;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows;

namespace client_app.ProductSection
{
    /// <summary>
    /// Сервис взаимодействия с областью Product
    /// </summary>
    class ProductService : IProductService
    {
        private readonly HttpClient _httpClient;

        public ProductService()
        {
            _httpClient = new HttpClient();
        }

        /// <summary>
        /// Получение списка товаров из API
        /// </summary>
        /// <returns> Список товаров </returns>
        public async Task<List<ProductToUserDto>> GetListProducts()
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string url = "http://localhost:5117/api/product/list";

                    HttpResponseMessage response = await client.GetAsync(url);

                    if (response.IsSuccessStatusCode)
                    {
                        string json = await response.Content.ReadAsStringAsync();

                        List<ProductToUserDto> items = JsonConvert.DeserializeObject<List<ProductToUserDto>>(json);

                        return items;
                    }
                    else
                    {
                        MessageBox.Show($"Ошибка при выполнении запроса: {response.StatusCode}");
                        return new List<ProductToUserDto>();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}");
                return new List<ProductToUserDto>();
            }
        }
    }
}

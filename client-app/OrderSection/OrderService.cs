using client_app.DTOs;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace client_app.OrderSection
{
    /// <summary>
    /// Сервис взаимодействия с областью Order через API
    /// </summary>
    internal class OrderService : IOrderService
    {
        private readonly HttpClient _httpClient;

        public OrderService()
        {
            _httpClient = new HttpClient();
        }

        /// <summary>
        /// Создание заказа через API
        /// </summary>
        /// <param name="userId"> Идентификатор пользователя </param>
        /// <param name="price"> Цена </param>
        /// <param name="products"> Список товаров </param>
        /// <returns></returns>
        public async Task CreateOrder(string userId, decimal price, List<ProductNameDto> products)
        {
            try
            {
                string url = "http://localhost:5117/api/order/create";

                var postData = JsonConvert.SerializeObject(new OrderDto { UserId = userId, Price = price, Products = products });

                HttpContent content = new StringContent(postData, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await _httpClient.PostAsync(url, content);
                
                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show($"Заказ успешно создан");
                }
                else
                {
                    MessageBox.Show($"Запрос завершился неудачей - {response.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Во время отправки запроса произошла ошибка{ex.Message} ");
            }
        }
    }
}


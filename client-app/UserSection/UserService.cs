using client_app.DTOs;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows;

namespace client_app.UserSection
{
    /// <summary>
    /// Сервис взаимодействия с областью User
    /// </summary>
    public class UserService : IUserService
    {
        private readonly HttpClient _httpClient;

        public UserService()
        {
            _httpClient = new HttpClient();
        }

        /// <summary>
        /// Получения списка заказов по индентификатору пользователя из API
        /// </summary>
        /// <param name="id"> Индентификатор </param>
        /// <returns> Списка заказов </returns>
        public async Task<List<ListUserOrdersDto>> GetUserOrdersListByIdAsync(string id)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string url = string.Concat("http://localhost:5117/api/user/listOrders/",id);

                    HttpResponseMessage response = await client.GetAsync(url);

                    if (response.IsSuccessStatusCode)
                    {
                        string json = await response.Content.ReadAsStringAsync();

                        List<ListUserOrdersDto> items = JsonConvert.DeserializeObject<List<ListUserOrdersDto>>(json);
                        
                        return items;
                    }
                    else
                    {
                        MessageBox.Show($"Ошибка при выполнении запроса: {response.StatusCode}");
                        return new List<ListUserOrdersDto>();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}");
                return new List<ListUserOrdersDto>();
            }
        }
    }
}

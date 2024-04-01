using client_app.DTOs;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;

namespace client_app.UserSection
{
    public class UserService : IUserService
    {
        private readonly HttpClient _httpClient;

        public UserService()
        {
            _httpClient = new HttpClient();
        }

        public async Task<List<ListUserOrdersDto>> GetUserOrdersListByIdAsync(string id)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string url = string.Concat("http://localhost:5117/api/user/listOrders/",id);

                    // Выполнить GET-запрос и получить ответ
                    HttpResponseMessage response = await client.GetAsync(url);

                    // Проверить, успешно ли выполнен запрос
                    if (response.IsSuccessStatusCode)
                    {
                        // Прочитать ответ как строку JSON
                        string json = await response.Content.ReadAsStringAsync();

                        // Десериализовать JSON в список объектов MyItem
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

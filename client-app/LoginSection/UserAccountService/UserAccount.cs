using client_app.DTOs;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace client_app.LoginSection.UserAccountService
{

    public class UserAccount : IUserAccount
    {
        private readonly HttpClient _httpClient;
        public UserAccount()
        {
            _httpClient = new HttpClient();
        }

        public async Task<string> LoginAsync(string login)
        {
            try
            {
                // URL, на который будет отправлен POST-запрос
                string url = "http://localhost:5117/api/account/login";

                // Данные для отправки (в данном примере это JSON)
                var postData = JsonConvert.SerializeObject(new LoginDto { Login = login });

                // Создание содержимого запроса
                HttpContent content = new StringContent(postData, Encoding.UTF8, "application/json");

                // Отправка POST-запроса и получение ответа
                HttpResponseMessage response = await _httpClient.PostAsync(url, content);

                // Проверка успешности запроса (HTTP статус код 200)
                if (response.IsSuccessStatusCode)
                {
                    // Чтение содержимого ответа как строки
                    string responseData = await response.Content.ReadAsStringAsync();

                    // Обработка полученных данных
                    return responseData.Substring(1, responseData.Length - 2);
                }
                else
                {
                    // Обработка случая, когда запрос завершился неудачей
                    MessageBox.Show($"Запрос завершился неудачей - {response.StatusCode}");
                    return null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Во время отправки запроса произошла ошибка{ex.Message} ");
                return null;
            }
        }
    }
}

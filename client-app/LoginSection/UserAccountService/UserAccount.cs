using client_app.DTOs;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace client_app.LoginSection.UserAccountService
{
    /// <summary>
    /// Сервис взаимодействия с областью аккаунта пользователя
    /// </summary>
    public class UserAccount : IUserAccount
    {
        private readonly HttpClient _httpClient;
        public UserAccount()
        {
            _httpClient = new HttpClient();
        }

        /// <summary>
        /// Вход пользователя в систему через API
        /// </summary>
        /// <param name="login"> email </param>
        /// <returns> Идентификатор пользователя </returns>
        public async Task<string> LoginAsync(string login)
        {
            try
            {
                string url = "http://localhost:5117/api/account/login";

                var postData = JsonConvert.SerializeObject(new LoginDto { Login = login });

                HttpContent content = new StringContent(postData, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await _httpClient.PostAsync(url, content);

                if (response.IsSuccessStatusCode)
                {
                    string responseData = await response.Content.ReadAsStringAsync();

                    return responseData.Substring(1, responseData.Length - 2);
                }
                else
                {
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

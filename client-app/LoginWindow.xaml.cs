using client_app.LoginSection.UserAccountService;
using System.Windows;

namespace client_app
{
    /// <summary>
    /// Логика взаимодействия для LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        private IUserAccount _userAccount;

        public LoginWindow()
        {
            InitializeComponent();
            _userAccount = new UserAccount();
        }

        /// <summary>
        /// Отправка логина пользователя для входа в систему
        /// </summary>
        /// <param name="sender"> Кнопка </param>
        /// <param name="e"> Нажатие </param>
        private async void LoginUserClick(object sender, RoutedEventArgs e)
        {
            string userLogin = null;
            
            if (!ValidateInputString(loginTextBox.Text))
            {
                MessageBox.Show("Введите логин в поле ниже");
            }
            else
            {
                userLogin = loginTextBox.Text;
            }

            if (userLogin != null)
            {
                var userId = await _userAccount.LoginAsync(userLogin);

                if (userId != null)
                {
                    MainWindow mainWindow = new MainWindow(userId);
                    Close();
                    mainWindow.Show();
                }
            }
            
        }

        /// <summary>
        /// Валидация логина пользователя
        /// </summary>
        /// <param name="input"> Логин </param>
        /// <returns> True или False </returns>
        private bool ValidateInputString(string input)
        {
            return string.IsNullOrEmpty(input) || input.Trim() == "" ? false : true;
        }
    }
}

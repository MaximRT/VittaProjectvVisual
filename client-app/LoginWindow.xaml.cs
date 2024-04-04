using client_app.LoginSection.UserAccountService;
using System.Windows;

namespace client_app
{
    public partial class LoginWindow : Window
    {
        private IUserAccount _userAccount;

        public LoginWindow()
        {
            InitializeComponent();
            _userAccount = new UserAccount();
        }

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

        private bool ValidateInputString(string input)
        {
            return string.IsNullOrEmpty(input) || input.Trim() == "" ? false : true;
        }
    }
}

using client_app.LoginSection.UserAccountService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

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

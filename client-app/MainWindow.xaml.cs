using client_app.UserSection;
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
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string _userId;

        private IUserService _userService;
        public MainWindow(string userId)
        {
            InitializeComponent();
            _userId = userId;
            _userService = new UserService();
        }

        private void BackToLoginWindow(object sender, RoutedEventArgs e)
        {
            LoginWindow window = new LoginWindow();
            Close();
            window.Show();
        }

        private async void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            var items = await _userService.GetUserOrdersListByIdAsync(_userId);

            dataGrid.ItemsSource = items;
        }

        private void MoveToCreateOrderWindow(object sender, RoutedEventArgs e)
        {
            CreateOrderWindow window = new CreateOrderWindow(_userId);
            Close();
            window.Show();
        }
    }
}

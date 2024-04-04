using client_app.UserSection;
using System.Windows;

namespace client_app
{
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

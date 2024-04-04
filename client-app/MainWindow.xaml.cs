using client_app.UserSection;
using System.Windows;

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

        /// <summary>
        /// Возврат на форму входа в систему
        /// </summary>
        /// <param name="sender"> Кнопка </param>
        /// <param name="e"> Нажатие </param>
        private void BackToLoginWindow(object sender, RoutedEventArgs e)
        {
            LoginWindow window = new LoginWindow();
            Close();
            window.Show();
        }

        /// <summary>
        /// Получение списка заказов пользователя
        /// </summary>
        /// <param name="sender"> DataGrid </param>
        /// <param name="e"> Загрузка формы </param>
        private async void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            var items = await _userService.GetUserOrdersListByIdAsync(_userId);

            dataGrid.ItemsSource = items;
        }

        /// <summary>
        /// Открытие окна создания заказа
        /// </summary>
        /// <param name="sender"> Кнопка </param>
        /// <param name="e"> Назатие </param>
        private void MoveToCreateOrderWindow(object sender, RoutedEventArgs e)
        {
            CreateOrderWindow window = new CreateOrderWindow(_userId);
            Close();
            window.Show();
        }
    }
}

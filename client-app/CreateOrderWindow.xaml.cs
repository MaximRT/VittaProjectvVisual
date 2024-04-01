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
    /// Логика взаимодействия для CreateOrderWindow.xaml
    /// </summary>
    public partial class CreateOrderWindow : Window
    {
        private string _userId;
        public CreateOrderWindow(string userId)
        {
            InitializeComponent();
            _userId = userId;
        }

        private void BackToMainWindow(object sender, RoutedEventArgs e)
        {
            MainWindow window = new MainWindow(_userId);
            Close();
            window.Show();
        }
    }
}

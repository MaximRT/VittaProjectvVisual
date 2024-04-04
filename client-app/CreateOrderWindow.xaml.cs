using client_app.DTOs;
using client_app.OrderSection;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace client_app
{
    /// <summary>
    /// Логика взаимодействия для CreateOrderWindow.xaml
    /// </summary>
    public partial class CreateOrderWindow : Window
    {
        private IOrderService _orderService;
        private string _userId;

        public ObservableCollection<ProductToUserDto> _products;

        public CreateOrderWindow(string userId)
        {
            InitializeComponent();
            _userId = userId;
            _products = new ObservableCollection<ProductToUserDto>();
            dataGrid.ItemsSource = _products;
            _orderService = new OrderService();
        }

        /// <summary>
        /// Закрытие окон создания заказа и добавления товаров
        /// </summary>
        /// <param name="sender"> Кнопка </param>
        /// <param name="e"> Нажатие </param>
        private void BackToMainWindow(object sender, RoutedEventArgs e)
        {
            ProductsAdditionWindow.GetInstance(_userId, _products).Close();

            MainWindow window = new MainWindow(_userId);

            Close();

            window.Show();
        }

        /// <summary>
        /// Открытие окна добавление товаров
        /// </summary>
        /// <param name="sender"> Кнопка </param>
        /// <param name="e"> Нажатие </param>
        private void MoveToProductsAdditionWindow(object sender, RoutedEventArgs e)
        {
            ProductsAdditionWindow.GetInstance(_userId, _products).Show();
        }

        /// <summary>
        /// Создание заказа в базе данных
        /// </summary>
        /// <param name="sender"> Кнопка </param>
        /// <param name="e"> Нажатие </param>
        private async void CreateOrder(object sender, RoutedEventArgs e)
        {
            decimal priceOrder = 0;

            var products = new List<ProductNameDto>();

            if(dataGrid.Items.Count > 1)
            {
                foreach (var row in dataGrid.Items)
                {
                    if (row is ProductToUserDto)
                    {
                        ProductToUserDto product = (ProductToUserDto)row;

                        priceOrder += product.Count * product.Price;

                        var positionOrder = new ProductNameDto
                        {
                            Name = product.Name,
                            Count = product.Count
                        };

                        products.Add(positionOrder);
                    }    
                }

                await _orderService.CreateOrder(_userId, priceOrder, products);

                _products.Clear();

                MessageBox.Show("Заказ успешно создан");
            }
            else
            {
                MessageBox.Show("Список товаров пуст!");
            }
        }

        /// <summary>
        /// Удаление товара из заказа
        /// </summary>
        /// <param name="sender"> Строка с товаров в DataGrid </param>
        /// <param name="e"> Нажатие правой кнопкой мыши и последующий выбор пункта "Удалить" в контекстном меню </param>
        private void Row_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Right)
            {
                DataGridRow row = sender as DataGridRow;
                row?.Focus();
                e.Handled = true;

                ContextMenu contextMenu = new ContextMenu();
                MenuItem menuItemDelete = new MenuItem();

                menuItemDelete.Header = "Удалить";

                menuItemDelete.Click += (s, args) =>
                {
                    if (row.Item is ProductToUserDto)
                    {
                        ProductToUserDto selectedProduct = (ProductToUserDto)row.Item;

                        if (selectedProduct != null)
                        {
                            _products.Remove(selectedProduct);
                        }
                    }
                };

                contextMenu.Items.Add(menuItemDelete);

                row.ContextMenu = contextMenu;
            }
        }
    }
}

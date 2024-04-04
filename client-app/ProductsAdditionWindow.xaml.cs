using client_app.DTOs;
using client_app.ProductSection;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;

namespace client_app
{
    /// <summary>
    /// Логика взаимодействия для ProductsAdditionWindow.xaml
    /// </summary>
    public partial class ProductsAdditionWindow : Window
    {
        private string _userId;

        private static ProductsAdditionWindow instance;

        private IProductService _productService;

        public ObservableCollection<ProductToUserDto> _productsInOrder;
        public ObservableCollection<ProductToUserDto> _listProducts;
        private ProductsAdditionWindow(string userId, ObservableCollection<ProductToUserDto> productsInOrder)
        {
            InitializeComponent();
            _userId = userId;
            _productService = new ProductService();
            _productsInOrder = productsInOrder;
            _listProducts = new ObservableCollection<ProductToUserDto>();
            dataGridProduct.ItemsSource = _listProducts;
        }

        /// <summary>
        /// Закрытие формы при возврате в окно создания заказа
        /// </summary>
        /// <param name="sender"> Кнопка </param>
        /// <param name="e"> Нажатие </param>
        private void BackToCreateOrderWindow(object sender, RoutedEventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Отображение списка товаров
        /// </summary>
        /// <param name="sender"> DataGrid </param>
        /// <param name="e"> Загрузка формы </param>
        private async void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            var listProducts = await _productService.GetListProducts();

            foreach (var product in listProducts)
            {
                _listProducts.Add(product);
            }
        }

        /// <summary>
        /// Добавление выделенной строки с товаром из окна ProductsAddition 
        /// в DataGrid товаров в заказе расположенной в CreateOrderWindow
        /// </summary>
        /// <param name="sender"> Кнопка </param>
        /// <param name="e"> Нажатие </param>
        private void AddProductToOrder(object sender, RoutedEventArgs e)
        {
            if (dataGridProduct.SelectedItem is ProductToUserDto selectedProduct)
            {
                var existingProduct = _productsInOrder.FirstOrDefault(x => x.Name == selectedProduct.Name);

                if (existingProduct != null)
                {
                    existingProduct.Count += selectedProduct.Count;

                    _productsInOrder.Remove(existingProduct);

                    _productsInOrder.Add(existingProduct);
                }
                else
                {
                    _productsInOrder.Add(new ProductToUserDto 
                        { 
                            Name = selectedProduct.Name, 
                            Price = selectedProduct.Price, 
                            Count = selectedProduct.Count
                        });
                }
            }
            else
            {
                MessageBox.Show("Выберите строку для добавления в массив.");
            }
        }

        /// <summary>
        /// Получение объекта ProductsAdditionWindow, чтобы окно можно было открыть только один раз
        /// </summary>
        /// <param name="userId"> Идентификатор пользователя </param>
        /// <param name="productsInOrder"> Список товаров в заказе </param>
        /// <returns> Объект ProductsAdditionWindow </returns>
        public static ProductsAdditionWindow GetInstance(string userId, ObservableCollection<ProductToUserDto> productsInOrder)
        {
            if (instance == null || instance.IsClosed)
            {
                instance = new ProductsAdditionWindow(userId, productsInOrder);
            }

            return instance;
        }

        /// <summary>
        /// Проверка статуса окна
        /// </summary>
        private bool IsClosed
        {
            get { return !IsLoaded || !IsVisible; }
        }
    }
}

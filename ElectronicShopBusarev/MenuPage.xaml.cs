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
using ElectronicShopBusarev.DatabaseContext;
using ElectronicShopBusarev.Entities;

namespace ElectronicShopBusarev
{
    /// <summary>
    /// Логика взаимодействия для MenuPage.xaml
    /// </summary>
    public partial class MenuPage : Window
    {
        public MenuPage()
        {
            InitializeComponent();
            LoadData();
        }

        private void OpenAddProductWindow(object sender, RoutedEventArgs e)
        {
            AddProductWindow addProductWindow = new AddProductWindow();
            addProductWindow.ShowDialog();
            LoadData();
        }

        private void GoToEditProductWindow(object sender, SelectionChangedEventArgs e)
        {
            ProductEntity selectedProduct = (ProductEntity)ProductLV.SelectedItem;
            if (selectedProduct == null) return;

            UpdateProductWindow editPage = new UpdateProductWindow(selectedProduct.Id);
            editPage.ShowDialog();
            LoadData();
        }


        private void LoadData()
        {
            ApplicationDbContext dbContext = new ApplicationDbContext();
            ProductLV.ItemsSource = dbContext.Products.ToList();
        }
    }
}

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
    /// Логика взаимодействия для UpdateProductWindow.xaml
    /// </summary>
    public partial class UpdateProductWindow : Window
    {
        private int productId;
        public UpdateProductWindow(int id)
        {
            InitializeComponent();
            ApplicationDbContext dbContext = new ApplicationDbContext();
            ProductEntity product = dbContext.Products.SingleOrDefault(p => p.Id == id);
            if (product == null)
            {
                MessageBox.Show("Товар с данным идентификатором не надйен!", "Error");
                Close();
                return;
            }

            productId = product.Id;
            TitleTB.Text = product.Title;
            DescriptionTB.Text = product.Description;
            AmountTB.Text = product.Amount.ToString();
        }

        private void UpdateProduct(object sender, RoutedEventArgs e)
        {
            string title = TitleTB.Text;
            string description = DescriptionTB.Text;
            string amount = AmountTB.Text;

            bool isTitleEmpty = string.IsNullOrWhiteSpace(title);
            if (isTitleEmpty)
            {
                MessageBox.Show("Заголовок не может быть пустым", "Error");
                return;
            }

            bool isDescriptionEmpty = string.IsNullOrWhiteSpace(description);
            if (isDescriptionEmpty)
            {
                MessageBox.Show("Описание не может быть пустым", "Error");
                return;
            }

            bool isAmountEmpty = string.IsNullOrWhiteSpace(amount);
            if (isTitleEmpty)
            {
                MessageBox.Show("Кол-во товара не может быть пустым", "Error");
                return;
            }

            ApplicationDbContext dbContext = new ApplicationDbContext();
            bool isTitleAlreadyExistForUpdate = dbContext.Products.Any(p => p.Title == title && p.Id != productId);
            if (isTitleAlreadyExistForUpdate)
            {
                MessageBox.Show("Товар с данным заголовком существует", "Error");
                return;
            }

            ProductEntity product = dbContext.Products.SingleOrDefault(p => p.Id == productId);
            if (product == null)
            {
                MessageBox.Show("Товар с данным идентификатором не найден", "Error");
                Close();
                return;
            }

            int amountConvertedToInteger = Convert.ToInt32(amount);

            product.Title = title;
            product.Description = description;
            product.Amount = amountConvertedToInteger;

            dbContext.Update(product);
            dbContext.SaveChanges();

            MessageBox.Show("Товар успешно обновлен!", "Complete");
            Close();
        }

        private void RemoveProduct(object sender, RoutedEventArgs e)
        {
            ApplicationDbContext dbContext = new ApplicationDbContext();
            ProductEntity product = dbContext.Products.SingleOrDefault(p => p.Id == productId);
            if (product == null)
            {
                MessageBox.Show("Товар с данным идентификатором не найден", "Error");
                Close();
                return;
            }

            dbContext.Remove(product);
            dbContext.SaveChanges();

            MessageBox.Show("Товар успешно удален!", "Complete");
            Close();
        }

        private void CloseWindow(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}

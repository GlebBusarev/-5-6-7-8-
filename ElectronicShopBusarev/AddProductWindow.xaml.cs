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

namespace ElectronicShopBusarev;

/// <summary>
/// Логика взаимодействия для AddProductWindow.xaml
/// </summary>
public partial class AddProductWindow : Window
{
    public AddProductWindow()
    {
        InitializeComponent();
    }

    private void AddProduct(object sender, RoutedEventArgs e)
    {
        string title = TitleTB.Text;
        string description = DescriptionTB.Text;
        string amount = AmountTB.Text;

        bool isTitleEmpty = string.IsNullOrWhiteSpace(title);
        if (isTitleEmpty)
        {
            MessageBox.Show("Заголовок не должен быть пустым", "Error");
            return;
        }

        bool isDescriptionEmpty = string.IsNullOrWhiteSpace(description);
        if (isDescriptionEmpty)
        {
            MessageBox.Show("Описание не должен быть пустым", "Error");
            return;
        }

        bool isAmountEmpty = string.IsNullOrWhiteSpace(amount);
        if (isAmountEmpty)
        {
            MessageBox.Show("Кол-во товара не должен быть пустым", "Error");
            return;
        }

        ApplicationDbContext dbContext = new ApplicationDbContext();

        bool isTitleAlreadyExist = dbContext.Products.Any(p => p.Title == title);
        if (isTitleAlreadyExist)
        {
            MessageBox.Show("Товар уже существует", "Error");
            return;
        }

        int amountConvertedToInteger = Convert.ToInt32(amount);
        ProductEntity product = new ProductEntity(title, description, amountConvertedToInteger);
        dbContext.Products.Add(product);
        dbContext.SaveChanges();

        MessageBox.Show("Товар успешно добавлен!", "Complete");
        Close();
    }

    private void CloseWindow(object sender, RoutedEventArgs e)
    {
        Close();
    }

}


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
    /// Логика взаимодействия для RegistrationPage.xaml
    /// </summary>
    public partial class RegistrationPage : Window
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public RegistrationPage()
        {
            InitializeComponent();
        }

        private void AddUserButton(object sender, EventArgs e)
        {
            string secondName = SecondNameEntry.Text;
            string name = NameEntry.Text;
            string login = LoginEntry.Text;
            string password = PasswordEntry.Password;

            if (string.IsNullOrWhiteSpace(secondName) && string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("Все поля должны быть заполнены!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(login) && string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Все поля должны быть заполнены!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            var user = db.Users.FirstOrDefault(u => u.Login == LoginEntry.Text && u.Password == PasswordEntry.Password);
            if (user == null)
            {
                UserEntity userEntity = new UserEntity { SecondName = secondName, Name = name, Login = login, Password = password };

                db.Users.Add(userEntity);
                db.SaveChanges();

                MessageBox.Show("Регистрация успешна!");
                this.Close();
            }

            else
            {
                MessageBox.Show("Данный пользователь уже существует");
                return;
            }


        }


        private void CloseRegistrationButton(object sender, EventArgs e)
        {
            Close();
        }



    }
}

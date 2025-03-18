using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ElectronicShopBusarev.DatabaseContext;

namespace ElectronicShopBusarev
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public MainWindow()
        {

            InitializeComponent();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            string login = Login.Text;
            string password = Password.Password;

            if (string.IsNullOrWhiteSpace(login) && string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Все поля должны быть заполнены!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            var user = db.Users.FirstOrDefault(b => b.Login == Login.Text && b.Password == Password.Password);
            if (user != null)
            {

                MessageBox.Show("Успешный вход!");
                MenuPage userWindow = new MenuPage();
                userWindow.Show();
                this.Close();

            }
            else
            {
                MessageBox.Show("Неверное имя пользователя или пароль.");
            }
        }

        private void OpenRegistrationWindow(object sender, RoutedEventArgs e)
        {
            var registrationPage = new RegistrationPage();
            registrationPage.Show();
        }

        private void OpenMenuWindow(object sender, RoutedEventArgs e)
        {
            var menuPage = new MenuPage();
            App.Current.MainWindow = menuPage;
            menuPage.Show();
            Close();
        }
    }
}
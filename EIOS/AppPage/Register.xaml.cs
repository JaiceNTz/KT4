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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace EIOS.AppPage
{
    /// <summary>
    /// Логика взаимодействия для Register.xaml
    /// </summary>
    public partial class Register : Page
    {
        public Register()
        {
            InitializeComponent();
        }
        private void PassCheck(object sender, RoutedEventArgs e)
        {
            // Проверка совпадения паролей
            if (txtConfirmPassword.Password != txtNewPassword.Password)
            {
                txtConfirmPassword.Background = Brushes.LightCoral;
                txtConfirmPassword.BorderBrush = Brushes.Red;
            }
            else
            {
                txtConfirmPassword.Background = Brushes.LightGreen;
                txtConfirmPassword.BorderBrush = Brushes.Green;
            }
        }

        private void Reg_Click(object sender, RoutedEventArgs e)
        {
            // Проверка наличия пользователя с указанным именем
            if (AppConnect.EiosDB.User.Count(x => x.Name == txtNewUsername.Text) > 0)
            {
                MessageBox.Show("Пользователь с таким Именем есть!",
                    "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            try
            {
                // Создание нового пользователя и добавление его в базу данных
                User userobj = new User()
                {
                    Login = txtNewUserlogin.Text,
                    Name = txtNewUsername.Text,
                    Password = txtNewPassword.Password,
                    IdRole = 1,
                };
                AppConnect.EiosDB.User.Add(userobj);
                AppConnect.EiosDB.SaveChanges();
                MessageBox.Show("Данные успешно добавлены!",
                    "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                // Переход на страницу входа после успешной регистрации
                this.NavigationService.Navigate(new Uri("/AppPage/LoginPage.xaml", UriKind.Relative));
            }
            catch
            {
                // Обработка ошибки при добавлении данных
                MessageBox.Show("Ошибка при добавлении данных!",
                    "Уведомление", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
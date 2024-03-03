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
    /// Логика взаимодействия для LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        public LoginPage()
        {
            InitializeComponent();
        }
        private void Login_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Поиск пользователя по логину и паролю
                var userObj = AppConnect.EiosDB.User.FirstOrDefault(X => X.Login == txtUsername.Text && X.Password == txtPassword.Password);
                if (userObj == null)
                {
                    // Если пользователь не найден, выдаем сообщение об ошибке
                    MessageBox.Show("Заполните поля пожалуйста!", "Ошибка",
                        MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    // Перенаправление в зависимости от роли пользователя
                    switch (userObj.IdRole)
                    {
                        case 1:
                            this.NavigationService.Navigate(new Uri("AppPage/ItemEios.xaml", UriKind.Relative));
                            break;
                        case 2:
                            this.NavigationService.Navigate(new Uri("AppPage/ItemEios.xaml", UriKind.Relative));
                            break;
                        default:
                            MessageBox.Show("Данные не найдены! ", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Warning);
                            break;
                    }
                }
            }
            catch (Exception Ex)
            {
                // Обработка исключения при выполнении операции входа
                MessageBox.Show("Ошибка " + Ex.Message.ToString() + "ПК ошибка!",
                    "Уведомление", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void Registr(object sender, RoutedEventArgs e)
        {
            // Переход на страницу регистрации нового пользователя
            this.NavigationService.Navigate(new Uri("AppPage/Register.xaml", UriKind.Relative));
        }
    }
}

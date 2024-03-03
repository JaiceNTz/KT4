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
    /// Логика взаимодействия для ItemEios.xaml
    /// </summary>
    public partial class ItemEios : Page
    {
        public ItemEios()
        {
            InitializeComponent();

            // Создание нового экземпляра контекста базы данных
            AppConnect.EiosDB = new EiosEntities();

            // Загрузка данных из базы данных и установка источника данных для элемента управления DataGrid
            DGridItem.ItemsSource = EiosEntities.GetContext().Item.ToList();
        }
    }
}

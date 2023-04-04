using CoffeeHouse.Windows.Director;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using CoffeeHouse.Pages.DirectorPages;
using CoffeeHouse.Pagess.DirectorPages;

namespace CoffeeHouse.Windows.CommonWindows
{
    /// <summary>
    /// Логика взаимодействия для MainChoiseWindow.xaml
    /// </summary>
    public partial class MainChoiseWindow : Window
    {
        public MainChoiseWindow()
        {
            InitializeComponent();
        }

        private void BtnClick(object sender, RoutedEventArgs e)
        {
            Button b = e.Source as Button;
            switch (b.Content)
            {
                case "Добавить новый товар":
                    DefaultDirectorWindow defaultDirectorWindow = new DefaultDirectorWindow( new AddProductPage());
                    defaultDirectorWindow.Show();
                    break;
                case "Изменить товар":
                    DefaultDirectorWindow defaultDirectorWindow2 = new DefaultDirectorWindow(new ChangeProductPage());
                    defaultDirectorWindow2.Show();
                    break;
                case "Удалить товар":
                    DefaultDirectorWindow defaultDirectorWindow3 = new DefaultDirectorWindow(new RemoveProductPage());
                    defaultDirectorWindow3.Show();
                    break;
                case "Добавить нового сотрудника":
                    DefaultDirectorWindow defaultDirectorWindow4 = new DefaultDirectorWindow(new AddManagerPage());
                    defaultDirectorWindow4.Show();
                    break;
                case "Изменить сотрудника":
                    DefaultDirectorWindow defaultDirectorWindow5 = new DefaultDirectorWindow(new ChangeManagerPage());
                    defaultDirectorWindow5.Show();
                    break;
                case "Удалить сотрудника":
                    DefaultDirectorWindow defaultDirectorWindow6 = new DefaultDirectorWindow(new RemoveManagerPage());
                    defaultDirectorWindow6.Show();
                    break;
                default:
                    break;
            }
            Close();            
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            AutorizationWindow autorizationWindow = new AutorizationWindow();
            autorizationWindow.Show();
            Close();
        }
    }
}

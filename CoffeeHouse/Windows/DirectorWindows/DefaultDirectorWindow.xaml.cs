using CoffeeHouse.Pages.CommonPages;
using CoffeeHouse.Pages.DirectorPages;
using CoffeeHouse.Pagess.DirectorPages;
using CoffeeHouse.Windows.CommonWindows;
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

namespace CoffeeHouse.Windows.Director
{
    /// <summary>
    /// Логика взаимодействия для DefaultDirectorWindow.xaml
    /// </summary>
    public partial class DefaultDirectorWindow : Window
    {
        public DefaultDirectorWindow(AddProductPage addProductPage)
        {
            InitializeComponent();
            DirectorFrame.Content = addProductPage;
        }
        public DefaultDirectorWindow(ChangeProductPage changeProductPage)
        {
            InitializeComponent();
            DirectorFrame.Content = changeProductPage;
        }
        public DefaultDirectorWindow(RemoveProductPage removeProductPage)
        {
            InitializeComponent();
            DirectorFrame.Content = removeProductPage;
        }



        public DefaultDirectorWindow(AddManagerPage addManagerPage)
        {
            InitializeComponent();
            DirectorFrame.Content = addManagerPage;
        }
        public DefaultDirectorWindow(ChangeManagerPage changeManagerPage)
        {
            InitializeComponent();
            DirectorFrame.Content = changeManagerPage;
        }
        public DefaultDirectorWindow(RemoveManagerPage removeManagerPage)
        {
            InitializeComponent();
            DirectorFrame.Content = removeManagerPage;
        }


        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            MainChoiseWindow mainChoiseWindow = new MainChoiseWindow();
            mainChoiseWindow.Show();
            Close();
        }
    }
}

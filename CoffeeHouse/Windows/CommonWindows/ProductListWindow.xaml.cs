using CoffeeHouse.ClassHelper;
using CoffeeHouse.DataBase;
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
using static CoffeeHouse.ClassHelper.EFClass;

namespace CoffeeHouse.Windows.CommonWindows
{
    /// <summary>
    /// Логика взаимодействия для ProductListWindow.xaml
    /// </summary>
    public partial class ProductListWindow : Window
    {
        public ProductListWindow()
        {
            InitializeComponent();
            GetProduct();
        }
        private void GetProduct()
        {
            List<Product> ProductList = new List<Product>();
            ProductList = EFClass.Context.Product.ToList();
            LvProductList.ItemsSource= ProductList;
        }
        private void GetProduct(string word)
        {
            List<Product> ProductList = new List<Product>();
            if ((Context.Category.ToList().Where(j => j.Title.ToLower().Contains(word.ToLower())).ToList().FirstOrDefault()) != null)
            {
                ProductList = Context.Product.ToList().Where(i => i.Title.ToLower().Contains(word.ToLower()) || i.Price.ToString().Contains(word.ToLower()) || i.IDCategory.ToString() == (Context.Category.ToList().Where(j => j.Title.ToLower().Contains(word.ToLower())).ToList().FirstOrDefault().IDCategory.ToString())).ToList();
            }
            else
            {
                ProductList = Context.Product.ToList().Where(i => i.Title.ToLower().Contains(word.ToLower()) || i.Price.ToString().Contains(word.ToLower())).ToList();
            }
            LvProductList.ItemsSource = ProductList;
        }

        private void TbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            GetProduct(TbSearch.Text);
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            AutorizationWindow autorizationWindow = new AutorizationWindow();
            autorizationWindow.Show();
            Close();
        }
    }
}

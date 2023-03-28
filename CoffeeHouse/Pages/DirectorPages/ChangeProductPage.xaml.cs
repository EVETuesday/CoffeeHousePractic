using CoffeeHouse.DataBase;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
using static CoffeeHouse.ClassHelper.EFClass;

namespace CoffeeHouse.Pagess.DirectorPages
{
    /// <summary>
    /// Логика взаимодействия для ChangeProductPage.xaml
    /// </summary>
    public partial class ChangeProductPage : Page
    {
        public ChangeProductPage()
        {
            InitializeComponent();
            GetProductList();
        }
        void GetProductList()
        {
            DgListOfProduct.ItemsSource = Context.Product.ToList();
        }
        void GetProductList(Product product)
        {
            DgListOfProduct.ItemsSource = Context.Product.ToList();
        }

        private void DgListOfProduct_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Product product = DgListOfProduct.SelectedItem as Product;
            if (product.Image!=null)
            {
                MemoryStream stream = new MemoryStream(product.Image);
                ImImage.Source = BitmapFrame.Create(stream, BitmapCreateOptions.None, BitmapCacheOption.OnLoad);
            }
            else
            {
                ImImage.Source = new BitmapImage(new Uri(@"\Resourses\Images\JpgFormat\bio_no_image.jpg"));
            }              
            
        }
    }
}
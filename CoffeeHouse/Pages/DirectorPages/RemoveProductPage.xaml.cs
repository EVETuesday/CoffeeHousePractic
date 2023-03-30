using CoffeeHouse.ClassHelper;
using CoffeeHouse.DataBase;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Contexts;
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

namespace CoffeeHouse.Pages.DirectorPages
{
    /// <summary>
    /// Логика взаимодействия для RemoveProductPage.xaml
    /// </summary>
    public partial class RemoveProductPage : Page
    {
        public RemoveProductPage()
        {
            InitializeComponent();
            GetProductList();
        }
        void GetProductList()
        {
            DgListOfProduct.ItemsSource = EFClass.Context.Product.ToList();
        }

        private void DgListOfProduct_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Product product = DgListOfProduct.SelectedItem as Product;
            if (product != null)
            {
                if (product.Image != null)
                {
                    MemoryStream stream = new MemoryStream(product.Image);
                    ImImage.Source = BitmapFrame.Create(stream, BitmapCreateOptions.None, BitmapCacheOption.OnLoad);
                }
                else
                {
                    BitmapImage bi3 = new BitmapImage();
                    bi3.BeginInit();
                    bi3.UriSource = new Uri(@"\Resourses\Images\JpgFormat\bio_no_image.jpg", UriKind.Relative);
                    bi3.EndInit();
                    ImImage.Source = bi3;
                }

            }
            else
            {
                BitmapImage bi3 = new BitmapImage();
                bi3.BeginInit();
                bi3.UriSource = new Uri(@"\Resourses\Images\JpgFormat\bio_no_image.jpg", UriKind.Relative);
                bi3.EndInit();
                ImImage.Source = bi3;
            }

        }

        private void btnRemove_Click(object sender, RoutedEventArgs e)
        {
            Product product = DgListOfProduct.SelectedItem as Product;
            ProductList productList = EFClass.Context.ProductList.ToList().Where(i=>i.IDProduct==product.IDProduct).FirstOrDefault();
            if (product != null)
            {

                try
                {
                    try
                    {
                        EFClass.Context.ProductList.Remove(productList);
                    }
                    catch { }                    
                    EFClass.Context.Product.Remove(product);
                    EFClass.Context.SaveChanges();
                    MessageBox.Show("Товар удалён");
                }
                catch
                {
                    MessageBox.Show("Ошибка, Товар не удалён");
                }
                GetProductList();
            }
        }
    }
}

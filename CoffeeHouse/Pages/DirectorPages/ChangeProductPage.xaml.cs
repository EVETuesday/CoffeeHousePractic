using CoffeeHouse.ClassHelper;
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

        private string pathPhoto = null;
        Product product22;
        public ChangeProductPage()
        {
            InitializeComponent();
            GetProductList();
        }
        void GetProductList()
        {
            DgListOfProduct.ItemsSource = Context.Product.ToList();
            DgListOfProduct.SelectedIndex = 0;

            Product product = DgListOfProduct.SelectedItem as Product; 

            cmbCategory.ItemsSource = EFClass.Context.Category.ToList();
            cmbCategory.SelectedItem = EFClass.Context.Category.ToList().Where(i=>i.IDCategory==product.IDCategory);
            cmbCategory.DisplayMemberPath = "Title";

            product22 = DgListOfProduct.SelectedItem as Product;
        }

        void GetProductList(string word)
        {
            if ((Context.Category.ToList().Where(j => j.Title.ToLower().Contains(word.ToLower())).ToList().FirstOrDefault())!=null)
            {
                DgListOfProduct.ItemsSource = Context.Product.ToList().Where(i => i.Title.ToLower().Contains(word.ToLower()) || i.Price.ToString().Contains(word.ToLower()) || i.IDCategory.ToString() == (Context.Category.ToList().Where(j => j.Title.ToLower().Contains(word.ToLower())).ToList().FirstOrDefault().IDCategory.ToString()));
            }
            else
            {
                DgListOfProduct.ItemsSource = Context.Product.ToList().Where(i => i.Title.ToLower().Contains(word.ToLower()) || i.Price.ToString().Contains(word.ToLower()));
            }
            


            DgListOfProduct.SelectedIndex = 0;

            Product product = DgListOfProduct.SelectedItem as Product;

            cmbCategory.ItemsSource = EFClass.Context.Category.ToList();
            cmbCategory.SelectedItem = EFClass.Context.Category.ToList().Where(i => i.IDCategory == product.IDCategory);
            cmbCategory.DisplayMemberPath = "Title";

            product22 = DgListOfProduct.SelectedItem as Product;
        }

        private void DgListOfProduct_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Product product = DgListOfProduct.SelectedItem as Product;
            if (product!=null)
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

                cmbCategory.SelectedIndex = product.IDCategory-1;

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

        private void BtnChooseImage_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            if (openFileDialog.ShowDialog() == true)
            {
                try
                {
                    ImImage.Source = new BitmapImage(new Uri(openFileDialog.FileName));
                    pathPhoto = openFileDialog.FileName;
                }
                catch
                {
                    MessageBox.Show("Изоображение имеет неверный формат");
                }
            }
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            Product product = DgListOfProduct.SelectedItem as Product;
            Product product2 =Context.Product.ToList().Where(i => i.Title == product22.Title).FirstOrDefault();            
            if (product22 != null)
            {
                product2.Title = product.Title;
                product2.Price = product.Price;
                product2.IDCategory = cmbCategory.SelectedIndex+1;
                if (product.ExpirationDate!=0)
                {
                    product2.ExpirationDate = product.ExpirationDate;
                }
                else if (product.ExpirationDate == 0)
                {
                    product2.ExpirationDate = null;
                }
                
                if (pathPhoto != null)
                {
                    product.Image = File.ReadAllBytes(pathPhoto);
                }
                else
                {
                    product.Image = null;
                }


                try
                {
                    Context.SaveChanges();
                    MessageBox.Show("Изменения сохранены");
                }
                catch
                {
                    MessageBox.Show("Ошибка, Изменения не сохранены");
                }
                GetProductList();
                
            }
        }

        private void TbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            GetProductList(TbSearch.Text);
        }
    }
}
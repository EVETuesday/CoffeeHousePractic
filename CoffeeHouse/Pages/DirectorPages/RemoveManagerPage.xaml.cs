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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CoffeeHouse.Pages.DirectorPages
{
    /// <summary>
    /// Логика взаимодействия для RemoveManagerPage.xaml
    /// </summary>
    public partial class RemoveManagerPage : Page
    {
        public RemoveManagerPage()
        {
            InitializeComponent();
            GetProductList();
        }
        void GetProductList()
        {
            DgListOfProduct.ItemsSource = EFClass.Context.Emploee.ToList();
        }
        void GetProductList(string word)
        {
            DgListOfProduct.ItemsSource = EFClass.Context.Emploee.ToList().Where(i => i.FullName.ToLower().Contains(word.ToLower()) || i.Phone.ToString().ToLower().Contains(word.ToLower()));
        }
        private void btnRemove_Click(object sender, RoutedEventArgs e)
        {
            Emploee emploee = DgListOfProduct.SelectedItem as Emploee;
            EmloeeWorkShift emloeeWorkShift = EFClass.Context.EmloeeWorkShift.ToList().Where(i => i.IDEmploee == emploee.IDEmploee).FirstOrDefault();
            Login login = EFClass.Context.Login.ToList().Where(i => emploee.IDLogin == i.IDLogin).FirstOrDefault();

            if (emploee != null)
            {

                try
                {
                    try
                    {
                        EFClass.Context.EmloeeWorkShift.Remove(emloeeWorkShift);
                    }
                    catch { }
                    try
                    {
                        EFClass.Context.Login.Remove(login);
                    }
                    catch { }
                    EFClass.Context.Emploee.Remove(emploee);
                    EFClass.Context.SaveChanges();
                    MessageBox.Show("Сотрудник удалён");
                }
                catch
                {
                    MessageBox.Show("Ошибка, Сотрудник не удалён");
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

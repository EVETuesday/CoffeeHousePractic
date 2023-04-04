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
using static System.Net.Mime.MediaTypeNames;

namespace CoffeeHouse.Pagess.DirectorPages
{
    /// <summary>
    /// Логика взаимодействия для ChangeManagerPage.xaml
    /// </summary>
    public partial class ChangeManagerPage : Page
    {
        Emploee emploee22;
        public ChangeManagerPage()
        {
            InitializeComponent();
            GetProductList();
        }
        void GetProductList()
        {
            DgListOfProduct.ItemsSource = EFClass.Context.Emploee.ToList();
            DgListOfProduct.SelectedIndex = 0;

            Emploee emploee = DgListOfProduct.SelectedItem as Emploee;

            cmbGender.ItemsSource = EFClass.Context.Gender.ToList();
            cmbGender.SelectedItem = EFClass.Context.Gender.ToList().Where(i => i.IDGender == emploee.IDGender);
            cmbGender.DisplayMemberPath = "Gender1";

            emploee22 = DgListOfProduct.SelectedItem as Emploee;

            Login login = EFClass.Context.Login.Where(i => i.IDLogin == emploee.IDLogin).FirstOrDefault();
            tbLogin.Text = login.Login1;
            tbPassword.Text = login.Password;
        }
        void GetProductList(string word)
        {
            DgListOfProduct.ItemsSource = EFClass.Context.Emploee.ToList().Where(i => i.FullName.ToLower().Contains(word.ToLower()) || i.Phone.ToString().Contains(word.ToLower()));
            DgListOfProduct.SelectedIndex = 0;

            try {
                Emploee emploee = DgListOfProduct.SelectedItem as Emploee;

                cmbGender.ItemsSource = EFClass.Context.Gender.ToList();
                cmbGender.SelectedItem = EFClass.Context.Gender.ToList().Where(i => i.IDGender == emploee.IDGender);
                cmbGender.DisplayMemberPath = "Gender1";

                emploee22 = DgListOfProduct.SelectedItem as Emploee;

                Login login = EFClass.Context.Login.Where(i => i.IDLogin == emploee.IDLogin).FirstOrDefault();
                tbLogin.Text = login.Login1;
                tbPassword.Text = login.Password;
            }
            catch
            {
                cmbGender.ItemsSource = EFClass.Context.Gender.ToList();
                cmbGender.SelectedIndex = 0;
                cmbGender.DisplayMemberPath = "Gender1";

                emploee22 = DgListOfProduct.SelectedItem as Emploee;

                tbLogin.Text = "";
                tbPassword.Text = "";
            }
            
        }


        private void DgListOfProduct_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Emploee emploee = DgListOfProduct.SelectedItem as Emploee;
            if (emploee != null)
            {
                cmbGender.SelectedIndex = emploee.IDGender - 1;
                dpBirthday.SelectedDate = emploee.Birthday;
                Login login = EFClass.Context.Login.Where(i => i.IDLogin == emploee.IDLogin).FirstOrDefault();
                tbLogin.Text = login.Login1;
                tbPassword.Text = login.Password;
            }

        }
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            Emploee emploee = DgListOfProduct.SelectedItem as Emploee;
            Emploee emploee2 = EFClass.Context.Emploee.ToList().Where(i => i.FullName == emploee22.FullName).FirstOrDefault();
            if (emploee22 != null)
            {
                emploee2.FullName = emploee.FullName;
                emploee2.Phone = emploee.Phone;
                emploee2.IDGender = cmbGender.SelectedIndex + 1;
                emploee2.Email = emploee.Email;
                emploee2.Birthday = dpBirthday.SelectedDate.Value;

                Login login = EFClass.Context.Login.Where(i => i.IDLogin == emploee.IDLogin).FirstOrDefault();
                login.Login1 = tbLogin.Text;
                login.Password = tbPassword.Text;


                try
                {
                    EFClass.Context.SaveChanges();
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

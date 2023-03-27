using CoffeeHouse.ClassHelper;
using CoffeeHouse.Windows.Director;
using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;
using static CoffeeHouse.ClassHelper.EFClass;

namespace CoffeeHouse.Windows.CommonWindows
{
    /// <summary>
    /// Логика взаимодействия для AutorizationWindow.xaml
    /// </summary>
    public partial class AutorizationWindow : Window
    {
        Random rnd = new Random();
        string capcha = "";
        public AutorizationWindow()
        {
            InitializeComponent();
            
            for (int i = 0; i < rnd.Next(8, 11); i++)
            {
                switch(rnd.Next(0,3))
                {
                    case 0:
                        capcha += (char)rnd.Next(65, 90);
                        break;
                    case 1:
                        capcha += (char)rnd.Next(97, 122);
                        break;
                    case 2:
                        capcha += rnd.Next(0, 9);
                        break;
                }
                
            }
            tblCapcha.Text= capcha;
        }

        private void BtnToReg_Click(object sender, RoutedEventArgs e)
        {
            RegistrationWindow registrationWindow= new RegistrationWindow();
            registrationWindow.Show();
            Close();
        }

        private void BtnGo_Click(object sender, RoutedEventArgs e)
        {
            if (tbCapcha.Text == tblCapcha.Text)
            {

                var OneGuest = EFClass.Context.Login.ToList().Where(i => i.Login1 == TbLogin.Text && i.Password == TbPassword.Password).FirstOrDefault();
                if (OneGuest != null)
                {
                    DefaultDirectorWindow defaultDirectorWindow = new DefaultDirectorWindow();
                    defaultDirectorWindow.Show();
                    Close();


                }
                else
                {
                    MessageBox.Show("Пользователь не найден");
                }
            }
            else
            {
                MessageBox.Show("Капча не верна");
            }
        }

        private void TbLogin_GotFocus(object sender, RoutedEventArgs e)
        {
            if (TbLogin.Text=="Login")
            {
                TbLogin.Text = "";
            }
        }

        private void TbLogin_LostFocus(object sender, RoutedEventArgs e)
        {
            if (TbLogin.Text == "")
            {
                TbLogin.Text = "Login";
            }
        }

        private void TbPassword_LostFocus(object sender, RoutedEventArgs e)
        {
            if (TbPassword.Password == "")
            {
                TbPassword.Password = "Password";
            }
        }

        private void TbPassword_GotFocus(object sender, RoutedEventArgs e)
        {
            if (TbPassword.Password == "Password")
            {
                TbPassword.Password = "";
            }
        }

        private void tbCapcha_GotFocus(object sender, RoutedEventArgs e)
        {
            if (tbCapcha.Text == "xyXYxYxYXyx")
            {
                tbCapcha.Text = "";
            }
        }

        private void tbCapcha_LostFocus(object sender, RoutedEventArgs e)
        {
            if (tbCapcha.Text == "")
            {
                tbCapcha.Text = "xyXYxYxYXyx";
            }
        }
    }
}

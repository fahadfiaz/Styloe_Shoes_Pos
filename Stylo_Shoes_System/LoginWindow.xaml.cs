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
using LoginVerify;
using AdminBLL;

namespace Stylo_Shoes_System
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ImageBrush ib = new ImageBrush();
            ib.ImageSource = new BitmapImage(new Uri(@"../images/log1.jpg", UriKind.Relative));
            this.mycanvas.Background = ib;
            this.ErrorBlock.Visibility = Visibility.Hidden;

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(this.UserName.Text) || String.IsNullOrWhiteSpace(this.UserName.Text) || String.IsNullOrEmpty(this.Password.Password.ToString()) || String.IsNullOrWhiteSpace(this.Password.Password.ToString()))
            {
               
                MessageBox.Show("USERNAME OR PASSWORD FIELD EMPTY");
            }
            else
            {
                string name = UserName.Text;
                string password = Password.Password.ToString();
                Console.WriteLine("Ye");
                Login ValidUser = new Login();
                ValidUser.Username = name;
                ValidUser.Password = password;
                BLL VerifyLogin = new BLL();
                int res = VerifyLogin.CheckLogin(ValidUser);
                int res2 = VerifyLogin.CheckStaff(ValidUser);
                if (res == 2)
                {
                    // MessageBox.Show("CorrectLogin");

                    AdminPanel vr = new AdminPanel();
                    vr.Show();
                    this.Hide();
                }
                else if (res2 == 4)
                {
                    UserPanel usr = new UserPanel();
                    usr.Show();
                    this.Hide();

                }
                else
                {
                    this.ErrorBlock.Visibility = Visibility.Visible;


                }
                
            }


        }

        private void UserName_GotFocus(object sender, RoutedEventArgs e)
        {
            this.ErrorBlock.Visibility = Visibility.Hidden;
        }

        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            Application.Current.Shutdown();
        }

    }
}

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
using LoginVerify;
using AdminBLL;

namespace Stylo_Shoes_System
{
    /// <summary>
    /// Interaction logic for UpdatePassword.xaml
    /// </summary>
    public partial class UpdatePassword : Window
    {
        public UpdatePassword()
        {
            InitializeComponent();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            AdminPanel ap = new AdminPanel();
            ap.Show();
            this.Hide();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(this.usr.Text) || String.IsNullOrWhiteSpace(this.usr.Text) || String.IsNullOrEmpty(this.pass.Text) || String.IsNullOrWhiteSpace(this.pass.Text) || String.IsNullOrEmpty(this.cpass.Text) || String.IsNullOrWhiteSpace(this.cpass.Text))
            {

                MessageBox.Show("Please Fill Every Field");
            }
            else
            {
                Login usr = new Login();
                usr.Username = this.usr.Text;
                usr.Password = this.pass.Text;
                string cpass = this.cpass.Text;
                
                if (this.pass.Text != cpass)
                {
                    MessageBox.Show("PASSWORD DOES NOT MATCH ");
                }
                else
                {
                    BLL brp = new BLL();
                    int res = brp.UpdatePassword(usr);
                    if (res == 1)
                    {
                        MessageBox.Show("PASSOWRD UPDATED SUCCESSFULLY");
                        this.usr.Clear();
                        this.pass.Clear();
                        this.cpass.Clear();
                    }
                    else
                    {
                        MessageBox.Show("THIS USERNAME DOES NOT EXIST");
                    }

                }


            }
        }

    }
}

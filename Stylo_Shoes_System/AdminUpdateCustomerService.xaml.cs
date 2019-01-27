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
using AdminBO;
using AdminBLL;
using System.Data;

namespace Stylo_Shoes_System
{
    /// <summary>
    /// Interaction logic for AdminUpdateCustomerService.xaml
    /// </summary>
    public partial class AdminUpdateCustomerService : Window
    {
        public AdminUpdateCustomerService()
        {
            InitializeComponent();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            AdminCustomerService swc = new AdminCustomerService();
            swc.Show();
            this.Hide();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(this.id.Text) || String.IsNullOrWhiteSpace(this.id.Text))
            {

                MessageBox.Show("PLEASE ENTER ID TO SEARCH PRODUCT");
            }
            else
            {
                string id = this.id.Text;
                BLL br = new BLL();
                int count = br.ExistSer(id);
                if (count == 0)
                {
                    MessageBox.Show("PRODUCT WITH THIS ID DOES NOT EXIST");
                    this.id.Clear();
                    this.chg.Clear();
                    this.cust.Clear();
                    this.addr.Clear();
                    this.pho.Clear();
                    this.date2.SelectedDate = null;
                    this.date3.SelectedDate = null;
                    this.date.SelectedDate = null;

                    this.price.Clear();
                    this.category.Clear();
                    this.size.Clear();
                    this.color.Clear();
                    this.brand.Clear();


                }
                else
                {
                    DataTable dp = br.ReturnServiceItem(id);
                    DataRow dr = dp.Rows[0];
                    this.price.Text = dr[1].ToString();
                    this.price.IsEnabled = false;

                    this.category.Text = dr[2].ToString();
                    this.category.IsEnabled = false;

                    this.size.Text = dr[3].ToString();
                    this.size.IsEnabled = false;

                    this.color.Text = dr[4].ToString();
                    this.color.IsEnabled = false;

                    this.brand.Text = dr[5].ToString();
                    this.brand.IsEnabled = false;

                    this.date.SelectedDate = Convert.ToDateTime(dr[9]);
                    this.date.IsEnabled = false;

                    this.cust.Text = dr[11].ToString();
                    this.cust.IsEnabled = false;

                    this.addr.Text = dr[12].ToString();
                    this.addr.IsEnabled = false;

                    this.pho.Text = dr[13].ToString();

                    this.date2.SelectedDate = Convert.ToDateTime(dr[14]);
                    this.date2.IsEnabled = false;

                    this.date3.SelectedDate = Convert.ToDateTime(dr[15]);

                    this.chg.Text = dr[16].ToString();
                    this.chg.IsEnabled = false;
                }


            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(this.id.Text) || String.IsNullOrWhiteSpace(this.id.Text) || String.IsNullOrEmpty(this.pho.Text) || String.IsNullOrWhiteSpace(this.pho.Text) || this.date3.SelectedDate == null)
            {

                MessageBox.Show("PLEASE FILL ALL FIELDS");
            }
            else
            {
                string id, phone, dater;
                id = this.id.Text;
                phone = this.pho.Text;
                dater = this.date3.SelectedDate.ToString();

                BLL newUpd = new BLL();
                int res = newUpd.UpdateSer(id, phone, dater);
                if (res == 1)
                {
                    MessageBox.Show("PRODUCT SERVICE UPDATED SUCESSFULLY");
                    this.id.Clear();
                    this.chg.Clear();
                    this.cust.Clear();
                    this.addr.Clear();
                    this.pho.Clear();
                    this.date2.SelectedDate = null;
                    this.date3.SelectedDate = null;
                    this.date.SelectedDate = null;

                    this.price.Clear();
                    this.category.Clear();
                    this.size.Clear();
                    this.color.Clear();
                    this.brand.Clear();
                }
                else
                {
                    MessageBox.Show("UNABLE TO UPDATE INFO");
                    this.id.Clear();
                    this.chg.Clear();
                    this.cust.Clear();
                    this.addr.Clear();
                    this.pho.Clear();
                    this.date2.SelectedDate = null;
                    this.date3.SelectedDate = null;
                    this.date.SelectedDate = null;

                    this.price.Clear();
                    this.category.Clear();
                    this.size.Clear();
                    this.color.Clear();
                    this.brand.Clear();

                }
            }

        }
    }
}

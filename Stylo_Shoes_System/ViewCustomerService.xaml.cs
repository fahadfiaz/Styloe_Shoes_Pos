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
using AdminBLL;
using AdminBO;
using System.Data;

namespace Stylo_Shoes_System
{
    /// <summary>
    /// Interaction logic for ViewService.xaml
    /// </summary>
    public partial class ViewService : Window
    {
        public ViewService()
        {
            InitializeComponent();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            CustomerService sc = new CustomerService();
            sc.Show();
            this.Hide();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(this.id.Text) || String.IsNullOrWhiteSpace(this.id.Text))
            {

                MessageBox.Show("PLEASE ENTER ID TO VIEW PRODUCT");
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
                    this.pho.IsEnabled = false;

                    this.date2.SelectedDate = Convert.ToDateTime(dr[14]);
                    this.date2.IsEnabled = false;

                    this.date3.SelectedDate = Convert.ToDateTime(dr[15]);
                    this.date3.IsEnabled = false;

                    this.chg.Text = dr[16].ToString();
                    this.chg.IsEnabled = false;
                }


            }
        }
    }
}

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
using System.Data;
using System.Data.SqlClient;

namespace Stylo_Shoes_System
{
    /// <summary>
    /// Interaction logic for AdminStockReport.xaml
    /// </summary>
    public partial class AdminStockReport : Window
    {
        public AdminStockReport()
        {
            InitializeComponent();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            BLL report=new BLL();
            //DataTable dtr = new DataTable();
                //dtr=report.ShowStock();
            //DataTable dr = report.ShowStock();
            this.listview.ItemsSource = report.ShowStock().DefaultView;
            
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            this.listview.ItemsSource=null;
            this.listview.Items.Clear();
            if (this.pick1.SelectedDate == null || this.pick2.SelectedDate == null)
            {
                MessageBox.Show("PLEASE SELECT DATE IN BOTH DATE FIELDS");

            }
            else
            {
                DateTime date1 = this.pick1.SelectedDate.Value;
                DateTime date2 = this.pick2.SelectedDate.Value;
                if (date2 < date1)
                {
                    MessageBox.Show("INVALID DATE SELECTED");
                }
                else
                {
                    string dates1 = date1.ToString();
                    string dates2 = date2.ToString();
                    BLL showDateReport = new BLL();
                    this.listview.ItemsSource=showDateReport.ShowDateStock(dates1, dates2).DefaultView;
                }
                

            }

        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Menu me = new Menu();
            me.Show();
            this.Hide();
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            Additem ard = new Additem();
            ard.Show();
            this.Hide();
        }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            UpdateItem ui = new UpdateItem();
            ui.Show();
            this.Hide();
        }

        private void MenuItem_Click_3(object sender, RoutedEventArgs e)
        {
            DeleteProduct dp = new DeleteProduct();
            dp.Show();
            this.Hide();
        }
    }
}

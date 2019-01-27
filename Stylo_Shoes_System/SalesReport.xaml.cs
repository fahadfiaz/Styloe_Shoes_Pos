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

namespace Stylo_Shoes_System
{
    /// <summary>
    /// Interaction logic for SalesReport.xaml
    /// </summary>
    public partial class SalesReport : Window
    {
        public SalesReport()
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
            BLL report = new BLL();
            this.listview2.ItemsSource = report.showSalesRep().DefaultView;

        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            this.listview2.ItemsSource = null;
            this.listview2.Items.Clear();
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
                    BLL showSalReport = new BLL();
                    this.listview2.ItemsSource = showSalReport.showSalrRepByTm(dates1, dates2).DefaultView;
                }


            }
        }
    }
}

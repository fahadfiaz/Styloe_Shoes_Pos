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
    /// Interaction logic for ClientServiceReport.xaml
    /// </summary>
    public partial class ClientServiceReport : Window
    {
        public ClientServiceReport()
        {
            InitializeComponent();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            ReportMenu sp = new ReportMenu();
            sp.Show();
            this.Hide();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            BLL report = new BLL();
            this.listview2.ItemsSource = report.showServiceReport().DefaultView;
            
           // var name = this.listview2.Columns[13].HeaderText;
           // MessageBox.Show(
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
                    this.listview2.ItemsSource = showSalReport.ShowDateService(dates1, dates2).DefaultView;
                }


            }
        }
    }
}

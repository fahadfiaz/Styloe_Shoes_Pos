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

namespace Stylo_Shoes_System
{
    /// <summary>
    /// Interaction logic for ReportMenu.xaml
    /// </summary>
    public partial class ReportMenu : Window
    {
        public ReportMenu()
        {
            InitializeComponent();
        }

        private void LogOut_Click(object sender, RoutedEventArgs e)
        {
            UserPanel ur = new UserPanel();
            ur.Show();
            this.Hide();
        }

        private void ManageStock_Click(object sender, RoutedEventArgs e)
        {
            ClientSalesReport src = new ClientSalesReport();
            src.Show();
            this.Hide();
        }

        private void ViewReport_Click(object sender, RoutedEventArgs e)
        {
            ClientServiceReport srr = new ClientServiceReport();
            srr.Show();
            this.Hide();
        }

        private void UpdatePass_Click(object sender, RoutedEventArgs e)
        {
            ClientStockReport srt = new ClientStockReport();
            srt.Show();
            this.Hide();
        }
    }
}

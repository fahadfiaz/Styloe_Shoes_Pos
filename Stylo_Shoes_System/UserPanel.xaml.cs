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
    /// Interaction logic for UserPanel.xaml
    /// </summary>
    public partial class UserPanel : Window
    {
        public UserPanel()
        {
            InitializeComponent();
            
        }

        private void LogOut_Click(object sender, RoutedEventArgs e)
        {
            MainWindow lgr = new MainWindow();
            lgr.Show();
            this.Hide();
            

        }

        private void UpdatePass_Click(object sender, RoutedEventArgs e)
        {
            ReportMenu sp = new ReportMenu();
            sp.Show();
            this.Hide();
        }

        private void ViewReport_Click(object sender, RoutedEventArgs e)
        {
            CustomerService cs = new CustomerService();
            cs.Show();
            this.Hide();
        }

        private void ManageStock_Click(object sender, RoutedEventArgs e)
        {
            NewSalesClient nc = new NewSalesClient();
            nc.Show();
            this.Hide();
        }
    }
}

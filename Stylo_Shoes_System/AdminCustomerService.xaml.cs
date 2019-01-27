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
    /// Interaction logic for AdminCustomerService.xaml
    /// </summary>
    public partial class AdminCustomerService : Window
    {
        public AdminCustomerService()
        {
            InitializeComponent();
        }

        private void LogOut_Click(object sender, RoutedEventArgs e)
        {
            AdminPanel adp = new AdminPanel();
            adp.Show();
            this.Hide();
        }

        

        private void ManageStock_Click(object sender, RoutedEventArgs e)
        {
            AdminNewCustomerService ns = new AdminNewCustomerService();
            ns.Show();
            this.Hide();
        }

        private void ViewReport_Click(object sender, RoutedEventArgs e)
        {
            AdminUpdateCustomerService up = new AdminUpdateCustomerService();
            up.Show();
            this.Hide();
        }

        private void UpdatePass_Click(object sender, RoutedEventArgs e)
        {
            AdminViewCustomerService nv = new AdminViewCustomerService();
            nv.Show();
            this.Hide();

        }
    }
}

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
    /// Interaction logic for CustomerService.xaml
    /// </summary>
    public partial class CustomerService : Window
    {
        public CustomerService()
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
            NewCustomerService ns = new NewCustomerService();
            ns.Show();
            this.Hide();
        }

        private void ViewReport_Click(object sender, RoutedEventArgs e)
        {
            UpdateCustomerService up = new UpdateCustomerService();
            up.Show();
            this.Hide();
        }

        private void UpdatePass_Click(object sender, RoutedEventArgs e)
        {
            ViewService nv = new ViewService();
            nv.Show();
            this.Hide();
            
        }
    }
}

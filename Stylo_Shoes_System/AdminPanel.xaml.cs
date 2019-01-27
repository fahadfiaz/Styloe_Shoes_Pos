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
    /// Interaction logic for AdminPanel.xaml
    /// </summary>
    public partial class AdminPanel : Window
    {
        public AdminPanel()
        {
            InitializeComponent();
            ImageBrush ib = new ImageBrush();
            ib.ImageSource = new BitmapImage(new Uri(@"../images/log1.jpg", UriKind.Relative));
            this.admin.Background = ib;
        }

        private void LogOut_Click(object sender, RoutedEventArgs e)
        {
            
            MainWindow mw = new MainWindow();
            mw.Show();
            this.Hide();

        }

        private void ManageStock_Click(object sender, RoutedEventArgs e)
        {
            Menu mrd = new Menu();
            mrd.Show();
            this.Hide();
        }

        private void ViewReport_Click(object sender, RoutedEventArgs e)
        {
            SalesReport srp = new SalesReport();
            srp.Show();
            this.Hide();
        }

        private void UpdatePass_Click(object sender, RoutedEventArgs e)
        {
            UpdatePassword updpass = new UpdatePassword();
            updpass.Show();
            this.Hide();
        }

        private void StafRegister_Click(object sender, RoutedEventArgs e)
        {
            StaffRegister srfg = new StaffRegister();
            srfg.Show();
            this.Hide();
        }

        private void Service_Click(object sender, RoutedEventArgs e)
        {
            AdminCustomerService sdc = new AdminCustomerService();
            sdc.Show();
            this.Hide();
        }
    }
}

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
    /// Interaction logic for Menu.xaml
    /// </summary>
    public partial class Menu : Window
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {

           
            Additem addItem = new Additem();
            addItem.Show();
            this.Hide();


            
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            AdminPanel ap = new AdminPanel();
            ap.Show();
            this.Hide();
        }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            UpdateItem upd = new UpdateItem();
            upd.Show();
            this.Hide();
        }

        private void MenuItem_Click_3(object sender, RoutedEventArgs e)
        {
            DeleteProduct dr = new DeleteProduct();
            dr.Show();
            this.Hide();
        }

        private void MenuItem_Click_4(object sender, RoutedEventArgs e)
        {
            AdminStockReport sra = new AdminStockReport();
            sra.Show();
            this.Hide();
        }
    }
}

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
namespace Stylo_Shoes_System
{
    /// <summary>
    /// Interaction logic for NewSalesClient.xaml
    /// </summary>
    public partial class NewSalesClient : Window
    {
        public NewSalesClient()
        {
            InitializeComponent();
            this.head.Visibility = Visibility.Hidden;
            this.lid.Visibility = Visibility.Hidden;
            this.ls.Visibility = Visibility.Hidden;
            this.lc.Visibility = Visibility.Hidden;
            this.lct.Visibility = Visibility.Hidden;
            this.ld.Visibility = Visibility.Hidden;
            this.ll.Visibility = Visibility.Hidden;
            this.lls.Visibility = Visibility.Hidden;
            this.lp.Visibility = Visibility.Hidden;
            this.lb.Visibility = Visibility.Hidden;
            this.tid.Visibility = Visibility.Hidden;
            this.tp.Visibility = Visibility.Hidden;
            this.tc.Visibility = Visibility.Hidden;
            this.ts.Visibility = Visibility.Hidden;
            this.tct.Visibility = Visibility.Hidden;
            this.tb.Visibility = Visibility.Hidden;
            this.td.Visibility = Visibility.Hidden;
            

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

            if (String.IsNullOrEmpty(this.id.Text) || String.IsNullOrWhiteSpace(this.id.Text))
            {

                MessageBox.Show("PLEASE ENTER ID TO SEARCH PRODUCT");

            }
            else
            {
                string id = this.id.Text;
                BLL br = new BLL();
                int count = br.SearchProduct(id);
                if (count == 0)
                {
                    MessageBox.Show("PRODUCT WITH THIS ID DOES NOT EXIST");
                    this.id.Clear();
                    this.price.Clear();
                    this.category.Clear();
                    this.size.Clear();
                    this.color.Clear();
                    this.brand.Clear();
                   
                }
                else
                {
                    BO item = br.SearchProductForUpdate(id);
                    this.price.Text = item.Price;
                    this.category.Text = item.Category;
                    this.size.Text = item.Size;
                    this.color.Text = item.Color;
                    this.brand.Text= item.Brand;
                    this.date.SelectedDate = DateTime.Today;
                }


            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            UserPanel ur = new UserPanel();
            ur.Show();
            this.Hide();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(this.id.Text) || String.IsNullOrWhiteSpace(this.id.Text) || String.IsNullOrEmpty(this.price.Text) || String.IsNullOrWhiteSpace(this.price.Text) || String.IsNullOrEmpty(this.category.Text) || String.IsNullOrWhiteSpace(this.category.Text) || String.IsNullOrEmpty(this.size.Text) || String.IsNullOrWhiteSpace(this.size.Text) || String.IsNullOrEmpty(this.color.Text) || String.IsNullOrWhiteSpace(this.color.Text) || String.IsNullOrEmpty(this.brand.Text) || String.IsNullOrWhiteSpace(this.brand.Text) || this.date.SelectedDate == null)
            {

                MessageBox.Show("PLEASE FILL EACH FIELD");

            }
            else
            {
                BO Product = new BO();
                BLL saveItem = new BLL();

                Product.Id = this.id.Text;
                Product.Price = this.price.Text;
                Product.Category = this.category.Text;
                Product.Size = this.size.Text;
                Product.Color = this.color.Text;
                Product.Brand = this.brand.Text;
                Product.Date = this.date.SelectedDate.ToString();
                int stat = saveItem.SaleProduct(Product);
                if (stat == 1)
                {
                    MessageBox.Show("PRODUCT SOLD");
                    this.id.Clear();
                    this.price.Clear();
                    this.category.Clear();
                    this.size.Clear();
                    this.color.Clear();
                    this.brand.Clear();
                    this.date.SelectedDate = null;
                    this.head.Visibility = Visibility.Hidden;
                    this.lid.Visibility = Visibility.Hidden;
                    this.ls.Visibility = Visibility.Hidden;
                    this.lc.Visibility = Visibility.Hidden;
                    this.lct.Visibility = Visibility.Hidden;
                    this.ld.Visibility = Visibility.Hidden;
                    this.ll.Visibility = Visibility.Hidden;
                    this.lls.Visibility = Visibility.Hidden;
                    this.lp.Visibility = Visibility.Hidden;
                    this.lb.Visibility = Visibility.Hidden;
                    this.tid.Visibility = Visibility.Hidden;
                    this.tp.Visibility = Visibility.Hidden;
                    this.tc.Visibility = Visibility.Hidden;
                    this.ts.Visibility = Visibility.Hidden;
                    this.tct.Visibility = Visibility.Hidden;
                    this.tb.Visibility = Visibility.Hidden;
                    this.td.Visibility = Visibility.Hidden;
            


                }


            }
        }

        private void add_Click(object sender, RoutedEventArgs e)
        {
            this.id.Clear();
            this.price.Clear();
            this.category.Clear();
            this.size.Clear();
            this.color.Clear();
            this.brand.Clear();
            this.date.SelectedDate = null;
            this.head.Visibility = Visibility.Hidden;
            this.lid.Visibility = Visibility.Hidden;
            this.ls.Visibility = Visibility.Hidden;
            this.lc.Visibility = Visibility.Hidden;
            this.lct.Visibility = Visibility.Hidden;
            this.ld.Visibility = Visibility.Hidden;
            this.ll.Visibility = Visibility.Hidden;
            this.lls.Visibility = Visibility.Hidden;
            this.lp.Visibility = Visibility.Hidden;
            this.lb.Visibility = Visibility.Hidden;
            this.tid.Visibility = Visibility.Hidden;
            this.tp.Visibility = Visibility.Hidden;
            this.tc.Visibility = Visibility.Hidden;
            this.ts.Visibility = Visibility.Hidden;
            this.tct.Visibility = Visibility.Hidden;
            this.tb.Visibility = Visibility.Hidden;
            this.td.Visibility = Visibility.Hidden;
            

        }

       

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(this.id.Text) || String.IsNullOrWhiteSpace(this.id.Text) || String.IsNullOrEmpty(this.price.Text) || String.IsNullOrWhiteSpace(this.price.Text) || String.IsNullOrEmpty(this.category.Text) || String.IsNullOrWhiteSpace(this.category.Text) || String.IsNullOrEmpty(this.size.Text) || String.IsNullOrWhiteSpace(this.size.Text) || String.IsNullOrEmpty(this.color.Text) || String.IsNullOrWhiteSpace(this.color.Text) || String.IsNullOrEmpty(this.brand.Text) || String.IsNullOrWhiteSpace(this.brand.Text) || this.date.SelectedDate == null)
            {

                MessageBox.Show("PLEASE FILL EACH FIELD");

            }
            else
            {
                this.head.Visibility = Visibility.Visible;
                this.lid.Visibility = Visibility.Visible;
                this.ls.Visibility = Visibility.Visible;
                this.lc.Visibility = Visibility.Visible;
                this.lct.Visibility = Visibility.Visible;
                this.ld.Visibility = Visibility.Visible;
                this.ll.Visibility = Visibility.Visible;
                this.lls.Visibility = Visibility.Visible;
                this.lp.Visibility = Visibility.Visible;
                this.lb.Visibility = Visibility.Visible;
                this.tid.Visibility = Visibility.Visible;
                this.tp.Visibility = Visibility.Visible;
                this.tc.Visibility = Visibility.Visible;
                this.ts.Visibility = Visibility.Visible;
                this.tct.Visibility = Visibility.Visible;
                this.tb.Visibility = Visibility.Visible;
                this.td.Visibility = Visibility.Visible;
            


                

                 this.tid.Text = this.id.Text;
                 this.tp.Text = this.price.Text;
                this.tct.Text = this.category.Text;
                this.ts.Text = this.size.Text;
                this.tc.Text = this.color.Text;
                this.tb.Text = this.brand.Text;
                this.td.Text= this.date.SelectedDate.ToString();
               

            }


        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(this.id.Text) || String.IsNullOrWhiteSpace(this.id.Text) || String.IsNullOrEmpty(this.price.Text) || String.IsNullOrWhiteSpace(this.price.Text) || String.IsNullOrEmpty(this.category.Text) || String.IsNullOrWhiteSpace(this.category.Text) || String.IsNullOrEmpty(this.size.Text) || String.IsNullOrWhiteSpace(this.size.Text) || String.IsNullOrEmpty(this.color.Text) || String.IsNullOrWhiteSpace(this.color.Text) || String.IsNullOrEmpty(this.brand.Text) || String.IsNullOrWhiteSpace(this.brand.Text) || this.date.SelectedDate == null)
            {

                MessageBox.Show("PLEASE FILL EACH FIELD");

            }
            else
            {
                BO Product1 = new BO();
                BLL saveItem1 = new BLL();

                Product1.Id = this.id.Text;
                Product1.Price = this.price.Text;
                Product1.Category = this.category.Text;
                Product1.Size = this.size.Text;
                Product1.Color = this.color.Text;
                Product1.Brand = this.brand.Text;
                Product1.Date = this.date.SelectedDate.ToString();
                saveItem1.SaveForSale(Product1);


                ClientInvoice cls = new ClientInvoice();
                cls.Show();
            }
        }

       
    }
}

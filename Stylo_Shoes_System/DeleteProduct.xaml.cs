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
    /// Interaction logic for DeleteProduct.xaml
    /// </summary>
    public partial class DeleteProduct : Window
    {
        public DeleteProduct()
        {
            InitializeComponent();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(this.id.Text) || String.IsNullOrWhiteSpace(this.id.Text))
            {

                MessageBox.Show("PLEASE ENTER ID TO DELETE PRODUCT");

            }
            else
            {
                string id = this.id.Text;
                BLL br = new BLL();
                int count1 = br.SearchProduct(id);
                if (count1 == 0)
                {
                    MessageBox.Show("PRODUCT WITH THIS ID DOES NOT EXIST");
                    this.id.Clear();
                    this.price.Clear();
                    this.category.Clear();
                    this.size.Clear();
                    this.color.Clear();
                    this.brand.Clear();
                    this.date.Clear();
                }
                else
                {
                    BO items = br.SearchProductForUpdate(id);
                    this.price.Text = items.Price;
                    this.category.Text = items.Category;
                    this.size.Text = items.Size;
                    this.color.Text = items.Color;
                    this.size.Text = items.Size;
                    this.brand.Text = items.Brand;
                    DateTime dtr = Convert.ToDateTime(items.Date);
                    string nameof = dtr.ToString("dddd");
                    int day = dtr.Day;
                    string month = dtr.ToString("MMMM");
                    int year = dtr.Year;
                    string full = nameof + " " + "," + " " + month + " " + day + " " + "," + " " + year;
                    this.date.Text = full;

                }

            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Menu mrs = new Menu();
            mrs.Show();
            this.Hide();
        }

        private void add_Click(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(this.id.Text) || String.IsNullOrWhiteSpace(this.id.Text))
            {

                MessageBox.Show("PLEASE ENTER ID TO DELETE PRODUCT");

            }
            else
            {
                string id = this.id.Text;
                BLL br = new BLL();
                int count1 = br.SearchProduct(id);
                if (count1 == 0)
                {
                    MessageBox.Show("PRODUCT WITH THIS ID DOES NOT EXIST");
                    this.id.Clear();
                    this.price.Clear();
                    this.category.Clear();
                    this.size.Clear();
                    this.color.Clear();
                    this.brand.Clear();
                    this.date.Clear();
                }
                else
                {
                    BLL del = new BLL();
                    int delete=del.deleteProduct(this.id.Text);
                    if (delete > 0)
                    {
                        MessageBox.Show("PRODUCT DELETED");
                        this.id.Clear();
                        this.price.Clear();
                        this.category.Clear();
                        this.size.Clear();
                        this.color.Clear();
                        this.brand.Clear();
                        this.date.Clear();
                    }
                }

            }

        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            Additem Adr = new Additem();
            Adr.Show();
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
            AdminStockReport srr = new AdminStockReport();
            srr.Show();
            this.Hide();
        }
    }
}

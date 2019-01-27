using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
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
    /// Interaction logic for Additem.xaml
    /// </summary>
    public partial class Additem : Window
    {
        public Additem()
        {
            InitializeComponent();
            this.cat.Items.Add("Male");
            this.cat.Items.Add("Female");
            this.size.Items.Add("30");
            this.size.Items.Add("31");
            this.size.Items.Add("32");
            this.size.Items.Add("33");
            this.size.Items.Add("34");
            this.size.Items.Add("35");
            this.size.Items.Add("36");
            this.size.Items.Add("37");
            this.size.Items.Add("38");
            Type colorsType = typeof(System.Windows.Media.Colors);
            PropertyInfo[] colorsTypePropertyInfos = colorsType.GetProperties(BindingFlags.Public | BindingFlags.Static);

            foreach (PropertyInfo colorsTypePropertyInfo in colorsTypePropertyInfos)
                this.color.Items.Add(colorsTypePropertyInfo.Name);
            this.brand.Items.Add("Bata");
            this.brand.Items.Add("Service");
            this.brand.Items.Add("Indure");
            this.brand.Items.Add("HushPuppies");
           
        }

        private void add_Click(object sender, RoutedEventArgs e)
        {

            if (String.IsNullOrEmpty(this.id.Text) || String.IsNullOrWhiteSpace(this.id.Text) || String.IsNullOrEmpty(this.price.Text) || String.IsNullOrWhiteSpace(this.price.Text) || this.cat.SelectedIndex < 0 || this.size.SelectedIndex < 0 || this.color.SelectedIndex < 0 || this.brand.SelectedIndex < 0 || this.date.SelectedDate == null)
            {

                MessageBox.Show("Please Fill Every Field");

            }
            else
            {
                
                BO Product = new BO();
                BLL saveItem = new BLL();

                Product.Id = this.id.Text;
                Product.Price= this.price.Text;
                Product.Category= this.cat.SelectedValue.ToString();
                Product.Size= this.size.SelectedValue.ToString();
                Product.Color = this.color.SelectedValue.ToString();
                Product.Brand= this.brand.SelectedValue.ToString();
                Product.Date= this.date.SelectedDate.ToString();
               // Product.Date = this.date.SelectedDate.Value.ToShortDateString();
                int status=saveItem.AddProduct(Product);
                if (status == 0)
                {
                    MessageBox.Show("PRODUCT WITH THIS ID ALREADY EXIST");
                }
                else
                {
                    MessageBox.Show("PRODUCT ADDED");
                    this.id.Clear();
                    this.price.Clear();
                    this.cat.SelectedItem = null;
                    this.size.SelectedItem = null;
                    this.color.SelectedItem=null;
                    this.brand.SelectedItem = null;
                    this.date.SelectedDate=null;
                }

            }

            
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Menu arm = new Menu();
            arm.Show();
            this.Hide();
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            UpdateItem upt = new UpdateItem();
            upt.Show();
            this.Hide();
        }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            DeleteProduct dpp = new DeleteProduct();
            dpp.Show();
            this.Hide();
        }

        private void MenuItem_Click_3(object sender, RoutedEventArgs e)
        {
            AdminStockReport sr = new AdminStockReport();
            sr.Show();
            this.Hide();
        }
    }
}

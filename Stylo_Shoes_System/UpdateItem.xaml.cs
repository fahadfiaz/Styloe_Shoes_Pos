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
using AdminBO;
using AdminBLL;
using System.Reflection;

namespace Stylo_Shoes_System
{
    /// <summary>
    /// Interaction logic for UpdateItem.xaml
    /// </summary>
    public partial class UpdateItem : Window
    {
        public UpdateItem()
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
            this.date.IsEnabled = false;
            
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Menu mrp = new Menu();
            mrp.Show();
            this.Hide();
        }


        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(this.id.Text) || String.IsNullOrWhiteSpace(this.id.Text))
            {
                MessageBox.Show("ENTER SHOES ID TO SEARCH");
               

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
                    this.cat.SelectedItem = null;
                    this.size.SelectedItem = null;
                    this.color.SelectedItem = null;
                    this.brand.SelectedItem = null;
                    this.date.SelectedDate = null;
                }
                else
                {
                    BO item = br.SearchProductForUpdate(id);
                    this.price.Text = item.Price;
                    this.cat.SelectedItem =item.Category;
                    this.size.SelectedItem = item.Size;
                    this.color.SelectedItem = item.Color;
                    this.brand.SelectedItem = item.Brand;

                    //dateTimePicker.Format = DateTimePickerFormat.Custom;
                    //dateTimePicker1.CustomFormat = "MMMM dd, yyyy - dddd";

                    //DateTime dtr = Convert.ToDateTime(item.Date);
                    //string nameof = dtr.ToString("dddd");
                    //int day = dtr.Day;
                    //string month = dtr.ToString("MMMM");
                    //int year = dtr.Year;
                    //string full = nameof +" "+","+" "+ month+" " +day+" "+","+" "+ year;
                    //String date = item.Date;
                    //string customFormattedDateTimeString = DateTime.Now.ToString("MMMM/dd/yyyy");
                   // MessageBox.Show(customFormattedDateTimeString);
                    //MessageBox.Show(full);
                    this.date.SelectedDate = Convert.ToDateTime(item.Date);
                    //this.date.SelectedDate = (DateTime)full;
                }

            }
        }

        private void add_Click(object sender, RoutedEventArgs e)
        {

            if (String.IsNullOrEmpty(this.id.Text) || String.IsNullOrWhiteSpace(this.id.Text) || String.IsNullOrEmpty(this.price.Text) || String.IsNullOrWhiteSpace(this.price.Text) || this.cat.SelectedIndex < 0 || this.size.SelectedIndex < 0 || this.color.SelectedIndex < 0 || this.brand.SelectedIndex < 0)
            {

                MessageBox.Show("Please Fill Every Field");

            }
            else
            {
                BLL br = new BLL();
                int errorCheck = br.SearchProduct(this.id.Text);
                if (errorCheck == 0)
                {
                    MessageBox.Show("PRODUCT WITH THIS ID DOES NOT EXIST");
                    this.id.Clear();
                    this.price.Clear();
                    this.cat.SelectedItem = null;
                    this.size.SelectedItem = null;
                    this.color.SelectedItem = null;
                    this.brand.SelectedItem = null;
                    this.date.SelectedDate = null;
                }
                else
                {
                    BO UpdatePR = new BO();
                    BLL Updation = new BLL();

                    UpdatePR.Id = this.id.Text;
                    UpdatePR.Price = this.price.Text;
                    UpdatePR.Category = this.cat.SelectedValue.ToString();
                    UpdatePR.Size = this.size.SelectedValue.ToString();
                    UpdatePR.Color = this.color.SelectedValue.ToString();
                    UpdatePR.Brand = this.brand.SelectedValue.ToString();
                   UpdatePR.Date = this.date.SelectedDate.ToString();
                    int added=Updation.UpdatePro(UpdatePR);
                    if (added>0)
                    {
                        MessageBox.Show("PRODUCT UPDATED");
                        this.id.Clear();
                        this.price.Clear();
                        this.cat.SelectedItem = null;
                        this.size.SelectedItem = null;
                        this.color.SelectedItem = null;
                        this.brand.SelectedItem = null;
                    }

                }
                

            }

        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            DeleteProduct dr = new DeleteProduct();
            dr.Show();
            this.Hide();

        }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            Additem at = new Additem();
            at.Show();
            this.Hide();
        }

        private void MenuItem_Click_3(object sender, RoutedEventArgs e)
        {
            AdminStockReport srp = new AdminStockReport();
            srp.Show();
            this.Hide();
        }
    }
}

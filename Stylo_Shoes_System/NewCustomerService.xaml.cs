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

namespace Stylo_Shoes_System
{
    /// <summary>
    /// Interaction logic for NewCustomerService.xaml
    /// </summary>
    public partial class NewCustomerService : Window
    {
        public NewCustomerService()
        {
            InitializeComponent();

            this.head.Visibility = Visibility.Hidden;
            this.lid.Visibility = Visibility.Hidden;
            this.ls.Visibility = Visibility.Hidden;
            this.lc.Visibility = Visibility.Hidden;
            this.lct.Visibility = Visibility.Hidden;
            this.ld.Visibility = Visibility.Hidden;
           
            this.lp.Visibility = Visibility.Hidden;
            this.lb.Visibility = Visibility.Hidden;
            this.tid.Visibility = Visibility.Hidden;
            this.tp.Visibility = Visibility.Hidden;
            this.tc.Visibility = Visibility.Hidden;
            this.ts.Visibility = Visibility.Hidden;
            this.tct.Visibility = Visibility.Hidden;
            this.tb.Visibility = Visibility.Hidden;
            this.td.Visibility = Visibility.Hidden;

            this.CU.Visibility = Visibility.Hidden;
            this.NA.Visibility = Visibility.Hidden;
            this.P.Visibility = Visibility.Hidden;
            this.PO.Visibility = Visibility.Hidden;
            this.AS.Visibility = Visibility.Hidden;
            this.AER.Visibility = Visibility.Hidden;
            this.SR.Visibility = Visibility.Hidden;
            this.LS.Visibility = Visibility.Hidden;
            this.RT.Visibility = Visibility.Hidden;
            this.LR.Visibility = Visibility.Hidden;
            this.CC.Visibility = Visibility.Hidden;
            this.LC.Visibility = Visibility.Hidden;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            CustomerService sc = new CustomerService();
            sc.Show();
            this.Hide();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(this.id.Text) || String.IsNullOrWhiteSpace(this.id.Text))
            {

                MessageBox.Show("PLEASE ENTER ID TO SEARCH PRODUCT");
            }
            else
            {
                string id = this.id.Text;
                BLL br = new BLL();
                int count = br.CheckSoldPro(id);
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
                    BO item = br.ClientProductForUpdate(id);
                    this.price.Text = item.Price;
                    this.category.Text = item.Category;
                    this.size.Text = item.Size;
                    this.color.Text = item.Color;
                    this.brand.Text = item.Brand;
                    this.date.SelectedDate = Convert.ToDateTime(item.Date);
                    this.date.IsEnabled = false;
                }


            }
            
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(this.id.Text) || String.IsNullOrWhiteSpace(this.id.Text) || String.IsNullOrEmpty(this.price.Text) || String.IsNullOrWhiteSpace(this.price.Text) || String.IsNullOrEmpty(this.category.Text) || String.IsNullOrWhiteSpace(this.category.Text) || String.IsNullOrEmpty(this.size.Text) || String.IsNullOrWhiteSpace(this.size.Text) || String.IsNullOrEmpty(this.color.Text) || String.IsNullOrWhiteSpace(this.color.Text) || String.IsNullOrEmpty(this.brand.Text) || String.IsNullOrWhiteSpace(this.brand.Text) || this.date.SelectedDate == null || this.date2.SelectedDate == null || this.date3.SelectedDate == null || String.IsNullOrEmpty(this.cust.Text) || String.IsNullOrWhiteSpace(this.cust.Text) || String.IsNullOrEmpty(this.addr.Text) || String.IsNullOrWhiteSpace(this.addr.Text) || String.IsNullOrEmpty(this.phn.Text) || String.IsNullOrWhiteSpace(this.phn.Text) || String.IsNullOrEmpty(this.chg.Text) || String.IsNullOrWhiteSpace(this.chg.Text))
            {

                MessageBox.Show("PLEASE FILL EACH FIELD");

            }
            else
            {
                BLL newService = new BLL();
                CustBo Product = new CustBo();

                Product.Id = this.id.Text;
                Product.Price = this.chg.Text;
                Product.Name = this.cust.Text;
                Product.Address = this.addr.Text;
                Product.Phone = this.phn.Text;
                Product.Service = this.date2.SelectedDate.ToString();
                Product.Ret = this.date3.SelectedDate.ToString();

                int co = newService.AddNewService(Product);
                if (co == 1)
                {
                    MessageBox.Show("PRODUCT ADDED FOR SERVICE");
                    this.id.Clear();
                    this.chg.Clear();
                    this.cust.Clear();
                    this.addr.Clear();
                    this.phn.Clear();
                    this.date2.SelectedDate = null;
                    this.date3.SelectedDate = null;
                    this.date.SelectedDate = null;

                    this.price.Clear();
                    this.category.Clear();
                    this.size.Clear();
                    this.color.Clear();
                    this.brand.Clear();
                    this.head.Visibility = Visibility.Hidden;
                    this.lid.Visibility = Visibility.Hidden;
                    this.ls.Visibility = Visibility.Hidden;
                    this.lc.Visibility = Visibility.Hidden;
                    this.lct.Visibility = Visibility.Hidden;
                    this.ld.Visibility = Visibility.Hidden;

                    this.lp.Visibility = Visibility.Hidden;
                    this.lb.Visibility = Visibility.Hidden;
                    this.tid.Visibility = Visibility.Hidden;
                    this.tp.Visibility = Visibility.Hidden;
                    this.tc.Visibility = Visibility.Hidden;
                    this.ts.Visibility = Visibility.Hidden;
                    this.tct.Visibility = Visibility.Hidden;
                    this.tb.Visibility = Visibility.Hidden;
                    this.td.Visibility = Visibility.Hidden;

                    this.CU.Visibility = Visibility.Hidden;
                    this.NA.Visibility = Visibility.Hidden;
                    this.P.Visibility = Visibility.Hidden;
                    this.PO.Visibility = Visibility.Hidden;
                    this.AS.Visibility = Visibility.Hidden;
                    this.AER.Visibility = Visibility.Hidden;
                    this.SR.Visibility = Visibility.Hidden;
                    this.LS.Visibility = Visibility.Hidden;
                    this.RT.Visibility = Visibility.Hidden;
                    this.LR.Visibility = Visibility.Hidden;
                    this.CC.Visibility = Visibility.Hidden;
                    this.LC.Visibility = Visibility.Hidden;
                }
                else
                {
                    MessageBox.Show("THIS PRODUCT DOES NOT EXIST ");
                }


            }

        }

        private void add_Click(object sender, RoutedEventArgs e)
        {
            this.id.Clear();
            this.chg.Clear();
            this.cust.Clear();
            this.addr.Clear();
            this.phn.Clear();
            this.date2.SelectedDate = null;
            this.date3.SelectedDate = null;
            this.date.SelectedDate = null;

            this.price.Clear();
            this.category.Clear();
            this.size.Clear();
            this.color.Clear();
            this.brand.Clear();
            this.head.Visibility = Visibility.Hidden;
            this.lid.Visibility = Visibility.Hidden;
            this.ls.Visibility = Visibility.Hidden;
            this.lc.Visibility = Visibility.Hidden;
            this.lct.Visibility = Visibility.Hidden;
            this.ld.Visibility = Visibility.Hidden;

            this.lp.Visibility = Visibility.Hidden;
            this.lb.Visibility = Visibility.Hidden;
            this.tid.Visibility = Visibility.Hidden;
            this.tp.Visibility = Visibility.Hidden;
            this.tc.Visibility = Visibility.Hidden;
            this.ts.Visibility = Visibility.Hidden;
            this.tct.Visibility = Visibility.Hidden;
            this.tb.Visibility = Visibility.Hidden;
            this.td.Visibility = Visibility.Hidden;

            this.CU.Visibility = Visibility.Hidden;
            this.NA.Visibility = Visibility.Hidden;
            this.P.Visibility = Visibility.Hidden;
            this.PO.Visibility = Visibility.Hidden;
            this.AS.Visibility = Visibility.Hidden;
            this.AER.Visibility = Visibility.Hidden;
            this.SR.Visibility = Visibility.Hidden;
            this.LS.Visibility = Visibility.Hidden;
            this.RT.Visibility = Visibility.Hidden;
            this.LR.Visibility = Visibility.Hidden;
            this.CC.Visibility = Visibility.Hidden;
            this.LC.Visibility = Visibility.Hidden;
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(this.id.Text) || String.IsNullOrWhiteSpace(this.id.Text) || String.IsNullOrEmpty(this.price.Text) || String.IsNullOrWhiteSpace(this.price.Text) || String.IsNullOrEmpty(this.category.Text) || String.IsNullOrWhiteSpace(this.category.Text) || String.IsNullOrEmpty(this.size.Text) || String.IsNullOrWhiteSpace(this.size.Text) || String.IsNullOrEmpty(this.color.Text) || String.IsNullOrWhiteSpace(this.color.Text) || String.IsNullOrEmpty(this.brand.Text) || String.IsNullOrWhiteSpace(this.brand.Text) || this.date.SelectedDate == null || this.date2.SelectedDate==null || this.date3.SelectedDate==null || String.IsNullOrEmpty(this.cust.Text) || String.IsNullOrWhiteSpace(this.cust.Text) || String.IsNullOrEmpty(this.phn.Text) || String.IsNullOrWhiteSpace(this.phn.Text) || String.IsNullOrEmpty(this.addr.Text) || String.IsNullOrWhiteSpace(this.addr.Text) || String.IsNullOrEmpty(this.chg.Text) || String.IsNullOrWhiteSpace(this.chg.Text))
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
               
                this.lp.Visibility = Visibility.Visible;
                this.lb.Visibility = Visibility.Visible;
                this.tid.Visibility = Visibility.Visible;
                this.tp.Visibility = Visibility.Visible;
                this.tc.Visibility = Visibility.Visible;
                this.ts.Visibility = Visibility.Visible;
                this.tct.Visibility = Visibility.Visible;
                this.tb.Visibility = Visibility.Visible;
                this.td.Visibility = Visibility.Visible;

                this.CU.Visibility = Visibility.Visible;
                this.NA.Visibility = Visibility.Visible;
                this.P.Visibility = Visibility.Visible;
                this.PO.Visibility = Visibility.Visible;
                this.AS.Visibility = Visibility.Visible;
                this.AER.Visibility = Visibility.Visible;
                this.SR.Visibility = Visibility.Visible;
                this.LS.Visibility = Visibility.Visible;
                this.RT.Visibility = Visibility.Visible;
                this.LR.Visibility = Visibility.Visible;
                this.CC.Visibility = Visibility.Visible;
                this.LC.Visibility = Visibility.Visible;

                this.tid.Text = this.id.Text;
                this.tp.Text = this.price.Text;
                this.tct.Text = this.category.Text;
                this.ts.Text = this.size.Text;
                this.tc.Text = this.color.Text;
                this.tb.Text = this.brand.Text;
                this.td.Text = this.date.SelectedDate.ToString();
                this.NA.Text = this.cust.Text;
                this.PO.Text = this.phn.Text;
                this.AER.Text = this.addr.Text;
                this.LC.Text = this.chg.Text;
                this.LS.Text = this.date2.SelectedDate.ToString();
                this.LR.Text = this.date3.SelectedDate.ToString();
               
            }
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(this.id.Text) || String.IsNullOrWhiteSpace(this.id.Text) || String.IsNullOrEmpty(this.price.Text) || String.IsNullOrWhiteSpace(this.price.Text) || String.IsNullOrEmpty(this.category.Text) || String.IsNullOrWhiteSpace(this.category.Text) || String.IsNullOrEmpty(this.size.Text) || String.IsNullOrWhiteSpace(this.size.Text) || String.IsNullOrEmpty(this.color.Text) || String.IsNullOrWhiteSpace(this.color.Text) || String.IsNullOrEmpty(this.brand.Text) || String.IsNullOrWhiteSpace(this.brand.Text) || this.date.SelectedDate == null || this.date2.SelectedDate == null || this.date3.SelectedDate == null || String.IsNullOrEmpty(this.cust.Text) || String.IsNullOrWhiteSpace(this.cust.Text) || String.IsNullOrEmpty(this.addr.Text) || String.IsNullOrWhiteSpace(this.addr.Text) || String.IsNullOrEmpty(this.phn.Text) || String.IsNullOrWhiteSpace(this.phn.Text) || String.IsNullOrEmpty(this.chg.Text) || String.IsNullOrWhiteSpace(this.chg.Text))
            {

                MessageBox.Show("PLEASE FILL EACH FIELD");

            }
            else
            {

                BO Product1 = new BO();
                CustBo Product = new CustBo();
                BLL saveItem1 = new BLL();

                Product1.Id = this.id.Text;
                Product1.Price = this.price.Text;
                Product1.Category = this.category.Text;
                Product1.Size = this.size.Text;
                Product1.Color = this.color.Text;
                Product1.Brand = this.brand.Text;
                Product1.Date = this.date.SelectedDate.ToString();

                Product.Id = this.id.Text;
                Product.Price = this.chg.Text;
                Product.Name = this.cust.Text;
                Product.Address = this.addr.Text;
                Product.Phone = this.phn.Text;
                Product.Service = this.date2.SelectedDate.ToString();
                Product.Ret = this.date3.SelectedDate.ToString();

                saveItem1.SaveForSale(Product1);

                saveItem1.saveForRep(Product);


                ServiceInvoice srv = new ServiceInvoice();
                srv.Show();
            }
        }

       
    }
}

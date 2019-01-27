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
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

namespace Stylo_Shoes_System
{
    /// <summary>
    /// Interaction logic for ServiceInvoice.xaml
    /// </summary>
    public partial class ServiceInvoice : Window
    {
        public ServiceInvoice()
        {
            InitializeComponent();



            string conString = @"Data Source=DESKTOP-QEUTNBA\SQLEXPRESS;Initial Catalog=Pos;Integrated Security=True;Persist Security Info=True;";
            SqlConnection conn = new SqlConnection(conString);
            conn.Open();
            string query = "SELECT * FROM dbo.Report1,dbo.Report2 where dbo.Report1.Id=dbo.Report2.Id";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            DataSet dts = new DataSet();
            dts.Tables.Add(dt);




            ReportDocument drs = new ReportDocument();

            drs.Load(@"L:\Net._Projects+Dbs\dotNetAssignment\dotNetAssignment\ServiceRep.rpt");
            drs.SetDataSource(dt);
            myv.ViewerCore.ReportSource = drs;









        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            BLL delItem = new BLL();
            delItem.DelSaleRep();
            delItem.delReports();

           
            this.Close();
        }
    }
}

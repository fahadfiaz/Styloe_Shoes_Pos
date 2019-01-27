using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdminDAL;
using LoginVerify;
using AdminBO;
using System.Data.SqlClient;
using System.Data;

namespace AdminBLL
{
    public class BLL
    {
        public int CheckLogin(Login lg)
        {
            DAL checker = new DAL();
            return checker.LoginVerify(lg);

        }

        public int CheckStaff(Login lg1)
        {
            DAL staff= new DAL();
            return staff.StaffVerify(lg1);
        }

        public int userRegistration(Login lg2)
        {
            DAL addUser = new DAL();
            return addUser.RegisterUser(lg2);
        }

        public int UpdatePassword(Login p)
        {
            DAL addUser = new DAL();
            return addUser.UpdatedPass(p);

        }

        public int AddProduct(BO item)
        {
            DAL pr = new DAL();
            return pr.SaveProduct(item);

        }

        public int SearchProduct(string id)
        {
            DAL sr = new DAL();
            return sr.SearchProductId(id);
        }

        public BO SearchProductForUpdate(string id)
        {
            DAL src = new DAL();
            return src.ClientUpdateSearch(id);
        }

        public int UpdatePro(BO UpdatePr)
        {
            DAL UPDT = new DAL();
            return UPDT.UpdateProduct(UpdatePr);

        }

        public int deleteProduct(string id)
        {
            DAL delPr = new DAL();
            return delPr.deleteItem(id);
        }

        public int SaleProduct(BO salep)
        {
            DAL salp=new DAL();

            return salp.SalePro(salep);

        }

        public int CheckSoldPro(string id)
        {
            DAL csp = new DAL();
            return csp.CheckSoldProduct(id);

        }

        public int AddNewService(CustBo newServ)
        {
            DAL addser = new DAL();
           return addser.AddNewService(newServ);

        }

        public int ExistSer(String id)
        {
            DAL dr = new DAL();
            return dr.CheckServiceExist(id);

        }

        public int UpdateSer(String id, String phon, String re)
        {
            DAL up = new DAL();
            return up.UpdateService(id, phon, re);
        }

        public DataTable ReturnServiceItem(String id)
        {
            DAL rs = new DAL();
            return rs.ReturnProForService(id);
        }

        public DataTable ShowStock()
        {
            DAL rep = new DAL();
            return rep.showReport();
        }

        public DataTable ShowDateStock(String date1, string date2)
        {
            DAL reportDate = new DAL();
            return reportDate.showTimeStock(date1, date2);

        }

        public DataTable ShowDateService(String date1, string date2)
        {
            DAL reportDate = new DAL();
            return reportDate.showReportServiceByTime(date1, date2);

        }

        public DataTable showSalesRep()
        {

            DAL sal = new DAL();
            return sal.showReportSale();

        }

        public DataTable showSalrRepByTm(string ds1, string ds2)
        {
            DAL sal2 = new DAL();
            return sal2.showReportSaleByTime(ds1, ds2);

        }

        public BO ClientProductForUpdate(string id)
        {
            DAL src = new DAL();
            return src.ClientUpdateSearch(id);
        }

        public DataTable showServiceReport()
        {

            DAL sal = new DAL();
            return sal.ClientService();

        }

        public void SaveForSale(BO BS)
        {
            DAL repSal = new DAL();
            repSal.SaveSaleRep(BS);

        }

        public void DelSaleRep()
        {
            DAL del = new DAL();
            del.DelReportRow();
        }

        public void saveForRep(CustBo BB)
        {
            DAL dre = new DAL();
            dre.SaveServReport(BB);
        }

        public void delReports()
        {
            DAL req = new DAL();
            req.DeleteReports();
        }

       
    }
}

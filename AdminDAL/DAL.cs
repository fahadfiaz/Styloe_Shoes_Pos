using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdminBO;
using LoginVerify;
using System.Data.SqlClient;
using System.Data;

namespace AdminDAL
{
    public class DAL
    {
        public int LoginVerify(Login lg1)
        {
                Console.WriteLine("Start");
                SqlConnection conn = Connection();
                Console.WriteLine("End");
                string sqlQuery = String.Format(@"SELECT * FROM dbo.Table_1 WHERE UserName =@User and Password=@Pass");

                SqlCommand command = new SqlCommand(sqlQuery, conn);
                SqlParameter param = new SqlParameter();
                param.ParameterName = "User";
                param.SqlDbType = System.Data.SqlDbType.VarChar;
                param.Value = lg1.Username;

                command.Parameters.Add(param);

                param = new SqlParameter();
                
                param.ParameterName = "Pass";
                param.SqlDbType = System.Data.SqlDbType.VarChar;
                param.Value = lg1.Password;

                command.Parameters.Add(param);
                SqlDataReader ans = command.ExecuteReader();
               
                if (ans.HasRows)
                {
                    conn.Close();
                    return 2;
                }
                conn.Close();
            return 1;
        }

        public int StaffVerify(Login lg2)
        {
            SqlConnection conn = Connection();
            string sqlQuery = String.Format(@"SELECT * FROM dbo.Staff WHERE UserName =@User and Password=@Pass");

            SqlCommand command = new SqlCommand(sqlQuery, conn);
            SqlParameter param = new SqlParameter();
            param.ParameterName = "User";
            param.SqlDbType = System.Data.SqlDbType.VarChar;
            param.Value = lg2.Username;

            command.Parameters.Add(param);

            param = new SqlParameter();

            param.ParameterName = "Pass";
            param.SqlDbType = System.Data.SqlDbType.VarChar;
            param.Value = lg2.Password;

            command.Parameters.Add(param);
            SqlDataReader ans = command.ExecuteReader();

            if (ans.HasRows)
            {
                conn.Close();
                return 4;
            }
            conn.Close();
            return 3;

        }

        public int SaveProduct(BO pdt)
        {
            int exist = CheckId(pdt.Id);
            if (exist == 0)
            {


                SqlConnection con = Connection();
                SqlParameter Pid = new SqlParameter("id", pdt.Id);
                SqlParameter idP = new SqlParameter("id", pdt.Id);
                SqlParameter Pprice = new SqlParameter("price", pdt.Price);
                SqlParameter PCar = new SqlParameter("category", pdt.Category);
                SqlParameter PSize = new SqlParameter("size", pdt.Size);
                SqlParameter Pcolor = new SqlParameter("color", pdt.Color);
                SqlParameter Pbrand = new SqlParameter("brand", pdt.Brand);
                SqlParameter Pdate = new SqlParameter("date", pdt.Date);
                SqlParameter status = new SqlParameter("stat", "unsold");
                SqlParameter dat = new SqlParameter("da", pdt.Date);
                string query = "INSERT INTO dbo.Product(Id,Price,Category,Size,Color,Brand,Date) VALUES(@id,@price,@category,@size,@color,@brand,@date)";
                SqlCommand cmd = new SqlCommand(query, con);

                string query2 = "INSERT INTO dbo.Status(Id,Status,Dates) VALUES(@id,@stat,@da)";
                SqlCommand cmd2 = new SqlCommand(query2, con);

                cmd.Parameters.Add(Pid);
                cmd.Parameters.Add(Pprice);
                cmd.Parameters.Add(PCar);
                cmd.Parameters.Add(PSize);
                cmd.Parameters.Add(Pcolor);
                cmd.Parameters.Add(Pbrand);
                cmd.Parameters.Add(Pdate);

                cmd2.Parameters.Add(idP);
                cmd2.Parameters.Add(status);
                cmd2.Parameters.Add(dat);

                int res = cmd.ExecuteNonQuery();
                int res2 = cmd2.ExecuteNonQuery();
                con.Close();
                return 1;
            }
            else
            {   

                return 0;
            }

        }

        public int SearchProductId(string id)
        {
            return CheckId(id);

        }

        public BO SearchForUpdate(string id)
        {
            SqlConnection cnt = Connection();
            SqlParameter idP = new SqlParameter("id", id);
            string query = "SELECT * FROM dbo.Product WHERE Id=@id";
            SqlCommand cmd = new SqlCommand(query, cnt);
            cmd.Parameters.Add(idP);
            SqlDataReader sr = cmd.ExecuteReader();
            BO updateItem = new BO();


           
                sr.Read();
                updateItem.Id = sr[0].ToString();
                updateItem.Price = sr[1].ToString();
                updateItem.Category = sr[2].ToString();
                updateItem.Size = sr[3].ToString();
                updateItem.Color = sr[4].ToString();
                updateItem.Brand = sr[5].ToString();
                updateItem.Date = sr[6].ToString();
            
                cnt.Close();
                return updateItem;
        }

        public int UpdateProduct(BO newItem)
        {
            SqlConnection cond = Connection();
            SqlParameter Pid = new SqlParameter("id", newItem.Id);
            SqlParameter Pprice = new SqlParameter("price", newItem.Price);
            SqlParameter PCar = new SqlParameter("category", newItem.Category);
            SqlParameter PSize = new SqlParameter("size", newItem.Size);
            SqlParameter Pcolor = new SqlParameter("color", newItem.Color);
            SqlParameter Pbrand = new SqlParameter("brand", newItem.Brand);
            string query = "UPDATE dbo.Product SET Price=@price,Category=@category,Size=@size,Color=@color,Brand=@brand WHERE Id=@id";
            SqlCommand cmd = new SqlCommand(query, cond);
            cmd.Parameters.Add(Pid);
            cmd.Parameters.Add(Pprice);
            cmd.Parameters.Add(PCar);
            cmd.Parameters.Add(PSize);
            cmd.Parameters.Add(Pcolor);
            cmd.Parameters.Add(Pbrand);
            
            int res = cmd.ExecuteNonQuery();
            cond.Close();
            return res;


        }

        public int deleteItem(string id)
        {
            SqlConnection conn = Connection();
            SqlParameter Pid = new SqlParameter("id", id);
            string query = "DELETE FROM dbo.Product WHERE Id=@id";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.Add(Pid);
            int count = cmd.ExecuteNonQuery();
            conn.Close();
            return count;


        }

        public DataTable showReport()
        {
            SqlConnection cnt = Connection();
            string query = "SELECT * FROM dbo.Product,dbo.Status where dbo.Product.Id=dbo.Status.Id and dbo.Status.Status='unsold'";
            SqlCommand cmd = new SqlCommand(query, cnt);
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            DataTable dt = new DataTable();
            da.Fill(dt);

            cnt.Close();
            return dt;

        }

        public DataTable showTimeStock(string dat1, string dat2)
        {
            SqlConnection cnt = Connection();
            SqlParameter Pid = new SqlParameter("dt1", dat1);
            SqlParameter Pprice = new SqlParameter("dt2", dat2);
            string query = "SELECT * FROM dbo.Product,dbo.status where dbo.Product.Date >=@dt1  and dbo.Product.Date<=@dt2 and dbo.Product.Id=dbo.Status.Id and dbo.Status.Status='unsold'";
            //string query = "SELECT * FROM dbo.Product,dbo.status where dbo.Product.Date >=@dt1  and dbo.Product.Date<=@dt2 and dbo.Status.Status='unsold'";
            SqlCommand cmd = new SqlCommand(query, cnt);
            cmd.Parameters.Add(Pid);
            cmd.Parameters.Add(Pprice);
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            DataTable dt = new DataTable();
            da.Fill(dt);
            cnt.Close();
            return dt;

        }

        public int RegisterUser(Login lg1)
        {
            int ifExist = CheckUserName(lg1.Username);
            if (ifExist == 0)
            {


                SqlConnection con = Connection();
                SqlParameter Usr = new SqlParameter("user", lg1.Username);
                SqlParameter Pass = new SqlParameter("pass",lg1.Password);
                SqlParameter Role = new SqlParameter("role", "staff");
                string query = "INSERT INTO dbo.Staff(Username,Password,Role) VALUES(@user,@pass,@role)";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.Add(Usr);
                cmd.Parameters.Add(Pass);
                cmd.Parameters.Add(Role);
                int res = cmd.ExecuteNonQuery();
                con.Close();
                return 1;
            }
            else
            {

                return 0;
            }


        }

        public int UpdatedPass(Login upd)
        {
            int pass = CheckUserName(upd.Username);
            if (pass == 1)
            {
                SqlConnection con = Connection();
                SqlParameter Usr = new SqlParameter("user", upd.Username);
                SqlParameter Pass = new SqlParameter("pass", upd.Password);
                string query = "UPDATE dbo.Staff SET Password=@pass WHERE UserName=@user";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.Add(Usr);
                cmd.Parameters.Add(Pass);
                int res = cmd.ExecuteNonQuery();
                con.Close();
                return 1;
            }
            else
            {

                return 0;
            }


        }

        public DataTable showReportSale()
        {
            SqlConnection cnt = Connection();
            string query = "SELECT * FROM dbo.Product,dbo.Status where dbo.Product.Id=dbo.Status.Id and dbo.Status.Status='sold'";
            SqlCommand cmd = new SqlCommand(query, cnt);
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            DataTable dt = new DataTable();
            da.Fill(dt);

            cnt.Close();
            return dt;

        }

        public DataTable showReportSaleByTime(string dates1, string dates2)
        {
            SqlConnection cnt = Connection();
            SqlParameter dats1 = new SqlParameter("dat1", dates1);
            SqlParameter dats2 = new SqlParameter("dat2", dates2);
            string query = "SELECT * FROM dbo.Product,dbo.status where dbo.Status.Dates >=@dat1  and dbo.Status.Dates<=@dat2 and dbo.Product.Id=dbo.Status.Id and dbo.Status.Status='sold'";
            SqlCommand cmd = new SqlCommand(query, cnt);
            cmd.Parameters.Add(dats1);
            cmd.Parameters.Add(dats2);
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            DataTable dt = new DataTable();
            da.Fill(dt);
            cnt.Close();
            return dt;

        }

        public int SalePro(BO its)
        {
            int exist = CheckId(its.Id);
            if (exist == 1)
            {


                SqlConnection con = Connection();
                SqlParameter Pid = new SqlParameter("id", its.Id);
                SqlParameter status = new SqlParameter("stat", "sold");
                SqlParameter dat = new SqlParameter("da", its.Date);
               
                string query2 = "UPDATE dbo.Status SET Status=@stat,Dates=@da WHERE Id=@id";
                SqlCommand cmd2 = new SqlCommand(query2, con);

                cmd2.Parameters.Add(Pid);
                cmd2.Parameters.Add(status);
                cmd2.Parameters.Add(dat);

                int res2 = cmd2.ExecuteNonQuery();
                con.Close();
                return 1;
            }
            else
            {

                return 0;
            }

        }

        public int CheckSoldProduct(string id)
        {
            return CheckSoldId(id);
        }

        public int AddNewService(CustBo br)
        {
            int res = CheckSoldId(br.Id);
            if (res == 1)
            {
                SqlConnection con = Connection();
                SqlParameter Pid = new SqlParameter("id", br.Id);
                SqlParameter ProductId = new SqlParameter("id", br.Id);
                SqlParameter Nam = new SqlParameter("name", br.Name);
                SqlParameter Pprice = new SqlParameter("price", br.Price);
                SqlParameter Ad = new SqlParameter("address", br.Address);
                SqlParameter pho = new SqlParameter("phone", br.Phone);
                SqlParameter Ser = new SqlParameter("service", br.Service);
                SqlParameter re = new SqlParameter("ret", br.Ret);
                SqlParameter status = new SqlParameter("stat", "service");

                string query2 = "UPDATE dbo.Status SET Status=@stat WHERE Id=@id";
                SqlCommand cmd2 = new SqlCommand(query2, con);
                cmd2.Parameters.Add(status);
                cmd2.Parameters.Add(Pid);
                int res2 = cmd2.ExecuteNonQuery();


                string query = "INSERT INTO dbo.Service(Pid,CustName,Address,Phone,Service,Retrn,Price) VALUES(@id,@name,@address,@phone,@service,@ret,@price)";
                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.Add(ProductId);
                cmd.Parameters.Add(Nam);
                cmd.Parameters.Add(Ad);
                cmd.Parameters.Add(pho);
                cmd.Parameters.Add(Ser);
                cmd.Parameters.Add(re);
                cmd.Parameters.Add(Pprice);
                int res1 = cmd.ExecuteNonQuery();
                con.Close();
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public int UpdateService(string id, string ph, string dat)
        {
            int ch = CheckService(id);
            if (ch == 1)
            {
                SqlConnection con = Connection();
                SqlParameter Ids = new SqlParameter("id",id);
                SqlParameter Pho = new SqlParameter("phone", ph);
                SqlParameter da = new SqlParameter("dat2", dat);
                string query = "UPDATE dbo.Service SET Phone=@phone,Retrn=@dat2 WHERE Pid=@id";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.Add(Ids);
                cmd.Parameters.Add(Pho);
                cmd.Parameters.Add(da);

                int res = cmd.ExecuteNonQuery();
                con.Close();
                return 1;


            }
            else
            {
                return 0;
            }
        }

        public DataTable ReturnProForService(string id)
        {
            return ReturnProduct(id);
        }

        public DataTable ClientService()
        {
            return ClientServiceReport();
        }


        public int CheckServiceExist(String id)
        {
            return CheckService(id);
        }

        public BO ClientUpdateSearch(string id)
        {
            SqlConnection cnt = Connection();
            SqlParameter idP = new SqlParameter("id", id);
            string query = "SELECT * FROM dbo.Product,dbo.Status WHERE dbo.Product.Id=@id and dbo.Product.Id=dbo.Status.Id";
            SqlCommand cmd = new SqlCommand(query, cnt);
            cmd.Parameters.Add(idP);
            SqlDataReader sr = cmd.ExecuteReader();
            BO updateItem = new BO();



            sr.Read();
            updateItem.Id = sr[0].ToString();
            updateItem.Price = sr[1].ToString();
            updateItem.Category = sr[2].ToString();
            updateItem.Size = sr[3].ToString();
            updateItem.Color = sr[4].ToString();
            updateItem.Brand = sr[5].ToString();
            updateItem.Date = sr[9].ToString();

            cnt.Close();
            return updateItem;
        }

        public DataTable showReportServiceByTime(string dates1, string dates2)
        {
            SqlConnection cnt = Connection();
            SqlParameter dats1 = new SqlParameter("dat1", dates1);
            SqlParameter dats2 = new SqlParameter("dat2", dates2);
           // string query = "SELECT * FROM dbo.Product,dbo.status where dbo.Status.Dates >=@dat1  and dbo.Status.Dates<=@dat2 and dbo.Product.Id=dbo.Status.Id and dbo.Status.Status='sold'";
            string query = "SELECT * FROM dbo.Product,dbo.Status,dbo.Service where dbo.Product.Id=dbo.Status.Id and dbo.Status.Status='service' and dbo.Product.Id=dbo.Service.Pid and dbo.Service.Service>=@dat1 and dbo.Service.Service<=@dat2";
            SqlCommand cmd = new SqlCommand(query, cnt);
            cmd.Parameters.Add(dats1);
            cmd.Parameters.Add(dats2);
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            DataTable dt = new DataTable();
            da.Fill(dt);
            cnt.Close();
            return dt;

        }

        static SqlConnection Connection()
        {
            string conString = @"Data Source=DESKTOP-QEUTNBA\SQLEXPRESS;Initial Catalog=Pos;Integrated Security=True;Persist Security Info=True;";
            SqlConnection conn = new SqlConnection(conString);
            conn.Open();
            return conn;
        }

        static int CheckId(String id)
        {
            SqlConnection cnt = Connection();
            SqlParameter idP = new SqlParameter("id", id);
           // string query = "SELECT * FROM dbo.Product WHERE Id=@id";
            string query = "SELECT * FROM dbo.Product,dbo.Status where dbo.Product.Id=dbo.Status.Id and dbo.Status.Status='unsold' and dbo.Product.Id=@id";
            SqlCommand cmd = new SqlCommand(query, cnt);
            cmd.Parameters.Add(idP);
            SqlDataReader sr = cmd.ExecuteReader();

            if (sr.HasRows)
            {
                cnt.Close();
                return 1;
            }
            cnt.Close();
            return 0;
        }

        static int CheckSoldId(String id)
        {
            SqlConnection cnt = Connection();
            SqlParameter idP = new SqlParameter("id", id);
            // string query = "SELECT * FROM dbo.Product WHERE Id=@id";
            string query = "SELECT * FROM dbo.Product,dbo.Status where dbo.Product.Id=dbo.Status.Id and dbo.Status.Status='sold' and dbo.Product.Id=@id";
            SqlCommand cmd = new SqlCommand(query, cnt);
            cmd.Parameters.Add(idP);
            SqlDataReader sr = cmd.ExecuteReader();

            if (sr.HasRows)
            {
                cnt.Close();
                return 1;
            }
            cnt.Close();
            return 0;

        }

        static int CheckUserName(String UserName)
        {
            SqlConnection cnt = Connection();
            SqlParameter idP = new SqlParameter("Name", UserName);
            string query = "SELECT * FROM dbo.Staff WHERE UserName=@Name";
            SqlCommand cmd = new SqlCommand(query, cnt);
            cmd.Parameters.Add(idP);
            SqlDataReader sr = cmd.ExecuteReader();

            if (sr.HasRows)
            {
                cnt.Close();
                return 1;
            }
            cnt.Close();
            return 0;
        }

        static int CheckService(String id)
        {
            SqlConnection cnt = Connection();
            SqlParameter idP = new SqlParameter("id", id);
            // string query = "SELECT * FROM dbo.Product WHERE Id=@id";
            string query = "SELECT * FROM dbo.Status where dbo.Status.Status='service' and dbo.Status.Id=@id";
            SqlCommand cmd = new SqlCommand(query, cnt);
            cmd.Parameters.Add(idP);
            SqlDataReader sr = cmd.ExecuteReader();

            if (sr.HasRows)
            {
                cnt.Close();
                return 1;
            }
            cnt.Close();
            return 0;

        }

        static DataTable ReturnProduct(string id)
        {
            SqlConnection cnt = Connection();
            SqlParameter idP = new SqlParameter("id", id);
            string query = "SELECT * FROM dbo.Product,dbo.Status,dbo.Service where dbo.Product.Id=dbo.Status.Id and dbo.Status.Status='service' and dbo.Product.Id=@id and dbo.Service.Pid=@id";
            SqlCommand cmd = new SqlCommand(query, cnt);
            cmd.Parameters.Add(idP);
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            DataTable dt = new DataTable();
            da.Fill(dt);

            cnt.Close();
            return dt;      
        }

        static DataTable ClientServiceReport()
        {
            SqlConnection cnt = Connection();
            
            string query = "SELECT * FROM dbo.Product,dbo.Status,dbo.Service where dbo.Product.Id=dbo.Status.Id and dbo.Status.Status='service' and dbo.Product.Id=dbo.Service.Pid";
            SqlCommand cmd = new SqlCommand(query, cnt);
           
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            DataTable dt = new DataTable();
            da.Fill(dt);

            cnt.Close();
            return dt;
        }

        public void SaveSaleRep(BO pdt)
        {
            SqlConnection con = Connection();
            SqlParameter Pid = new SqlParameter("id", pdt.Id);
            SqlParameter Pprice = new SqlParameter("price", pdt.Price);
            SqlParameter PCar = new SqlParameter("category", pdt.Category);
            SqlParameter PSize = new SqlParameter("size", pdt.Size);
            SqlParameter Pcolor = new SqlParameter("color", pdt.Color);
            SqlParameter Pbrand = new SqlParameter("brand", pdt.Brand);
            SqlParameter Pdate = new SqlParameter("date", pdt.Date);
           string query = "INSERT INTO dbo.Report1(Id,Price,Category,Size,Color,Brand,Date) VALUES(@id,@price,@category,@size,@color,@brand,@date)";
            SqlCommand cmd = new SqlCommand(query, con);   
            cmd.Parameters.Add(Pid);
            cmd.Parameters.Add(Pprice);
            cmd.Parameters.Add(PCar);
            cmd.Parameters.Add(PSize);
            cmd.Parameters.Add(Pcolor);
            cmd.Parameters.Add(Pbrand);
            cmd.Parameters.Add(Pdate);
            int res = cmd.ExecuteNonQuery();
            con.Close();

        }

        public void DelReportRow()
        {
            SqlConnection conn = Connection();
            string query = "DELETE FROM dbo.Report1";
            SqlCommand cmd = new SqlCommand(query, conn);
            int count = cmd.ExecuteNonQuery();
            conn.Close();
        }

        public void SaveServReport(CustBo br)
        {
            SqlConnection con = Connection();
           
            SqlParameter ProductId = new SqlParameter("id", br.Id);
            SqlParameter Nam = new SqlParameter("name", br.Name);
            SqlParameter Pprice = new SqlParameter("price", br.Price);
            SqlParameter Ad = new SqlParameter("address", br.Address);
            SqlParameter pho = new SqlParameter("phone", br.Phone);
            SqlParameter Ser = new SqlParameter("service", br.Service);
            SqlParameter re = new SqlParameter("ret", br.Ret);
           

            
            string query = "INSERT INTO dbo.Report2(Id,CustName,Address,Phone,Service,Retrn,Price) VALUES(@id,@name,@address,@phone,@service,@ret,@price)";
            SqlCommand cmd = new SqlCommand(query, con);

            cmd.Parameters.Add(ProductId);
            cmd.Parameters.Add(Nam);
            cmd.Parameters.Add(Ad);
            cmd.Parameters.Add(pho);
            cmd.Parameters.Add(Ser);
            cmd.Parameters.Add(re);
            cmd.Parameters.Add(Pprice);
            int res1 = cmd.ExecuteNonQuery();
            con.Close();
            

        }

        public void DeleteReports()
        {
            SqlConnection conn = Connection();
            string query = "DELETE FROM dbo.Report2";
            SqlCommand cmd = new SqlCommand(query, conn);
            int count = cmd.ExecuteNonQuery();
            conn.Close();

        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DbhandlerBo
{
    public class Class1
    {


        static SqlConnection Connection()
        {
            string conString = @"Data Source=FAHAD-PC;Initial Catalog=Pos;Integrated Security=True;Persist Security Info=True;";
            SqlConnection conn = new SqlConnection(conString);
            conn.Open();
            return conn;
        }
    }
}

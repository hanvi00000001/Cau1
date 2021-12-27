using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Cau1.DAL
{
    public class DBConnection
    {

        public DBConnection() { }
        public SqlConnection CreateConnection()
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = @"Data Source=DESKTOP-VKINOHI\SQLEXPRESS;Initial Catalog=QLBH;Integrated Security=True; User id=sa; Password=000 ";
            return conn;
        }
    }
}
 
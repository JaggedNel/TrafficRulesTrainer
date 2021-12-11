using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace WcfService1 {
    class DBSQLServerUtils {
        public static SqlConnection
                 GetDBConnection(string datasource, string database, string username, string password) {
            //
            // Data Source=TRAN-VMWARE\SQLEXPRESS;Initial Catalog=simplehr;Persist Security Info=True;User ID=sa;Password=12345
            //Server=myServerAddress;Database=myDataBase;User Id=myUsername;Password=myPassword;
            string connString = $"Server={datasource};Database={database};User Id={username};Password={password};";
            SqlConnection conn = new SqlConnection(connString);
            return conn;
        }
    }
}
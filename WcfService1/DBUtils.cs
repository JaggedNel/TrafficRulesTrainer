using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace WcfService1 {
    class DBUtils {
        // Data Source=118PC0025\SQLEXPRESS;Initial Catalog=TraficRulesBD;Integrated Security=True
        public static SqlConnection GetDBConnection() {
            string datasource = @"118PC0025\SQLEXPRESS";
            string database = "TraficRulesBD";
            string username = "TrainerService";
            string password = "P@ssw0rd";
            return DBSQLServerUtils.GetDBConnection(datasource, database, username, password);
        }
    }
}

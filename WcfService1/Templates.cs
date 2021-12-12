using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WcfService1 {
	public class Templates {


		//public void templateDo() {
		//	bool success = true;
		//	using (SqlConnection conn = DBUtils.GetDBConnection()) {
		//		try {
		//			conn.Open();

		//			string sql = "";

		//			SqlCommand cmd = new SqlCommand(sql, conn);

		//			int rowCount = cmd.ExecuteNonQuery();
		//		} catch (Exception e) {
		//			Log("Error: " + e.Message);
		//			success &= false;
		//		} finally {
		//			if (conn.State == System.Data.ConnectionState.Open)
		//				conn.Close();
		//		}
		//	}
		//	//return success;
		//}

		//public void templateRead() {
		//	bool success = true;
		//	using (SqlConnection conn = DBUtils.GetDBConnection()) {
		//		try {
		//			conn.Open();

		//			string sql = "";

		//			SqlCommand cmd = new SqlCommand(sql, conn);

		//			using (DbDataReader reader = cmd.ExecuteReader()) {
		//				if (reader.HasRows) {
		//					while (reader.Read()) {
		//						//индекс столбца
		//						int empId = reader.GetOrdinal("EmpId");
		//						string empName = reader.GetString(empId).ToString();

		//						if (!reader.IsDBNull(1)) { }
		//					}
		//				}
		//			}
		//		} catch (Exception e) {
		//			Log("Error: " + e.Message);
		//			success &= false;
		//		} finally {
		//			if (conn.State == System.Data.ConnectionState.Open)
		//				conn.Close();
		//		}
		//	}
		//	//return success;
		//}
	}
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
namespace QuanLyNS
{
	public class DataConections
	{
		string Strcon = @"Data Source=DESKTOP-4IRSTF4;Initial Catalog=QuanLyNhanSu1;Integrated Security=True";
 		public SqlConnection conn = null;
		public void OpenConnection()
		{
			if (conn == null) // kiểm tra có kết nối chưa..chưa kết nối thì sẽ khởi tạo kết nối
				conn = new SqlConnection(Strcon);
			if (conn.State == ConnectionState.Closed)
				conn.Open();
		}
		public void CloseConnection()
		{
			if (conn != null && conn.State == ConnectionState.Open)
				conn.Close();
		}
	}
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyNS
{
    public partial class frmNhanVien : Form
    {
        public frmNhanVien()
        {
            InitializeComponent();
			// Nhân Viên
			ShowDataNV();
			cbPhongBan();
			cbTrinhDo();

			// Trình Độ Học Vấn
			ShowDataTD();
		}
		DataConnection dt = new DataConnection();
		bool check = true;
		List<string> LstMaNV = new List<string>();
		List<string> LstMaTD = new List<string>();
		#region ShowDataNhanVien
		public void ShowDataNV()
		{
			btnThem.Enabled = true;
			btnRs.Enabled = true;
			btnSua.Enabled = false;
			btnXoa.Enabled = false;
			dt.OpenConnection();
			SqlCommand cmd = new SqlCommand();
			cmd.CommandType = CommandType.Text;
			cmd.CommandText = "select * from NHANVIEN";
			cmd.Connection = dt.conn;

			SqlDataReader reader = cmd.ExecuteReader();

			while (reader.Read())
			{
				string MaNV = reader.GetString(0);
 				ListViewItem liv = new ListViewItem(reader.GetString(0));
				liv.SubItems.Add(reader.GetString(1));
				liv.SubItems.Add(reader.GetString(2));
				liv.SubItems.Add(reader.GetString(3));
				liv.SubItems.Add(reader.GetString(4));
				liv.SubItems.Add(reader.GetDateTime(5).ToString());
				liv.SubItems.Add(reader.GetString(6));
				liv.SubItems.Add(reader.GetString(7));

				LstMaNV.Add(MaNV);
				lvNhanVien.Items.Add(liv);
			}
			reader.Close();
		}
		string matd = "";
		public void cbTrinhDo()
		{
			dt.OpenConnection();
			SqlCommand cmd = new SqlCommand();
			cmd.CommandType = CommandType.Text;
			cmd.CommandText = "select * from TRINHDOHOCVAN";
			cmd.Connection = dt.conn;

			SqlDataReader reader = cmd.ExecuteReader();
			cbbHV.Items.Clear();
			while (reader.Read())
			{
				 matd = reader.GetString(0);
				string tentd = reader.GetString(1);
				cbbHV.Items.Add(matd + "- " + tentd);
			}
			reader.Close();
		}
		string mapb = "";
		public void cbPhongBan()
		{
			dt.OpenConnection();
			SqlCommand cmd = new SqlCommand();
			cmd.CommandType = CommandType.Text;
			cmd.CommandText = "select * from PHONGBAN";
			cmd.Connection = dt.conn;

			SqlDataReader reader = cmd.ExecuteReader();
			cbbPB.Items.Clear();
			while (reader.Read())
			{
				 mapb = reader.GetString(0);
				string tenpb = reader.GetString(1);

				cbbPB.Items.Add(mapb + "-"+ tenpb);
			}
			reader.Close();
		}
		#endregion
		

		// Trình Độ học vấn
		#region ShowDataTrinhDo
		public void ShowDataTD()
		{
			btnThemtd.Enabled = true;
			btnRstd.Enabled = true;
			btnXoatd.Enabled = false;
			btnSuatd.Enabled = false;
			dt.OpenConnection();
			SqlCommand cmd = new SqlCommand();
			cmd.CommandType = CommandType.Text;
			cmd.CommandText = "select * from TRINHDOHOCVAN";
			cmd.Connection = dt.conn;

			SqlDataReader reader = cmd.ExecuteReader();

			while (reader.Read())
			{
				string MaTD = reader.GetString(0);
				ListViewItem liv = new ListViewItem(reader.GetString(0));
				liv.SubItems.Add(reader.GetString(1));
				liv.SubItems.Add(reader.GetString(2));
				 
				LstMaTD.Add(MaTD);
				lvTrinhDo.Items.Add(liv);
			}
			reader.Close();
		}
		#endregion
		


	}
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace QuanLyNS
{
    public partial class frmNhanVien : Form
    {
        public frmNhanVien()
        {
            InitializeComponent();
			ShowDataNV();
			cbPhongBan();
			cbTrinhDo();
			ShowDataCV();
			ShowDataTD();

		}
		DataConections dt = new DataConections();
		bool check = true;
		List<string> LstMaNV = new List<string>();
		List<string> LstMaTD = new List<string>();
		//Nhân Viên
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

				cbbPB.Items.Add(mapb + "-" + tenpb);
			}
			reader.Close();
		}
		#endregion
		#region Controllrer
		private void btnThem_Click(object sender, EventArgs e)
		{
			foreach (string us in LstMaNV)
			{
				if (us.Contains(txbMaNV.Text))
				{
					MessageBox.Show("Mã nhân viên đã tồn tại !");
					check = false;
					break;
				}
				check = true;
			}
			if (check == true)
			{
				ListViewItem liv = new ListViewItem(txbMaNV.Text);
				liv.SubItems.Add(txbTen.Text);
				if (rdbNam.Checked == true)
				{
					liv.SubItems.Add(rdbNam.Text);
				}
				else
				{
					liv.SubItems.Add(rdbNu.Text);
				}
				liv.SubItems.Add(txbSDT.Text);
				liv.SubItems.Add(txbQueQuan.Text);
				liv.SubItems.Add(dtNS.Text);
				liv.SubItems.Add(cbbHV.Text);
				liv.SubItems.Add(cbbPB.Text);

				lvNhanVien.Items.Add(liv);

			}
			AddNVToDatabase();
			MessageBox.Show("Thêm Nhân Viên tha`nh công!");
		}
		#endregion
		#region Database
		public void AddNVToDatabase()
		{
			dt.OpenConnection();
			SqlCommand cmd = new SqlCommand();
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "ThemNV";
			cmd.Connection = dt.conn;

			cmd.Parameters.Add("@MaNV", SqlDbType.NVarChar).Value = txbMaNV.Text;
			cmd.Parameters.Add("@HoTen", SqlDbType.NVarChar).Value = txbTen.Text;
			if (rdbNam.Checked == true)
			{
				cmd.Parameters.Add("@GioiTinh", SqlDbType.NVarChar).Value = rdbNam.Text;
			}
			else
			{
				cmd.Parameters.Add("@GioiTinh", SqlDbType.NVarChar).Value = rdbNu.Text;
			}
			cmd.Parameters.Add("@NgaySinh", SqlDbType.Date).Value = dtNS.Value;
			cmd.Parameters.Add("@QueQuan", SqlDbType.NVarChar).Value = txbQueQuan.Text;
			cmd.Parameters.Add("@MaTDHV", SqlDbType.VarChar).Value = matd;
			cmd.Parameters.Add("@MaPB", SqlDbType.VarChar).Value = mapb;
			cmd.Parameters.Add("@SDT ", SqlDbType.NChar).Value = txbSDT.Text;
			int ret = cmd.ExecuteNonQuery();
			lvNhanVien.Items.Clear();
			if (ret > 0)
				ShowDataNV();
		}
		#endregion



		//Trình Độ học vấn
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
		#region Controller
		private void btnThemtd_Click(object sender, EventArgs e)
		{
			foreach (string us in LstMaTD)
			{
				if (us.Contains(txbMatd.Text))
				{
					MessageBox.Show("Mã đã tồn tại!");
					check = false;
					break;
				}
				check = true;
			}
			if (check == true)
			{
				ListViewItem liv = new ListViewItem(txbMatd.Text);
				liv.SubItems.Add(txbTentd.Text);
				liv.SubItems.Add(txbCN.Text);

				lvTrinhDo.Items.Add(liv);

			}
			AddTDToDatabase();
			MessageBox.Show("Thêm thành công!");

		}
		#endregion
		#region Database
		public void AddTDToDatabase()
		{
			dt.OpenConnection();
			SqlCommand cmd = new SqlCommand();
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "ThemTD";
			cmd.Connection = dt.conn;
			cmd.Parameters.Add("@MaTDHV", SqlDbType.NVarChar).Value = txbMatd.Text;
			cmd.Parameters.Add("@TenTrinhDo", SqlDbType.NVarChar).Value = txbTentd.Text;
			cmd.Parameters.Add("@ChuyenNganh ", SqlDbType.NChar).Value = txbCN.Text;
			int ret = cmd.ExecuteNonQuery();
			lvNhanVien.Items.Clear();
			if (ret > 0)
				ShowDataTD();
		}
		#endregion
		//Chức vụ
		#region ShowDataCV

		List<string> list = new List<string>();
        public void ShowDataCV()
        {
            dt.OpenConnection();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from CHUCVU";
            cmd.Connection = dt.conn;

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                string mahs = reader.GetString(0);
                ListViewItem liv = new ListViewItem(reader.GetString(0));
                liv.SubItems.Add(reader.GetString(1));
                list.Add(mahs);
                lvCV.Items.Add(liv);
            }
            reader.Close();
        }
        #endregion
        private void lvCV_SelectedIndexChanged(object sender, EventArgs e)
        {
            txbMaCV.Enabled = false;
            btnThemCV.Enabled = false;
            btnSuaCV.Enabled = true;
            if (lvCV.SelectedItems.Count == 0) return;
            ListViewItem listview = lvCV.SelectedItems[0];
            txbMaCV.Text = listview.SubItems[0].Text;
            txbTenCV.Text = listview.SubItems[1].Text;
        }
        #region EventButton
        private void btnRsCV_Click(object sender, EventArgs e)
        {
            btnThemCV.Enabled = true;
            btnSuaCV.Enabled = true;
            btnXoaCV.Enabled = true;
            txbMaCV.Enabled = true;
            txbMaCV.Clear();
            txbTenCV.Clear();
        }

        private void btnThemCV_Click(object sender, EventArgs e)
        {
            if(txbMaCV.Text != "")
            {
                ListViewItem listview = new ListViewItem(txbMaCV.Text);
                listview.SubItems.Add(txbTenCV.Text);
                lvCV.Items.Add(listview);
                AddCV_ToDatabase();
            }
            else
            {
                MessageBox.Show("Chưa nhập mã chức vụ","Thông báo");
            }
          
        }

        private void btnSuaCV_Click(object sender, EventArgs e)
        {
            if (lvCV.SelectedItems.Count == 0) return;
            ListViewItem listview = lvCV.SelectedItems[0];
            listview.SubItems[0].Text = txbMaCV.Text;
            listview.SubItems[1].Text = txbTenCV.Text;
            UpdateCV_ToDatabase();
        }

        private void btnXoaCV_Click(object sender, EventArgs e)
        {
            if (lvCV.SelectedItems.Count != 0)
            {
                for (int i = 0; i < lvCV.Items.Count; i++)
                {
                    if (lvCV.Items[i].Selected)
                    {
                        lvCV.Items[i].Remove();
                        i--;
                    }
                }
                DeleteCv_ToDatabase();
            }
            else
            {
                MessageBox.Show("Cần chọn chức vụ cần xóa !","Thông báo");
            }
        }
        #endregion
        #region EventDatabase_CV
        public void AddCV_ToDatabase()
        {
            dt.OpenConnection();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "ThemCV";
            cmd.Connection = dt.conn;

            cmd.Parameters.Add("@machucvu", SqlDbType.NVarChar).Value = txbMaCV.Text;
            cmd.Parameters.Add("@tenchucvu", SqlDbType.NVarChar).Value = txbTenCV.Text;
            int ret = cmd.ExecuteNonQuery();
            lvCV.Items.Clear();
            if (ret > 0)
                ShowDataCV();
            MessageBox.Show("Thêm mới thành công!");
        }
        public void UpdateCV_ToDatabase()
        {
            dt.OpenConnection();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SuaCV";
            cmd.Connection = dt.conn;

            cmd.Parameters.Add("@machucvu", SqlDbType.NVarChar).Value = txbMaCV.Text;
            cmd.Parameters.Add("@tenchucvu", SqlDbType.NVarChar).Value = txbTenCV.Text;
            int ret = cmd.ExecuteNonQuery();
            lvCV.Items.Clear();
            if (ret > 0)
                ShowDataCV();
            MessageBox.Show("Cập nhật thành công!");
        }
        public void DeleteCv_ToDatabase()
        {
            dt.OpenConnection();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "XoaCV";
            cmd.Connection = dt.conn;

            cmd.Parameters.Add("@machucvu", SqlDbType.NVarChar).Value = txbMaCV.Text;
            int ret = cmd.ExecuteNonQuery();
            lvCV.Items.Clear();
            if (ret > 0)
                ShowDataCV();
            MessageBox.Show("Xóa thành công!");

        }

		#endregion

		
	}
}

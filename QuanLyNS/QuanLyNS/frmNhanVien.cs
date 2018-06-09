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
            //TK_NV
            txtTimKiemNV.ForeColor = Color.LightGray;
            txtTimKiemNV.Text = "Tìm kiếm";
            this.txtTimKiemNV.Leave += new System.EventHandler(this.txtTimKiemNV_Leave);
            this.txtTimKiemNV.Enter += new System.EventHandler(this.txtTimKiemNV_Enter);

            cbbTKNV.ForeColor = Color.LightGray;
            cbbTKNV.Text = "Tìm kiếm theo";
            this.cbbTKNV.Leave += new System.EventHandler(this.cbbTKNV_Leave);
            this.cbbTKNV.Enter += new System.EventHandler(this.cbbTKNV_Enter);

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

				AddNVToDatabase();
				MessageBox.Show("Thêm Nhân Viên tha`nh công!");
			}
			
		}
		private void btnSua_Click(object sender, EventArgs e)
		{
			btnThem.Enabled = false;
			if (lvNhanVien.SelectedItems.Count == 0) return;
			ListViewItem liv = lvNhanVien.SelectedItems[0];
			liv.SubItems[0].Text = txbMaNV.Text;
			liv.SubItems[1].Text = txbTen.Text;
			if (rdbNam.Checked == true)
			{
				liv.SubItems[2].Text = rdbNam.Text;
			}
			else
			{
				liv.SubItems[2].Text = rdbNu.Text;
			}
			liv.SubItems[3].Text = txbSDT.Text;
			liv.SubItems[4].Text = txbQueQuan.Text;
			liv.SubItems[5].Text = dtNS.Text;
			liv.SubItems[6].Text = cbbHV.Text;
			liv.SubItems[7].Text = cbbPB.Text;
			EditNVToDatabase();
			MessageBox.Show("Sửa thành công!");
		}
		private void btnXoa_Click(object sender, EventArgs e)
		{
			if (lvNhanVien.SelectedItems != null)
			{
				for (int i = 0; i < lvNhanVien.Items.Count; i++)
				{
					if (lvNhanVien.Items[i].Selected)
					{
						lvNhanVien.Items[i].Remove();
						i--;
					}
				}
			}
			DeleteHS_Database();
			MessageBox.Show("Đã xóa nhân viên!");
		}
		private void btnRs_Click(object sender, EventArgs e)
		{
			btnThem.Enabled = true;
			btnSua.Enabled = false;
			btnXoa.Enabled = false;
			txbMaNV.Enabled = true;
			txbMaNV.ResetText();
			txbTen.ResetText();
			rdbNam.Checked = true;
			txbSDT.ResetText();
			txbQueQuan.ResetText();
			cbbHV.ResetText();
			cbbPB.ResetText();
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
		public void EditNVToDatabase()
		{
			dt.OpenConnection();
			SqlCommand cmd = new SqlCommand();
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "SuaNV";
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

		public void DeleteHS_Database()
		{
			dt.OpenConnection();
			SqlCommand cmd = new SqlCommand();
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "XoaNV";
			cmd.Connection = dt.conn;

			cmd.Parameters.Add("@MaNV", SqlDbType.NVarChar).Value = txbMaNV.Text;

			int rekt = cmd.ExecuteNonQuery(); 
			lvNhanVien.Items.Clear();
			if (rekt > 0)
				ShowDataNV();
		}
		#endregion
		private void lvNhanVien_SelectedIndexChanged(object sender, EventArgs e)
		{
			txbMaNV.Enabled = false;
			btnThem.Enabled = false;
			btnXoa.Enabled = true;
			btnSua.Enabled = true;
			if (lvNhanVien.SelectedItems.Count == 0) return;
			ListViewItem liv = lvNhanVien.SelectedItems[0];
			txbMaNV.Text = liv.SubItems[0].Text;
			txbTen.Text = liv.SubItems[1].Text;
			if (rdbNam.Text.ToLower() == liv.SubItems[2].Text.ToLower())
			{
				rdbNam.Checked = true;
				rdbNu.Checked = false;
			}
			else
			{
				rdbNu.Checked = true;
				rdbNam.Checked = false;
			}

			txbSDT.Text = liv.SubItems[3].Text;
			txbQueQuan.Text = liv.SubItems[4].Text;

			dtNS.Text = liv.SubItems[5].Text;
			cbbHV.Text = liv.SubItems[6].Text;
			cbbPB.Text = liv.SubItems[7].Text;
		}


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
				AddTDToDatabase();
				MessageBox.Show("Thêm thành công!");
			}
			
		}
		private void btnSuatd_Click(object sender, EventArgs e)
		{
			btnThemtd.Enabled = false;
			if (lvTrinhDo.SelectedItems.Count == 0) return;
			ListViewItem liv = lvTrinhDo.SelectedItems[0];
			liv.SubItems[0].Text = txbMatd.Text;
			liv.SubItems[1].Text = txbTentd.Text;
			liv.SubItems[2].Text = txbCN.Text;

			EditTDToDatabase();
			MessageBox.Show("Sửa thành công!");
		}
		private void lvTrinhDo_SelectedIndexChanged(object sender, EventArgs e)
		{
			txbMatd.Enabled = false;
			btnThemtd.Enabled = false;
			btnXoatd.Enabled = true;
			btnSuatd.Enabled = true;
			if (lvTrinhDo.SelectedItems.Count == 0) return;
			ListViewItem liv = lvTrinhDo.SelectedItems[0];
			txbMatd.Text = liv.SubItems[0].Text;
			txbTentd.Text = liv.SubItems[1].Text;
			txbCN.Text = liv.SubItems[2].Text;
		}

		private void btnRstd_Click(object sender, EventArgs e)
		{
			btnThemtd.Enabled = true;
			btnSuatd.Enabled = false;
			btnXoatd.Enabled = false;
			txbMatd.Enabled = true;
			txbMatd.ResetText();
			txbTentd.ResetText();
			txbCN.ResetText();
		}

		private void btnXoatd_Click(object sender, EventArgs e)
		{
			if (lvTrinhDo.SelectedItems != null)
			{
				for (int i = 0; i < lvTrinhDo.Items.Count; i++)
				{
					if (lvTrinhDo.Items[i].Selected)
					{
						lvTrinhDo.Items[i].Remove();
						i--;
					}
				}
			}
			DeleteTD_Database();
			MessageBox.Show("Đã xóa!");
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
		public void EditTDToDatabase()
		{
			dt.OpenConnection();
			SqlCommand cmd = new SqlCommand();
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "SuaTD";
			cmd.Connection = dt.conn;

			cmd.Parameters.Add("@MaTDHV", SqlDbType.NVarChar).Value = txbMatd.Text;
			cmd.Parameters.Add("@TenTrinhDo", SqlDbType.NVarChar).Value = txbTentd.Text;
			cmd.Parameters.Add("@ChuyenNganh ", SqlDbType.NChar).Value = txbCN.Text;
			int ret = cmd.ExecuteNonQuery();
			lvTrinhDo.Items.Clear();
			if (ret > 0)
				ShowDataTD();
		}

		public void DeleteTD_Database()
		{
			dt.OpenConnection();
			SqlCommand cmd = new SqlCommand();
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "XoaTD";
			cmd.Connection = dt.conn;

			cmd.Parameters.Add("@MaTDHV", SqlDbType.NVarChar).Value = txbMatd.Text;

			int rekt = cmd.ExecuteNonQuery();
			lvNhanVien.Items.Clear();
			if (rekt > 0)
				ShowDataNV();
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
                string macv = reader.GetString(0);
                ListViewItem liv = new ListViewItem(reader.GetString(0));
                liv.SubItems.Add(reader.GetString(1));
                list.Add(macv);
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
            if (txbMaCV.Text != "")
            {
                foreach (string us in list)
                {
                    if (us.Contains(txbMaCV.Text))
                    {
                        MessageBox.Show("Mã đã tồn tại!");
                        check = false;
                        break;
                    }
                    check = true;
                }
                if (check == true)
                {

                    ListViewItem listview = new ListViewItem(txbMaCV.Text);
                    listview.SubItems.Add(txbTenCV.Text);
                    lvCV.Items.Add(listview);
                    AddCV_ToDatabase();

                }
            }
            else
            {
                MessageBox.Show("Chưa nhập mã chức vụ", "Thông báo");
            }
            
        }
        private void btnSuaCV_Click(object sender, EventArgs e)
        {
            if (lvCV.SelectedItems.Count == 0)
            {
                MessageBox.Show("Chọn chức vụ muốn sửa !", "Thống báo");
            }
            else
            {
                ListViewItem listview = lvCV.SelectedItems[0];
                listview.SubItems[0].Text = txbMaCV.Text;
                listview.SubItems[1].Text = txbTenCV.Text;
                UpdateCV_ToDatabase();
            }         
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

        #region TimKiem_NhanVien

        private void txtTimKiemNV_Leave(object sender, EventArgs e)
        {
            if (txtTimKiemNV.Text == "")
            {
                txtTimKiemNV.Text = "Tìm kiếm";
                txtTimKiemNV.ForeColor = Color.Gray;
            }
        }

        private void txtTimKiemNV_Enter(object sender, EventArgs e)
        {
            if (txtTimKiemNV.Text == "Tìm kiếm")
            {
                txtTimKiemNV.Text = "";
                txtTimKiemNV.ForeColor = Color.Black;
            }
        }

        private void btnTimKiemNV_Click(object sender, EventArgs e)
        {
            if (cbbTKNV.SelectedIndex == 0)
            {
                string str = txtTimKiemNV.Text;
                dt.OpenConnection();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from NHANVIEN Where MaNV like '%" + str + "%'";
                cmd.Connection = dt.conn;

                SqlDataReader reader = cmd.ExecuteReader();
                lvNhanVien.Items.Clear();
                while (reader.Read())
                {
                   
                    ListViewItem liv = new ListViewItem(reader.GetString(0));
                    liv.SubItems.Add(reader.GetString(1));
                    liv.SubItems.Add(reader.GetString(2));
                    liv.SubItems.Add(reader.GetString(3));
                    liv.SubItems.Add(reader.GetString(4));
                    liv.SubItems.Add(reader.GetDateTime(5).ToString());
                    liv.SubItems.Add(reader.GetString(6));
                    liv.SubItems.Add(reader.GetString(7));

                    
                   lvNhanVien.Items.Add(liv);
                }
                reader.Close();
            }
            else if (cbbTKNV.SelectedIndex == 1)
            {
                string str = txtTimKiemNV.Text;
                dt.OpenConnection();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from NHANVIEN Where HoTen like '%" + str + "%'";
                cmd.Connection = dt.conn;

                SqlDataReader reader = cmd.ExecuteReader();
                lvNhanVien.Items.Clear();
                while (reader.Read())
                {
                    
                    ListViewItem liv = new ListViewItem(reader.GetString(0));
                    liv.SubItems.Add(reader.GetString(1));
                    liv.SubItems.Add(reader.GetString(2));
                    liv.SubItems.Add(reader.GetString(3));
                    liv.SubItems.Add(reader.GetString(4));
                    liv.SubItems.Add(reader.GetDateTime(5).ToString());
                    liv.SubItems.Add(reader.GetString(6));
                    liv.SubItems.Add(reader.GetString(7));

                    
                    lvNhanVien.Items.Add(liv);
                }
                reader.Close();
            }
            else if (cbbTKNV.SelectedIndex == 2)
            {
                string str = txtTimKiemNV.Text;
                dt.OpenConnection();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from NHANVIEN Where SDT like '%" + str + "%'";
                cmd.Connection = dt.conn;

                SqlDataReader reader = cmd.ExecuteReader();
                lvNhanVien.Items.Clear();
                while (reader.Read())
                {
                    
                    ListViewItem liv = new ListViewItem(reader.GetString(0));
                    liv.SubItems.Add(reader.GetString(1));
                    liv.SubItems.Add(reader.GetString(2));
                    liv.SubItems.Add(reader.GetString(3));
                    liv.SubItems.Add(reader.GetString(4));
                    liv.SubItems.Add(reader.GetDateTime(5).ToString());
                    liv.SubItems.Add(reader.GetString(6));
                    liv.SubItems.Add(reader.GetString(7));

                   
                    lvNhanVien.Items.Add(liv);
                }
                reader.Close();
            }
            else if (cbbTKNV.SelectedIndex == 3)
            {
                string str = txtTimKiemNV.Text;
                dt.OpenConnection();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from NHANVIEN Where QueQuan like '%" + str + "%'";
                cmd.Connection = dt.conn;

                SqlDataReader reader = cmd.ExecuteReader();
                lvNhanVien.Items.Clear();
                while (reader.Read())
                {
                    
                    ListViewItem liv = new ListViewItem(reader.GetString(0));
                    liv.SubItems.Add(reader.GetString(1));
                    liv.SubItems.Add(reader.GetString(2));
                    liv.SubItems.Add(reader.GetString(3));
                    liv.SubItems.Add(reader.GetString(4));
                    liv.SubItems.Add(reader.GetDateTime(5).ToString());
                    liv.SubItems.Add(reader.GetString(6));
                    liv.SubItems.Add(reader.GetString(7));

                    
                    lvNhanVien.Items.Add(liv);
                }
                reader.Close();
            }
            else if (cbbTKNV.SelectedIndex == 4)
            {
                string str = txtTimKiemNV.Text;
                dt.OpenConnection();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from NHANVIEN Where NgaySinh like '%" + str + "%'";
                cmd.Connection = dt.conn;

                SqlDataReader reader = cmd.ExecuteReader();
                lvNhanVien.Items.Clear();
                while (reader.Read())
                {
                    
                    ListViewItem liv = new ListViewItem(reader.GetString(0));
                    liv.SubItems.Add(reader.GetString(1));
                    liv.SubItems.Add(reader.GetString(2));
                    liv.SubItems.Add(reader.GetString(3));
                    liv.SubItems.Add(reader.GetString(4));
                    liv.SubItems.Add(reader.GetDateTime(5).ToString());
                    liv.SubItems.Add(reader.GetString(6));
                    liv.SubItems.Add(reader.GetString(7));
                    
                    lvNhanVien.Items.Add(liv);
                }
                reader.Close();
            }
            else if (cbbTKNV.SelectedIndex == 5)
            {
                string str = txtTimKiemNV.Text;
                dt.OpenConnection();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from NHANVIEN Where MaPB like '%" + str + "%'";
                cmd.Connection = dt.conn;

                SqlDataReader reader = cmd.ExecuteReader();
                lvNhanVien.Items.Clear();
                while (reader.Read())
                {
                    
                    ListViewItem liv = new ListViewItem(reader.GetString(0));
                    liv.SubItems.Add(reader.GetString(1));
                    liv.SubItems.Add(reader.GetString(2));
                    liv.SubItems.Add(reader.GetString(3));
                    liv.SubItems.Add(reader.GetString(4));
                    liv.SubItems.Add(reader.GetDateTime(5).ToString());
                    liv.SubItems.Add(reader.GetString(6));
                    liv.SubItems.Add(reader.GetString(7));

                    
                    lvNhanVien.Items.Add(liv);
                }
                reader.Close();
            }
        }

        private void cbbTKNV_Enter(object sender, EventArgs e)
        {
            if (cbbTKNV.Text == "Tìm kiếm theo")
            {
                cbbTKNV.Text = "";
                cbbTKNV.ForeColor = Color.Black;
            }
        }

        private void cbbTKNV_Leave(object sender, EventArgs e)
        {
            if (cbbTKNV.Text == "")
            {
                cbbTKNV.Text = "Tìm kiếm theo";
                cbbTKNV.ForeColor = Color.Gray;
            }
        }
        #endregion

        #region TimKiem_ChucVu

        private void btnTimKiemCV_Click(object sender, EventArgs e)
        {
            if (cbbTKCV.SelectedIndex == 0)
            {
                string str = txtTimKiemCV.Text;
                dt.OpenConnection();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from CHUCVU Where MaCV like '%" + str + "%'";
                cmd.Connection = dt.conn;

                SqlDataReader reader = cmd.ExecuteReader();
                lvCV.Items.Clear();
                while (reader.Read())
                {
                    string macv = reader.GetString(0);
                    ListViewItem liv = new ListViewItem(reader.GetString(0));
                    liv.SubItems.Add(reader.GetString(1));
                    lvCV.Items.Add(liv);
                }
                reader.Close();
            }
            else if (cbbTKCV.SelectedIndex == 1)
            {
                string str = txtTimKiemCV.Text;
                dt.OpenConnection();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from CHUCVU Where TenCV like '%" + str + "%'";
                cmd.Connection = dt.conn;

                SqlDataReader reader = cmd.ExecuteReader();
                lvCV.Items.Clear();
                while (reader.Read())
                {
                    string macv = reader.GetString(0);
                    ListViewItem liv = new ListViewItem(reader.GetString(0));
                    liv.SubItems.Add(reader.GetString(1));
                    lvCV.Items.Add(liv);
                }
                reader.Close();
            }
        }
        #endregion


    }
}

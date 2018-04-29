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
    public partial class frmHDLD : Form
    {
        public frmHDLD()
        {
            InitializeComponent();
        }
		DataConections dt = new DataConections();

        #region ShowData-ListView-ComboBox
        
        private void lvHDLD_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtMaHD.Enabled = false;
            btnThem.Enabled = false;
            btnXoa.Enabled = true;
            btnSua.Enabled = true;
            if (lvHDLD.SelectedItems.Count == 0) return;
            ListViewItem liv = lvHDLD.SelectedItems[0];
            txtMaHD.Text = liv.SubItems[0].Text;
            txtLoaiHD.Text = liv.SubItems[1].Text;
            txtLuong.Text = liv.SubItems[2].Text;
            cbbMaNV.Text = liv.SubItems[3].Text;
        }

        private void frmHDLD_Load(object sender, EventArgs e)
        {
            ShowData();
            NhanVien();
        }
        List<string> lst = new List<string>();
        private void ShowData()
        {
            dt.OpenConnection();
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from HOPDONGLAODONG";
            cmd.Connection = dt.conn;

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                string mahdld = reader.GetString(0);
                ListViewItem liv = new ListViewItem(reader.GetString(0));
                liv.SubItems.Add(reader.GetString(1));
                liv.SubItems.Add(reader.GetInt64(2).ToString());
                liv.SubItems.Add(reader.GetString(3));
                lst.Add(mahdld);
                lvHDLD.Items.Add(liv);
            }
            reader.Close();
        }

        private void NhanVien()
        {
            dt.OpenConnection();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select N.MaNV from NHANVIEN N WHERE NOT EXISTS (SELECT * FROM HOPDONGLAODONG H WHERE N.MaNV=H.MaNV) ";
            cmd.Connection = dt.conn;

            SqlDataReader reader = cmd.ExecuteReader();
            cbbMaNV.Items.Clear();
            while (reader.Read())
            {
                string manvien = reader.GetString(0);
                cbbMaNV.Items.Add(manvien);
            }
            reader.Close();
        }

        string manv = "";
        private void cbbTenNV_SelectedIndexChanged(object sender, EventArgs e)
        {
            string valuePM = cbbMaNV.SelectedItem.ToString();
            string[] arrPM = valuePM.Split('-');
            manv = arrPM[0];
        }
        #endregion

        #region DataBase

        public void AddHD_DataBase()
        {
            dt.OpenConnection();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "ThemHD";
            cmd.Connection = dt.conn;

            cmd.Parameters.Add("@MaHD", SqlDbType.NVarChar).Value = txtMaHD.Text;
            cmd.Parameters.Add("@LoaiHD", SqlDbType.NVarChar).Value = txtLoaiHD.Text;
            cmd.Parameters.Add("@Luongthoathuan", SqlDbType.BigInt).Value = Convert.ToInt64(txtLuong.Text);
            cmd.Parameters.Add("@MaNV", SqlDbType.NVarChar).Value = manv;

            int ret = cmd.ExecuteNonQuery();
            lvHDLD.Items.Clear();
            if (ret > 0)
                ShowData();
        }

        public void RepairHD_Database()
        {
            dt.OpenConnection();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SuaHD";
            cmd.Connection = dt.conn;

            cmd.Parameters.Add("@MaHD", SqlDbType.NVarChar).Value = txtMaHD.Text;
            cmd.Parameters.Add("@LoaiHD", SqlDbType.NVarChar).Value = txtLoaiHD.Text;
            cmd.Parameters.Add("@Luongthoathuan", SqlDbType.BigInt).Value = Convert.ToInt64(txtLuong.Text);
            cmd.Parameters.Add("@MaNV", SqlDbType.NVarChar).Value = cbbMaNV.Text;

            int ret = cmd.ExecuteNonQuery();
            lvHDLD.Items.Clear();
            if (ret > 0)
                ShowData();

        }

        public void DeleteHD_Database()
        {
            dt.OpenConnection();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "XoaHD";
            cmd.Connection = dt.conn;

            cmd.Parameters.Add("@MaHD", SqlDbType.NVarChar).Value = txtMaHD.Text;

            int ret = cmd.ExecuteNonQuery();
            lvHDLD.Items.Clear();
            if (ret > 0)
                ShowData();
        }


        #endregion
        #region Control
        private void btnThem_Click(object sender, EventArgs e)
        {
            ListViewItem liv = new ListViewItem(txtMaHD.Text);
            liv.SubItems.Add(txtLoaiHD.Text);
            liv.SubItems.Add(txtLuong.Text);
            liv.SubItems.Add(manv);            
            lvHDLD.Items.Add(liv);
            if (txtMaHD.Text == "")
                MessageBox.Show("Nhập mã hợp đồng!");
            else
            {
                if (cbbMaNV.Text == "")
                    MessageBox.Show("Nhập mã nhân viên");
                else
                {
                    if (txtLuong.Text == "")
                        txtLuong.Text = "0";
                    AddHD_DataBase();
                    MessageBox.Show("Đã sửa thành công");
                }
            }
        }
        
        private void btnSua_Click(object sender, EventArgs e)
        {
            btnThem.Enabled = true;
            if (lvHDLD.SelectedItems.Count == 0) return;
            ListViewItem liv = lvHDLD.SelectedItems[0];
            liv.SubItems[0].Text = txtMaHD.Text;
            liv.SubItems[1].Text = txtLoaiHD.Text;
            liv.SubItems[2].Text = cbbMaNV.Text;
            liv.SubItems[3].Text = txtLuong.Text;
            if (cbbMaNV.Text == "")
            {
                MessageBox.Show("Nhập mã nhân viên");
            }
            else
            {
                if (txtLuong.Text == "")
                    txtLuong.Text = "0";
                RepairHD_Database();
                MessageBox.Show("Đã sửa thành công");
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (lvHDLD.SelectedItems != null)
            {
                for (int i = 0; i < lvHDLD.Items.Count; i++)
                {
                    if (lvHDLD.Items[i].Selected)
                    {
                        lvHDLD.Items[i].Remove();
                        i--;
                    }
                }
            }
            DeleteHD_Database();
            MessageBox.Show("Đã xoá thành công");
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            btnThem.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            txtMaHD.Enabled = true;
            txtMaHD.ResetText();
            txtLoaiHD.ResetText();
            txtLuong.ResetText();
            cbbMaNV.Refresh();
            cbbMaNV.ResetText();
            
        }
        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace QuanLyNS
{
    public partial class frmPhongBan : Form
    {
        public frmPhongBan()
        {
            InitializeComponent();
        }
        DataConections dt = new DataConections();
        #region ShowData-ListView-ComboBox

        
        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtMapb.Enabled = false;
            btnThempb.Enabled = false;
            btnXoapb.Enabled = true;
            btnSuapb.Enabled = true;
            if (lvPB.SelectedItems.Count == 0) return;
            ListViewItem liv = lvPB.SelectedItems[0];
            txtMapb.Text = liv.SubItems[0].Text;
            txtTenpb.Text = liv.SubItems[1].Text;
            cbbTP.Text = liv.SubItems[2].Text;
            txtDiaChi.Text = liv.SubItems[3].Text;
            txtSDT.Text = liv.SubItems[4].Text;
            
        }

        private void frmPhongBan_Load(object sender, EventArgs e)
        {
            ShowData();
            MaTP();
        }
        List<string> lst = new List<string>();
        public void ShowData()
        {
            dt.OpenConnection();
            btnSuapb.Enabled = false;
            btnXoapb.Enabled = false;
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from PHONGBAN";
            cmd.Connection = dt.conn;
            SqlDataReader reader = cmd.ExecuteReader();            
            while (reader.Read())
            {
                 
                ListViewItem liv = new ListViewItem(reader.GetString(0));
                liv.SubItems.Add(reader.GetString(1));
                liv.SubItems.Add(reader.GetString(2));   
                liv.SubItems.Add(reader.GetString(3));
                liv.SubItems.Add(reader.GetString(4)); 
                lvPB.Items.Add(liv);
            }
            reader.Close();
        }

        public void MaTP()
        {
            dt.OpenConnection();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from PHONGBAN";
            cmd.Connection = dt.conn;

            SqlDataReader reader = cmd.ExecuteReader();
            cbbTP.Items.Clear();
            while (reader.Read())
            {
                string mtp = reader.GetString(2);
                cbbTP.Items.Add(mtp);
            }
            reader.Close();
        }
        string matp = "";
        private void cbbTP_SelectedIndexChanged(object sender, EventArgs e)
        {           
            string valuePM = cbbTP.SelectedItem.ToString();
            string[] arrPM = valuePM.Split('-');
            matp = arrPM[0];
        }
        #endregion
        #region DataBase

        public void AddPB_DataBase()
        {
            dt.OpenConnection();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "ThemPB";
            cmd.Connection = dt.conn;

            cmd.Parameters.Add("@MaPB", SqlDbType.NVarChar).Value = txtMapb.Text;
            cmd.Parameters.Add("@TenPB", SqlDbType.NVarChar).Value = txtTenpb.Text;
            cmd.Parameters.Add("@MaTP", SqlDbType.NVarChar).Value = matp;
            cmd.Parameters.Add("@DiaChi", SqlDbType.NVarChar).Value = txtDiaChi.Text;
            cmd.Parameters.Add("@SDT", SqlDbType.Char).Value = txtSDT.Text;

            int ret = cmd.ExecuteNonQuery();
            lvPB.Items.Clear();
            if (ret > 0)
                ShowData();
        }

        public void repairPB_Database()
        {
            dt.OpenConnection();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SuaPB";
            cmd.Connection = dt.conn;

            cmd.Parameters.Add("@MaPB", SqlDbType.NVarChar).Value = txtMapb.Text;
            cmd.Parameters.Add("@TenPB", SqlDbType.NVarChar).Value = txtTenpb.Text;
            cmd.Parameters.Add("@MaTP", SqlDbType.NVarChar).Value = cbbTP.Text;
            cmd.Parameters.Add("@DiaChi", SqlDbType.NVarChar).Value = txtDiaChi.Text;
            cmd.Parameters.Add("@SDT", SqlDbType.Char).Value = txtSDT.Text;

            int ret = cmd.ExecuteNonQuery();
            lvPB.Items.Clear();
            if (ret > 0)
                ShowData();

        }

        public void DeletePB_Database()
        {
            dt.OpenConnection();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "XoaPB";          
            cmd.Connection = dt.conn;

            cmd.Parameters.Add("@MaPB", SqlDbType.NVarChar).Value = txtMapb.Text;

            int ret = cmd.ExecuteNonQuery();
            lvPB.Items.Clear();
            if (ret > 0)
                ShowData();
        }
        #endregion

        #region Control

        private void btnThempb_Click(object sender, EventArgs e)
        {
            ListViewItem liv = new ListViewItem(txtMapb.Text);
            liv.SubItems.Add(txtTenpb.Text);
            liv.SubItems.Add(matp);
            liv.SubItems.Add(txtDiaChi.Text);
            liv.SubItems.Add(txtSDT.Text);
            lvPB.Items.Add(liv);
            AddPB_DataBase();
            MessageBox.Show("Đã thêm thành công");
        }

        private void btnSuapb_Click(object sender, EventArgs e)
        {
            btnThempb.Enabled = true;
            if (lvPB.SelectedItems.Count == 0) return;
            ListViewItem liv = lvPB.SelectedItems[0];
            liv.SubItems[0].Text = txtMapb.Text;
            liv.SubItems[1].Text = txtTenpb.Text;
            liv.SubItems[2].Text = cbbTP.Text;
            liv.SubItems[3].Text = txtDiaChi.Text;
            liv.SubItems[4].Text = txtSDT.Text;
            repairPB_Database();
            MessageBox.Show("Đã sửa thành công");
        }

        private void btnXoapb_Click(object sender, EventArgs e)
        {
            if (lvPB.SelectedItems != null)
            {
                for (int i = 0; i < lvPB.Items.Count; i++)
                {
                    if (lvPB.Items[i].Selected)
                    {
                        lvPB.Items[i].Remove();
                        i--;
                    }
                }
            }
            DeletePB_Database();
            MessageBox.Show("Đã xoá thành công");
        }

        private void btnRspb_Click(object sender, EventArgs e)
        {
            btnThempb.Enabled = true;
            btnSuapb.Enabled = false;
            btnXoapb.Enabled = false;
            txtMapb.Enabled = true;
            txtMapb.ResetText();
            txtTenpb.ResetText();
            cbbTP.Refresh();
            cbbTP.ResetText();
            txtDiaChi.ResetText();
            txtSDT.ResetText();
        }
        #endregion


    }
}

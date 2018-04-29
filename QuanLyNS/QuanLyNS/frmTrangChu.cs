using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyNS
{
    public partial class frmTrangChu : Form
    {
        public frmTrangChu()
        {
            InitializeComponent();
        }

        private void btnNV_Click(object sender, EventArgs e)
        {
            frmNhanVien f = new frmNhanVien();
            this.Hide();
            f.ShowDialog();
            this.Show();
        } 

        private void btnHD_Click(object sender, EventArgs e)
        {
           frmHDLD frmhd = new frmHDLD();
           this.Hide();
           frmhd.ShowDialog();
           this.Show();
        }

        private void btnPB_Click(object sender, EventArgs e)
        {
            frmPhongBan frmpb = new frmPhongBan();
            this.Hide();
            frmpb.ShowDialog();
            this.Show();
        }
    }
}

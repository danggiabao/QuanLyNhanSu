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
        frmPhongBan frmpb = new frmPhongBan();
        private void button2_Click(object sender, EventArgs e)
        {
            frmPhongBan frmpb = new frmPhongBan();
            this.Hide();
            frmpb.ShowDialog();
            this.Show();
        }
        
        private void button3_Click(object sender, EventArgs e)
        {
            frmHDLD frmhd = new frmHDLD();
            this.Hide();
            frmhd.ShowDialog();
            this.Show();
        }
    }
}

namespace QuanLyNS
{
    partial class frmTrangChu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnHD = new System.Windows.Forms.Button();
            this.btnPB = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnNV = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.panel1.Controls.Add(this.btnHD);
            this.panel1.Controls.Add(this.btnPB);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btnNV);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1015, 613);
            this.panel1.TabIndex = 0;
            // 
            // btnHD
            // 
            this.btnHD.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnHD.Font = new System.Drawing.Font("Courier New", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHD.ForeColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnHD.Image = global::QuanLyNS.Properties.Resources.Clipboard_icon;
            this.btnHD.Location = new System.Drawing.Point(624, 203);
            this.btnHD.Name = "btnHD";
            this.btnHD.Size = new System.Drawing.Size(259, 173);
            this.btnHD.TabIndex = 8;
            this.btnHD.Text = "Quản lý hợp đồng lao động";
            this.btnHD.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnHD.UseVisualStyleBackColor = false;
            this.btnHD.Click += new System.EventHandler(this.btnHD_Click);
            // 
            // btnPB
            // 
            this.btnPB.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnPB.Font = new System.Drawing.Font("Courier New", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPB.ForeColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnPB.Image = global::QuanLyNS.Properties.Resources.icons8_embassy_100;
            this.btnPB.Location = new System.Drawing.Point(375, 203);
            this.btnPB.Name = "btnPB";
            this.btnPB.Size = new System.Drawing.Size(243, 173);
            this.btnPB.TabIndex = 7;
            this.btnPB.Text = "Quản lý phòng ban";
            this.btnPB.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnPB.UseVisualStyleBackColor = false;
            this.btnPB.Click += new System.EventHandler(this.btnPB_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(369, 99);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(270, 32);
            this.label1.TabIndex = 6;
            this.label1.Text = "Lựa chọn chức năng";
            // 
            // btnNV
            // 
            this.btnNV.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnNV.Font = new System.Drawing.Font("Courier New", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNV.ForeColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnNV.Image = global::QuanLyNS.Properties.Resources.icons8_conference_100;
            this.btnNV.Location = new System.Drawing.Point(110, 203);
            this.btnNV.Name = "btnNV";
            this.btnNV.Size = new System.Drawing.Size(259, 173);
            this.btnNV.TabIndex = 0;
            this.btnNV.Text = "Quản lý nhân viên";
            this.btnNV.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnNV.UseVisualStyleBackColor = false;
            this.btnNV.Click += new System.EventHandler(this.btnNV_Click);
            // 
            // frmTrangChu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1015, 613);
            this.Controls.Add(this.panel1);
            this.Name = "frmTrangChu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Trang chủ";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnNV;
        private System.Windows.Forms.Button btnHD;
        private System.Windows.Forms.Button btnPB;
    }
}
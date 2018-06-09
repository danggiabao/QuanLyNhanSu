namespace QuanLyNS
{
    partial class frmPhongBan
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lvPB = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cbbTP = new System.Windows.Forms.ComboBox();
            this.txtSDT = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnRspb = new System.Windows.Forms.Button();
            this.btnXoapb = new System.Windows.Forms.Button();
            this.btnSuapb = new System.Windows.Forms.Button();
            this.btnThempb = new System.Windows.Forms.Button();
            this.txtDiaChi = new System.Windows.Forms.TextBox();
            this.txtTenpb = new System.Windows.Forms.TextBox();
            this.txtMapb = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTimKiemPB = new System.Windows.Forms.TextBox();
            this.cbbTKPB = new System.Windows.Forms.ComboBox();
            this.btnTimKiemPB = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.splitContainer1.Panel2.Controls.Add(this.btnTimKiemPB);
            this.splitContainer1.Panel2.Controls.Add(this.cbbTKPB);
            this.splitContainer1.Panel2.Controls.Add(this.txtTimKiemPB);
            this.splitContainer1.Panel2.Controls.Add(this.cbbTP);
            this.splitContainer1.Panel2.Controls.Add(this.txtSDT);
            this.splitContainer1.Panel2.Controls.Add(this.label5);
            this.splitContainer1.Panel2.Controls.Add(this.btnRspb);
            this.splitContainer1.Panel2.Controls.Add(this.btnXoapb);
            this.splitContainer1.Panel2.Controls.Add(this.btnSuapb);
            this.splitContainer1.Panel2.Controls.Add(this.btnThempb);
            this.splitContainer1.Panel2.Controls.Add(this.txtDiaChi);
            this.splitContainer1.Panel2.Controls.Add(this.txtTenpb);
            this.splitContainer1.Panel2.Controls.Add(this.txtMapb);
            this.splitContainer1.Panel2.Controls.Add(this.label4);
            this.splitContainer1.Panel2.Controls.Add(this.label3);
            this.splitContainer1.Panel2.Controls.Add(this.label2);
            this.splitContainer1.Panel2.Controls.Add(this.label1);
            this.splitContainer1.Size = new System.Drawing.Size(761, 498);
            this.splitContainer1.SplitterDistance = 312;
            this.splitContainer1.SplitterWidth = 3;
            this.splitContainer1.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.groupBox1.Controls.Add(this.lvPB);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Size = new System.Drawing.Size(761, 312);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin hợp đồng lao động";
            // 
            // lvPB
            // 
            this.lvPB.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5});
            this.lvPB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvPB.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvPB.FullRowSelect = true;
            this.lvPB.GridLines = true;
            this.lvPB.Location = new System.Drawing.Point(2, 22);
            this.lvPB.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.lvPB.Name = "lvPB";
            this.lvPB.Size = new System.Drawing.Size(757, 288);
            this.lvPB.TabIndex = 0;
            this.lvPB.UseCompatibleStateImageBehavior = false;
            this.lvPB.View = System.Windows.Forms.View.Details;
            this.lvPB.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Mã Phòng Ban";
            this.columnHeader1.Width = 155;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Tên Phòng Ban";
            this.columnHeader2.Width = 162;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Mã Trưởng Phòng";
            this.columnHeader3.Width = 185;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Địa chỉ";
            this.columnHeader4.Width = 197;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Số Điện Thoại";
            this.columnHeader5.Width = 166;
            // 
            // cbbTP
            // 
            this.cbbTP.FormattingEnabled = true;
            this.cbbTP.Location = new System.Drawing.Point(142, 127);
            this.cbbTP.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cbbTP.Name = "cbbTP";
            this.cbbTP.Size = new System.Drawing.Size(156, 21);
            this.cbbTP.TabIndex = 24;
            this.cbbTP.SelectedIndexChanged += new System.EventHandler(this.cbbTP_SelectedIndexChanged);
            // 
            // txtSDT
            // 
            this.txtSDT.Location = new System.Drawing.Point(438, 71);
            this.txtSDT.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtSDT.Name = "txtSDT";
            this.txtSDT.Size = new System.Drawing.Size(156, 20);
            this.txtSDT.TabIndex = 23;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(344, 71);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(91, 17);
            this.label5.TabIndex = 22;
            this.label5.Text = "Số điện thoại";
            // 
            // btnRspb
            // 
            this.btnRspb.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRspb.Location = new System.Drawing.Point(649, 138);
            this.btnRspb.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnRspb.Name = "btnRspb";
            this.btnRspb.Size = new System.Drawing.Size(80, 24);
            this.btnRspb.TabIndex = 21;
            this.btnRspb.Text = "Reset";
            this.btnRspb.UseVisualStyleBackColor = true;
            this.btnRspb.Click += new System.EventHandler(this.btnRspb_Click);
            // 
            // btnXoapb
            // 
            this.btnXoapb.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoapb.Location = new System.Drawing.Point(649, 98);
            this.btnXoapb.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnXoapb.Name = "btnXoapb";
            this.btnXoapb.Size = new System.Drawing.Size(80, 24);
            this.btnXoapb.TabIndex = 20;
            this.btnXoapb.Text = "Xóa";
            this.btnXoapb.UseVisualStyleBackColor = true;
            this.btnXoapb.Click += new System.EventHandler(this.btnXoapb_Click);
            // 
            // btnSuapb
            // 
            this.btnSuapb.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSuapb.Location = new System.Drawing.Point(649, 55);
            this.btnSuapb.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnSuapb.Name = "btnSuapb";
            this.btnSuapb.Size = new System.Drawing.Size(80, 24);
            this.btnSuapb.TabIndex = 19;
            this.btnSuapb.Text = "Sửa";
            this.btnSuapb.UseVisualStyleBackColor = true;
            this.btnSuapb.Click += new System.EventHandler(this.btnSuapb_Click);
            // 
            // btnThempb
            // 
            this.btnThempb.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThempb.Location = new System.Drawing.Point(649, 15);
            this.btnThempb.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnThempb.Name = "btnThempb";
            this.btnThempb.Size = new System.Drawing.Size(80, 24);
            this.btnThempb.TabIndex = 18;
            this.btnThempb.Text = "Thêm";
            this.btnThempb.UseVisualStyleBackColor = true;
            this.btnThempb.Click += new System.EventHandler(this.btnThempb_Click);
            // 
            // txtDiaChi
            // 
            this.txtDiaChi.Location = new System.Drawing.Point(438, 32);
            this.txtDiaChi.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtDiaChi.Name = "txtDiaChi";
            this.txtDiaChi.Size = new System.Drawing.Size(156, 20);
            this.txtDiaChi.TabIndex = 12;
            // 
            // txtTenpb
            // 
            this.txtTenpb.Location = new System.Drawing.Point(142, 79);
            this.txtTenpb.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtTenpb.Name = "txtTenpb";
            this.txtTenpb.Size = new System.Drawing.Size(156, 20);
            this.txtTenpb.TabIndex = 10;
            // 
            // txtMapb
            // 
            this.txtMapb.Location = new System.Drawing.Point(142, 34);
            this.txtMapb.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtMapb.Name = "txtMapb";
            this.txtMapb.Size = new System.Drawing.Size(156, 20);
            this.txtMapb.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(344, 34);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 17);
            this.label4.TabIndex = 4;
            this.label4.Text = "Địa chỉ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(33, 127);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(116, 17);
            this.label3.TabIndex = 3;
            this.label3.Text = "Mã trưởng phòng";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(33, 80);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Tên phòng ban";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(33, 36);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Mã phòng ban";
            // 
            // txtTimKiemPB
            // 
            this.txtTimKiemPB.Location = new System.Drawing.Point(494, 102);
            this.txtTimKiemPB.Name = "txtTimKiemPB";
            this.txtTimKiemPB.Size = new System.Drawing.Size(100, 20);
            this.txtTimKiemPB.TabIndex = 25;
            // 
            // cbbTKPB
            // 
            this.cbbTKPB.FormattingEnabled = true;
            this.cbbTKPB.Items.AddRange(new object[] {
            "Theo Mã Phòng Ban ",
            "Theo Tên Phòng Ban ",
            "Theo Mã Trưởng Phòng",
            "Theo Số Điện Thoại "});
            this.cbbTKPB.Location = new System.Drawing.Point(473, 138);
            this.cbbTKPB.Name = "cbbTKPB";
            this.cbbTKPB.Size = new System.Drawing.Size(121, 21);
            this.cbbTKPB.TabIndex = 26;
            // 
            // btnTimKiemPB
            // 
            this.btnTimKiemPB.Location = new System.Drawing.Point(369, 139);
            this.btnTimKiemPB.Name = "btnTimKiemPB";
            this.btnTimKiemPB.Size = new System.Drawing.Size(75, 23);
            this.btnTimKiemPB.TabIndex = 27;
            this.btnTimKiemPB.Text = "Tìm Kiếm";
            this.btnTimKiemPB.UseVisualStyleBackColor = true;
            this.btnTimKiemPB.Click += new System.EventHandler(this.btnTimKiemPB_Click);
            // 
            // frmPhongBan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(761, 498);
            this.Controls.Add(this.splitContainer1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "frmPhongBan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Phòng ban";
            this.Load += new System.EventHandler(this.frmPhongBan_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListView lvPB;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ComboBox cbbTP;
        private System.Windows.Forms.TextBox txtSDT;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnRspb;
        private System.Windows.Forms.Button btnXoapb;
        private System.Windows.Forms.Button btnSuapb;
        private System.Windows.Forms.Button btnThempb;
        private System.Windows.Forms.TextBox txtDiaChi;
        private System.Windows.Forms.TextBox txtTenpb;
        private System.Windows.Forms.TextBox txtMapb;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.Button btnTimKiemPB;
        private System.Windows.Forms.ComboBox cbbTKPB;
        private System.Windows.Forms.TextBox txtTimKiemPB;
    }
}
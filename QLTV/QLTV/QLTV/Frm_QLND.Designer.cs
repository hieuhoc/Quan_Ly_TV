namespace QLTV
{
    partial class Frm_QLND
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
            this.dgv = new System.Windows.Forms.DataGridView();
            this.btn_Them = new System.Windows.Forms.Button();
            this.btn_Sua = new System.Windows.Forms.Button();
            this.btn_Xoa = new System.Windows.Forms.Button();
            this.txt_LamMoi = new System.Windows.Forms.Button();
            this.btn_Thoat = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txt_TimKiem = new System.Windows.Forms.TextBox();
            this.rdb_TaiKhoan = new System.Windows.Forms.RadioButton();
            this.rdb_MatKhau = new System.Windows.Forms.RadioButton();
            this.rdb_Quyen = new System.Windows.Forms.RadioButton();
            this.btn_TimKiem = new System.Windows.Forms.Button();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MatKhau = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PhanQuyen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaBD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgv
            // 
            this.dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader;
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.MatKhau,
            this.PhanQuyen,
            this.MaBD});
            this.dgv.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgv.Location = new System.Drawing.Point(0, 143);
            this.dgv.Name = "dgv";
            this.dgv.Size = new System.Drawing.Size(459, 296);
            this.dgv.TabIndex = 0;
            // 
            // btn_Them
            // 
            this.btn_Them.Location = new System.Drawing.Point(12, 19);
            this.btn_Them.Name = "btn_Them";
            this.btn_Them.Size = new System.Drawing.Size(75, 23);
            this.btn_Them.TabIndex = 1;
            this.btn_Them.Text = "Thêm";
            this.btn_Them.UseVisualStyleBackColor = true;
            this.btn_Them.Click += new System.EventHandler(this.btn_Them_Click);
            // 
            // btn_Sua
            // 
            this.btn_Sua.Location = new System.Drawing.Point(102, 19);
            this.btn_Sua.Name = "btn_Sua";
            this.btn_Sua.Size = new System.Drawing.Size(75, 23);
            this.btn_Sua.TabIndex = 2;
            this.btn_Sua.Text = "Sửa";
            this.btn_Sua.UseVisualStyleBackColor = true;
            this.btn_Sua.Click += new System.EventHandler(this.btn_Sua_Click);
            // 
            // btn_Xoa
            // 
            this.btn_Xoa.Location = new System.Drawing.Point(192, 19);
            this.btn_Xoa.Name = "btn_Xoa";
            this.btn_Xoa.Size = new System.Drawing.Size(75, 23);
            this.btn_Xoa.TabIndex = 3;
            this.btn_Xoa.Text = "Xoá";
            this.btn_Xoa.UseVisualStyleBackColor = true;
            this.btn_Xoa.Click += new System.EventHandler(this.btn_Xoa_Click);
            // 
            // txt_LamMoi
            // 
            this.txt_LamMoi.Location = new System.Drawing.Point(282, 19);
            this.txt_LamMoi.Name = "txt_LamMoi";
            this.txt_LamMoi.Size = new System.Drawing.Size(75, 23);
            this.txt_LamMoi.TabIndex = 4;
            this.txt_LamMoi.Text = "Làm mới";
            this.txt_LamMoi.UseVisualStyleBackColor = true;
            this.txt_LamMoi.Click += new System.EventHandler(this.txt_LamMoi_Click);
            // 
            // btn_Thoat
            // 
            this.btn_Thoat.Location = new System.Drawing.Point(372, 19);
            this.btn_Thoat.Name = "btn_Thoat";
            this.btn_Thoat.Size = new System.Drawing.Size(75, 23);
            this.btn_Thoat.TabIndex = 5;
            this.btn_Thoat.Text = "Thoát";
            this.btn_Thoat.UseVisualStyleBackColor = true;
            this.btn_Thoat.Click += new System.EventHandler(this.btn_Thoat_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btn_Them);
            this.groupBox1.Controls.Add(this.btn_Thoat);
            this.groupBox1.Controls.Add(this.btn_Sua);
            this.groupBox1.Controls.Add(this.txt_LamMoi);
            this.groupBox1.Controls.Add(this.btn_Xoa);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(459, 49);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            // 
            // txt_TimKiem
            // 
            this.txt_TimKiem.Location = new System.Drawing.Point(127, 68);
            this.txt_TimKiem.Name = "txt_TimKiem";
            this.txt_TimKiem.Size = new System.Drawing.Size(168, 20);
            this.txt_TimKiem.TabIndex = 7;
            // 
            // rdb_TaiKhoan
            // 
            this.rdb_TaiKhoan.AutoSize = true;
            this.rdb_TaiKhoan.Location = new System.Drawing.Point(48, 97);
            this.rdb_TaiKhoan.Name = "rdb_TaiKhoan";
            this.rdb_TaiKhoan.Size = new System.Drawing.Size(74, 17);
            this.rdb_TaiKhoan.TabIndex = 8;
            this.rdb_TaiKhoan.TabStop = true;
            this.rdb_TaiKhoan.Text = "Tài Khoản";
            this.rdb_TaiKhoan.UseVisualStyleBackColor = true;
            // 
            // rdb_MatKhau
            // 
            this.rdb_MatKhau.AutoSize = true;
            this.rdb_MatKhau.Location = new System.Drawing.Point(156, 97);
            this.rdb_MatKhau.Name = "rdb_MatKhau";
            this.rdb_MatKhau.Size = new System.Drawing.Size(71, 17);
            this.rdb_MatKhau.TabIndex = 9;
            this.rdb_MatKhau.TabStop = true;
            this.rdb_MatKhau.Text = "Mật Khẩu";
            this.rdb_MatKhau.UseVisualStyleBackColor = true;
            // 
            // rdb_Quyen
            // 
            this.rdb_Quyen.AutoSize = true;
            this.rdb_Quyen.Location = new System.Drawing.Point(270, 97);
            this.rdb_Quyen.Name = "rdb_Quyen";
            this.rdb_Quyen.Size = new System.Drawing.Size(56, 17);
            this.rdb_Quyen.TabIndex = 10;
            this.rdb_Quyen.TabStop = true;
            this.rdb_Quyen.Text = "Quyền";
            this.rdb_Quyen.UseVisualStyleBackColor = true;
            // 
            // btn_TimKiem
            // 
            this.btn_TimKiem.Location = new System.Drawing.Point(326, 68);
            this.btn_TimKiem.Name = "btn_TimKiem";
            this.btn_TimKiem.Size = new System.Drawing.Size(75, 23);
            this.btn_TimKiem.TabIndex = 11;
            this.btn_TimKiem.Text = "Tìm Kiếm";
            this.btn_TimKiem.UseVisualStyleBackColor = true;
            this.btn_TimKiem.Click += new System.EventHandler(this.btn_TimKiem_Click);
            // 
            // ID
            // 
            this.ID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ID.DataPropertyName = "ID";
            this.ID.HeaderText = "Tài khoản";
            this.ID.Name = "ID";
            // 
            // MatKhau
            // 
            this.MatKhau.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.MatKhau.DataPropertyName = "MatKhau";
            this.MatKhau.HeaderText = "Mật Khẩu";
            this.MatKhau.Name = "MatKhau";
            // 
            // PhanQuyen
            // 
            this.PhanQuyen.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.PhanQuyen.DataPropertyName = "PhanQuyen";
            this.PhanQuyen.HeaderText = "Phân Quyền";
            this.PhanQuyen.Name = "PhanQuyen";
            // 
            // MaBD
            // 
            this.MaBD.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.MaBD.DataPropertyName = "MaBD";
            this.MaBD.HeaderText = "Mã bạn đọc";
            this.MaBD.Name = "MaBD";
            this.MaBD.Width = 90;
            // 
            // Frm_QLND
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(459, 439);
            this.Controls.Add(this.btn_TimKiem);
            this.Controls.Add(this.rdb_Quyen);
            this.Controls.Add(this.rdb_MatKhau);
            this.Controls.Add(this.rdb_TaiKhoan);
            this.Controls.Add(this.txt_TimKiem);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dgv);
            this.Name = "Frm_QLND";
            this.Text = "Frm_QLND";
            this.Load += new System.EventHandler(this.Frm_QLND_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.Button btn_Them;
        private System.Windows.Forms.Button btn_Sua;
        private System.Windows.Forms.Button btn_Xoa;
        private System.Windows.Forms.Button txt_LamMoi;
        private System.Windows.Forms.Button btn_Thoat;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txt_TimKiem;
        private System.Windows.Forms.RadioButton rdb_TaiKhoan;
        private System.Windows.Forms.RadioButton rdb_MatKhau;
        private System.Windows.Forms.RadioButton rdb_Quyen;
        private System.Windows.Forms.Button btn_TimKiem;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn MatKhau;
        private System.Windows.Forms.DataGridViewTextBoxColumn PhanQuyen;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaBD;
    }
}
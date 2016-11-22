namespace QLTV
{
    partial class Frm_MuonTra
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_MuonTra));
            this.btn_Refresh = new System.Windows.Forms.Button();
            this.btn_Xoa = new System.Windows.Forms.Button();
            this.btn_Sua = new System.Windows.Forms.Button();
            this.btn_Them = new System.Windows.Forms.Button();
            this.DTGV = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txt_TK_Trangthai = new System.Windows.Forms.TextBox();
            this.txt_TK_Tailieu = new System.Windows.Forms.TextBox();
            this.txt_TK_Ngaytra = new System.Windows.Forms.TextBox();
            this.txt_TK_Ngaymuon = new System.Windows.Forms.TextBox();
            this.txt_TK_Bandoc = new System.Windows.Forms.TextBox();
            this.txt_TK_Maphieu = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.DTGV)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_Refresh
            // 
            //this.btn_Refresh.Image = ((System.Drawing.Image)(resources.GetObject("btn_Refresh.Image")));
            this.btn_Refresh.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Refresh.Location = new System.Drawing.Point(213, 3);
            this.btn_Refresh.Name = "btn_Refresh";
            this.btn_Refresh.Size = new System.Drawing.Size(78, 35);
            this.btn_Refresh.TabIndex = 32;
            this.btn_Refresh.Text = "Làm mới";
            this.btn_Refresh.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Refresh.UseVisualStyleBackColor = true;
            this.btn_Refresh.Click += new System.EventHandler(this.btn_Refresh_Click);
            // 
            // btn_Xoa
            // 
            //this.btn_Xoa.Image = ((System.Drawing.Image)(resources.GetObject("btn_Xoa.Image")));
            this.btn_Xoa.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Xoa.Location = new System.Drawing.Point(143, 3);
            this.btn_Xoa.Name = "btn_Xoa";
            this.btn_Xoa.Size = new System.Drawing.Size(64, 35);
            this.btn_Xoa.TabIndex = 31;
            this.btn_Xoa.Text = "Xóa";
            this.btn_Xoa.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Xoa.UseVisualStyleBackColor = true;
            this.btn_Xoa.Click += new System.EventHandler(this.btn_Xoa_Click);
            // 
            // btn_Sua
            // 
            //this.btn_Sua.Image = ((System.Drawing.Image)(resources.GetObject("btn_Sua.Image")));
            this.btn_Sua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Sua.Location = new System.Drawing.Point(73, 3);
            this.btn_Sua.Name = "btn_Sua";
            this.btn_Sua.Size = new System.Drawing.Size(64, 35);
            this.btn_Sua.TabIndex = 30;
            this.btn_Sua.Text = "Sửa";
            this.btn_Sua.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Sua.UseVisualStyleBackColor = true;
            this.btn_Sua.Click += new System.EventHandler(this.btn_Sua_Click);
            // 
            // btn_Them
            // 
            //this.btn_Them.Image = ((System.Drawing.Image)(resources.GetObject("btn_Them.Image")));
            this.btn_Them.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Them.Location = new System.Drawing.Point(3, 3);
            this.btn_Them.Name = "btn_Them";
            this.btn_Them.Size = new System.Drawing.Size(64, 35);
            this.btn_Them.TabIndex = 29;
            this.btn_Them.Text = "Thêm";
            this.btn_Them.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Them.UseVisualStyleBackColor = true;
            this.btn_Them.Click += new System.EventHandler(this.btn_Them_Click);
            // 
            // DTGV
            // 
            this.DTGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DTGV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6,
            this.Column9});
            this.DTGV.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.DTGV.Location = new System.Drawing.Point(0, 94);
            this.DTGV.Name = "DTGV";
            this.DTGV.Size = new System.Drawing.Size(742, 292);
            this.DTGV.TabIndex = 33;
            this.DTGV.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DTGV_CellDoubleClick);
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "MaPM";
            this.Column1.HeaderText = "Mã phiếu";
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "HoTen";
            this.Column2.HeaderText = "Bạn đọc";
            this.Column2.Name = "Column2";
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "NhanDe";
            this.Column3.HeaderText = "Tài liệu";
            this.Column3.Name = "Column3";
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "TrangThai";
            this.Column4.HeaderText = "Trạng thái";
            this.Column4.Name = "Column4";
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "NgayMuon";
            this.Column5.HeaderText = "Ngày mượn";
            this.Column5.Name = "Column5";
            // 
            // Column6
            // 
            this.Column6.DataPropertyName = "NgayTra";
            this.Column6.HeaderText = "Ngày trả";
            this.Column6.Name = "Column6";
            // 
            // Column9
            // 
            this.Column9.DataPropertyName = "GhiChu";
            this.Column9.HeaderText = "Ghi chú";
            this.Column9.Name = "Column9";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txt_TK_Trangthai);
            this.groupBox1.Controls.Add(this.txt_TK_Tailieu);
            this.groupBox1.Controls.Add(this.txt_TK_Ngaytra);
            this.groupBox1.Controls.Add(this.txt_TK_Ngaymuon);
            this.groupBox1.Controls.Add(this.txt_TK_Bandoc);
            this.groupBox1.Controls.Add(this.txt_TK_Maphieu);
            this.groupBox1.Location = new System.Drawing.Point(3, 49);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(739, 43);
            this.groupBox1.TabIndex = 34;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tìm kiếm";
            // 
            // txt_TK_Trangthai
            // 
            this.txt_TK_Trangthai.Location = new System.Drawing.Point(341, 19);
            this.txt_TK_Trangthai.Name = "txt_TK_Trangthai";
            this.txt_TK_Trangthai.Size = new System.Drawing.Size(92, 20);
            this.txt_TK_Trangthai.TabIndex = 34;
            this.txt_TK_Trangthai.TextChanged += new System.EventHandler(this.txt_TK_Trangthai_TextChanged);
            // 
            // txt_TK_Tailieu
            // 
            this.txt_TK_Tailieu.Location = new System.Drawing.Point(240, 19);
            this.txt_TK_Tailieu.Name = "txt_TK_Tailieu";
            this.txt_TK_Tailieu.Size = new System.Drawing.Size(95, 20);
            this.txt_TK_Tailieu.TabIndex = 33;
            this.txt_TK_Tailieu.TextChanged += new System.EventHandler(this.txt_TK_Tailieu_TextChanged);
            // 
            // txt_TK_Ngaytra
            // 
            this.txt_TK_Ngaytra.Location = new System.Drawing.Point(541, 19);
            this.txt_TK_Ngaytra.Name = "txt_TK_Ngaytra";
            this.txt_TK_Ngaytra.Size = new System.Drawing.Size(93, 20);
            this.txt_TK_Ngaytra.TabIndex = 31;
            this.txt_TK_Ngaytra.TextChanged += new System.EventHandler(this.txt_TK_Ngaytra_TextChanged);
            // 
            // txt_TK_Ngaymuon
            // 
            this.txt_TK_Ngaymuon.Location = new System.Drawing.Point(439, 19);
            this.txt_TK_Ngaymuon.Name = "txt_TK_Ngaymuon";
            this.txt_TK_Ngaymuon.Size = new System.Drawing.Size(96, 20);
            this.txt_TK_Ngaymuon.TabIndex = 30;
            this.txt_TK_Ngaymuon.TextChanged += new System.EventHandler(this.txt_TK_Ngaymuon_TextChanged);
            // 
            // txt_TK_Bandoc
            // 
            this.txt_TK_Bandoc.Location = new System.Drawing.Point(140, 19);
            this.txt_TK_Bandoc.Name = "txt_TK_Bandoc";
            this.txt_TK_Bandoc.Size = new System.Drawing.Size(94, 20);
            this.txt_TK_Bandoc.TabIndex = 29;
            this.txt_TK_Bandoc.TextChanged += new System.EventHandler(this.txt_TK_Bandoc_TextChanged);
            // 
            // txt_TK_Maphieu
            // 
            this.txt_TK_Maphieu.Location = new System.Drawing.Point(44, 19);
            this.txt_TK_Maphieu.Name = "txt_TK_Maphieu";
            this.txt_TK_Maphieu.Size = new System.Drawing.Size(90, 20);
            this.txt_TK_Maphieu.TabIndex = 23;
            this.txt_TK_Maphieu.TextChanged += new System.EventHandler(this.txt_TK_Maphieu_TextChanged);
            // 
            // Frm_MuonTra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(742, 386);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.DTGV);
            this.Controls.Add(this.btn_Refresh);
            this.Controls.Add(this.btn_Xoa);
            this.Controls.Add(this.btn_Sua);
            this.Controls.Add(this.btn_Them);
            this.Name = "Frm_MuonTra";
            this.Text = "Mượn trả tài liệu";
            ((System.ComponentModel.ISupportInitialize)(this.DTGV)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_Refresh;
        private System.Windows.Forms.Button btn_Xoa;
        private System.Windows.Forms.Button btn_Sua;
        private System.Windows.Forms.Button btn_Them;
        private System.Windows.Forms.DataGridView DTGV;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txt_TK_Trangthai;
        private System.Windows.Forms.TextBox txt_TK_Tailieu;
        private System.Windows.Forms.TextBox txt_TK_Ngaytra;
        private System.Windows.Forms.TextBox txt_TK_Ngaymuon;
        private System.Windows.Forms.TextBox txt_TK_Bandoc;
        private System.Windows.Forms.TextBox txt_TK_Maphieu;
    }
}
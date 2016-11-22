using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace QLTV
{
    public partial class Frm_MuonTra : Form
    {
        KetNoiCSDL kn = new KetNoiCSDL();
        DataTable dt = new DataTable();
        bool check;
        int trangthai = 0;
        public Frm_MuonTra()
        {
            InitializeComponent();
            load();
        }

        void load()
        {
            string s = @"select ct.MaPM, bd.HoTen, NhanDe, pm.TrangThai, NgayMuon, NgayTra, GhiChu 
                        from BanDoc bd, PhieuMuon pm, ChitietPhieuMuon ct, TaiLieu tl
                         where pm.MaBD = bd.MaBD and pm.MaPM = ct.MaPM and ct.MaTL = tl.MaTL";
            DTGV.DataSource = kn.Get(s);
        }

        private void DTGV_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            check = true;
            trangthai = 0;
            Frm_TTMuonTra TTMT = new Frm_TTMuonTra(DTGV.Rows[e.RowIndex].Cells["Column1"].Value.ToString(), check, trangthai);
            TTMT.ShowDialog();
        }

        private void btn_Them_Click(object sender, EventArgs e)
        {
            check = false;
            trangthai = 1;
            Frm_TTMuonTra TTMT = new Frm_TTMuonTra("", check, trangthai);
            TTMT.ShowDialog();
        }

        private void btn_Sua_Click(object sender, EventArgs e)
        {
            trangthai = 2;
            check = true;
            Frm_TTMuonTra TTMT = new Frm_TTMuonTra(DTGV.CurrentRow.Cells[0].Value.ToString(), check, trangthai);
            
            TTMT.ShowDialog();
        }

        private void btn_Xoa_Click(object sender, EventArgs e)
        {
            DialogResult dlrXoa;
            dlrXoa = MessageBox.Show("Bạn chắc chắn muốn xóa?", "Xóa Tài Liệu", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dlrXoa == DialogResult.OK)
            {
                try
                {
                    dt = kn.Get(@"delete  from chitietphieumuon where mapm='" + DTGV.CurrentRow.Cells[0].Value.ToString() + "'");
                    dt = kn.Get(@"delete  from phieumuon where mapm='" + DTGV.CurrentRow.Cells[0].Value.ToString() + "'");
                    load();
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex, "Xóa không thành công");
                }
            }
        }

        private void btn_Refresh_Click(object sender, EventArgs e)
        {
            load();
        }

        private void txt_TK_Maphieu_TextChanged(object sender, EventArgs e)
        {
            string s = @"select ct.MaPM, bd.HoTen, NhanDe, pm.TrangThai, NgayMuon, NgayTra, GhiChu 
                        from BanDoc bd, PhieuMuon pm, ChitietPhieuMuon ct, TaiLieu tl
                         where pm.MaBD = bd.MaBD and pm.MaPM = ct.MaPM and ct.MaTL = tl.MaTL and ct.mapm like '%"+ txt_TK_Maphieu.Text +"%'";
            DTGV.DataSource = kn.Get(s);
        }

        private void txt_TK_Bandoc_TextChanged(object sender, EventArgs e)
        {
            string s = @"select ct.MaPM, bd.HoTen, NhanDe, pm.TrangThai, NgayMuon, NgayTra, GhiChu 
                        from BanDoc bd, PhieuMuon pm, ChitietPhieuMuon ct, TaiLieu tl
                         where pm.MaBD = bd.MaBD and pm.MaPM = ct.MaPM and ct.MaTL = tl.MaTL and bd.hoten like N'%" + txt_TK_Bandoc.Text + "%'";
            DTGV.DataSource = kn.Get(s);
        }

        private void txt_TK_Tailieu_TextChanged(object sender, EventArgs e)
        {
            string s = @"select ct.MaPM, bd.HoTen, NhanDe, pm.TrangThai, NgayMuon, NgayTra, GhiChu 
                        from BanDoc bd, PhieuMuon pm, ChitietPhieuMuon ct, TaiLieu tl
                         where pm.MaBD = bd.MaBD and pm.MaPM = ct.MaPM and ct.MaTL = tl.MaTL and tl.nhande like N'%" + txt_TK_Tailieu.Text + "%'";
            DTGV.DataSource = kn.Get(s);
        }

        private void txt_TK_Trangthai_TextChanged(object sender, EventArgs e)
        {
            string s = @"select ct.MaPM, bd.HoTen, NhanDe, pm.TrangThai, NgayMuon, NgayTra, GhiChu 
                        from BanDoc bd, PhieuMuon pm, ChitietPhieuMuon ct, TaiLieu tl
                         where pm.MaBD = bd.MaBD and pm.MaPM = ct.MaPM and ct.MaTL = tl.MaTL and pm.trangthai like N'%" + txt_TK_Trangthai.Text + "%'";
            DTGV.DataSource = kn.Get(s);
        }

        private void txt_TK_Ngaymuon_TextChanged(object sender, EventArgs e)
        {
            string s = @"select ct.MaPM, bd.HoTen, NhanDe, pm.TrangThai, NgayMuon, NgayTra, GhiChu 
                        from BanDoc bd, PhieuMuon pm, ChitietPhieuMuon ct, TaiLieu tl
                         where pm.MaBD = bd.MaBD and pm.MaPM = ct.MaPM and ct.MaTL = tl.MaTL and ct.ngaymuon like N'%" + txt_TK_Ngaymuon.Text + "%'";
            DTGV.DataSource = kn.Get(s);
        }

        private void txt_TK_Ngaytra_TextChanged(object sender, EventArgs e)
        {
            string s = @"select ct.MaPM, bd.HoTen, NhanDe, pm.TrangThai, NgayMuon, NgayTra, GhiChu 
                        from BanDoc bd, PhieuMuon pm, ChitietPhieuMuon ct, TaiLieu tl
                         where pm.MaBD = bd.MaBD and pm.MaPM = ct.MaPM and ct.MaTL = tl.MaTL and ct.ngaytra like N'%" + txt_TK_Ngaytra.Text + "%'";
            DTGV.DataSource = kn.Get(s);
        }


    }
}

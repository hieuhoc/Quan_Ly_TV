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
    public partial class Frm_Sach : Form
    {
        public int trangthai = 0;
        string maTL = "";
        public bool check = false;
        DataTable dt = new DataTable();
        KetNoiCSDL kn = new KetNoiCSDL();
        public Frm_Sach()
        {
            InitializeComponent();
        }

        private void Frm_Sach_Load(object sender, EventArgs e)
        {
            load();
        }

        public void load()
        {
            check = false;
            trangthai = 0;
            string s = "select MaTL, NhanDe, TacGia, SoLuong, DoMat, NgonNgu, TenTheLoai, TenNXB, SoTrang, TaiBan, TrangThai, NgayNhap from TaiLieu a, TheLoai b, NXB c where a.MaTheLoai = b.MaTheLoai and a.MaNXB = c.MaNXB";
            DTGV.DataSource = kn.Get(s);
        }

            
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btn_Them_Click(object sender, EventArgs e)
        {
            check = false;
            trangthai = 1;
            Frm_Sach_Details sd = new Frm_Sach_Details("", check, trangthai);
            sd.ShowDialog();
        }

        private void btn_Sua_Click(object sender, EventArgs e)
        {
            trangthai = 2;
            check = true;
            Frm_Sach_Details sd = new Frm_Sach_Details(DTGV.CurrentRow.Cells[0].Value.ToString(), check, trangthai);
            sd.ShowDialog();
        }

        private void btn_Xoa_Click(object sender, EventArgs e)
        {
            DialogResult dlrXoa;
            dlrXoa = MessageBox.Show("Bạn chắc chắn muốn xóa?", "Xóa Tài Liệu", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dlrXoa == DialogResult.OK)
            {
                dt = kn.Get(@"delete  from Tailieu where matl='" + DTGV.CurrentRow.Cells[0].Value.ToString() + "'");
                load();
            }
        }

    


        private void DTGV_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            check = true;
            trangthai = 0;
            Frm_Sach_Details sd = new Frm_Sach_Details(DTGV.Rows[e.RowIndex].Cells["MaTL"].Value.ToString(), check, trangthai);
            sd.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            load();
        }

        private void txt_TK_MaTL_TextChanged(object sender, EventArgs e)
        {
            string s = @"select MaTL, NhanDe, TacGia, SoLuong, DoMat, NgonNgu, TenTheLoai, TenNXB, SoTrang, TaiBan, TrangThai, NgayNhap from TaiLieu a, TheLoai b, NXB c where a.MaTheLoai = b.MaTheLoai and a.MaNXB = c.MaNXB and matl like '%"+txt_TK_MaTL.Text+"%'";
            DTGV.DataSource = kn.Get(s);
        }

        private void txt_TK_TenTL_TextChanged(object sender, EventArgs e)
        {
           string s = @"select MaTL, NhanDe, TacGia, SoLuong, DoMat, NgonNgu, TenTheLoai, TenNXB, SoTrang, TaiBan, TrangThai, NgayNhap from TaiLieu a, TheLoai b, NXB c where a.MaTheLoai = b.MaTheLoai and a.MaNXB = c.MaNXB and nhande like N'%" + txt_TK_TenTL.Text + "%'";
           DTGV.DataSource = kn.Get(s);
        }

        private void txt_TK_Tacgia_TextChanged(object sender, EventArgs e)
        {
           string s = @"select MaTL, NhanDe, TacGia, SoLuong, DoMat, NgonNgu, TenTheLoai, TenNXB, SoTrang, TaiBan, TrangThai, NgayNhap from TaiLieu a, TheLoai b, NXB c where a.MaTheLoai = b.MaTheLoai and a.MaNXB = c.MaNXB and tacgia like N'%" + txt_TK_Tacgia.Text + "%'";
            DTGV.DataSource = kn.Get(s);
        }

        private void txt_TK_Domat_TextChanged(object sender, EventArgs e)
        {
            string s = @"select MaTL, NhanDe, TacGia, SoLuong, DoMat, NgonNgu, TenTheLoai, TenNXB, SoTrang, TaiBan, TrangThai, NgayNhap from TaiLieu a, TheLoai b, NXB c where a.MaTheLoai = b.MaTheLoai and a.MaNXB = c.MaNXB and domat like '%" + txt_TK_Domat.Text + "%'";
           DTGV.DataSource = kn.Get(s);
        }

        private void txt_TK_Ngonngu_TextChanged(object sender, EventArgs e)
        {
           string s = @"select MaTL, NhanDe, TacGia, SoLuong, DoMat, NgonNgu, TenTheLoai, TenNXB, SoTrang, TaiBan, TrangThai, NgayNhap from TaiLieu a, TheLoai b, NXB c where a.MaTheLoai = b.MaTheLoai and a.MaNXB = c.MaNXB and ngonngu like N'%" + txt_TK_Ngonngu.Text + "%'";
           DTGV.DataSource = kn.Get(s);
        }

       

        private void txt_TK_Sotrang_TextChanged(object sender, EventArgs e)
        {
            string s = @"select MaTL, NhanDe, TacGia, SoLuong, DoMat, NgonNgu, TenTheLoai, TenNXB, SoTrang, TaiBan, TrangThai, NgayNhap from TaiLieu a, TheLoai b, NXB c where a.MaTheLoai = b.MaTheLoai and a.MaNXB = c.MaNXB and SoTrang like '%" + txt_TK_Sotrang.Text + "%'";
            DTGV.DataSource = kn.Get(s);
        }

        private void txt_TK_Taiban_TextChanged(object sender, EventArgs e)
        {
            string s = @"select MaTL, NhanDe, TacGia, SoLuong, DoMat, NgonNgu, TenTheLoai, TenNXB, SoTrang, TaiBan, TrangThai, NgayNhap from TaiLieu a, TheLoai b, NXB c where a.MaTheLoai = b.MaTheLoai and a.MaNXB = c.MaNXB and taiban like '%" + txt_TK_Taiban.Text + "%'";
            DTGV.DataSource = kn.Get(s);
        }

        private void txt_TK_Trangthai_TextChanged(object sender, EventArgs e)
        {
           string s = @"select MaTL, NhanDe, TacGia, SoLuong, DoMat, NgonNgu, TenTheLoai, TenNXB, SoTrang, TaiBan, TrangThai, NgayNhap from TaiLieu a, TheLoai b, NXB c where a.MaTheLoai = b.MaTheLoai and a.MaNXB = c.MaNXB and trangthai like '%" + txt_TK_Trangthai.Text + "%'";
           DTGV.DataSource = kn.Get(s);
        }

        private void txt_TK_Ngaynhap_TextChanged(object sender, EventArgs e)
        {
           string s = @"select MaTL, NhanDe, TacGia, SoLuong, DoMat, NgonNgu, TenTheLoai, TenNXB, SoTrang, TaiBan, TrangThai, NgayNhap from TaiLieu a, TheLoai b, NXB c where a.MaTheLoai = b.MaTheLoai and a.MaNXB = c.MaNXB and ngaynhap like '%" + txt_TK_Ngaynhap.Text + "%'";
            DTGV.DataSource = kn.Get(s);
        }

        private void txt_TK_TLoai_TextChanged(object sender, EventArgs e)
        {
            string s = @"select MaTL, NhanDe, TacGia, SoLuong, DoMat, NgonNgu, TenTheLoai, TenNXB, SoTrang, TaiBan, TrangThai, NgayNhap from TaiLieu a, TheLoai b, NXB c where a.MaTheLoai = b.MaTheLoai and a.MaNXB = c.MaNXB and tentheloai like N'%" + txt_TK_TLoai.Text + "%'";
            DTGV.DataSource = kn.Get(s);
        }

        private void txt_TK_NXB_TextChanged(object sender, EventArgs e)
        {
             string s = @"select MaTL, NhanDe, TacGia, SoLuong, DoMat, NgonNgu, TenTheLoai, TenNXB, SoTrang, TaiBan, TrangThai, NgayNhap from TaiLieu a, TheLoai b, NXB c where a.MaTheLoai = b.MaTheLoai and a.MaNXB = c.MaNXB and tenNXB like '%" + txt_TK_NXB.Text + "%'";
             DTGV.DataSource = kn.Get(s);
        }

        private void DTGV_CellDoubleClick_1(object sender, DataGridViewCellEventArgs e)
        {
            check = true;
            trangthai = 0;
            Frm_Sach_Details sd = new Frm_Sach_Details(DTGV.Rows[e.RowIndex].Cells["Column1"].Value.ToString(), check, trangthai);
            sd.ShowDialog();
        }
    }
}

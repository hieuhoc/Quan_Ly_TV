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
    public partial class Frm_Sach_Details : Form
    {
        DataTable dt = new DataTable();
        KetNoiCSDL kn = new KetNoiCSDL();
        string maTL = "";
        int trangthai = 0;
        bool check;
        public Frm_Sach_Details(string ma, bool ck, int tt)
        {
            InitializeComponent();
            maTL = ma;
            trangthai = tt;
            check = ck;
            hienthi_Form();
        }

        void hienthi_Form()
        {
            if (check == true)
            {
                if (trangthai == 0)
                {
                    lbl_Title.Text = "Xem Chi tiết";
                    btn_Huy.Enabled = btn_Luu.Enabled = false;
                    load();
                }
                else
                {
                    lbl_Title.Text = "Sửa thông tin";
                    txt_Matl.Enabled = false;
                    load_them();
                    load();
                }

            }
            else
            {
                load_them();
                lbl_Title.Text = "Thêm tài liệu";
                txt_Matl.Enabled = false;
            }
        }

        bool ktra_trong()
        {
            if (txt_Domat.Text == "" || txt_Matl.Text == "" || txt_Ngonngu.Text == "" || txt_Soluong.Text == "" || txt_SoTrang.Text == "" || txt_Tacgia.Text == "" || txt_Taiban.Text == "" || txt_Ten.Text == "" || cmb_NXB.Text == "" || cmb_TL.Text == "" || cmb_Trangthai.Text == "")
                return false;
            return true;
        }

        void load()
        {
            string s = "select MaTL, NhanDe, TacGia, SoLuong, DoMat, NgonNgu, TenTheLoai, TenNXB, SoTrang, TaiBan, TrangThai, NgayNhap from TaiLieu a, TheLoai b, NXB c where a.MaTheLoai = b.MaTheLoai and a.MaNXB = c.MaNXB and Matl = '"+maTL+"'";
            dt = kn.Get(s);
            txt_Matl.Text = dt.Rows[0][0].ToString();
            txt_Ten.Text = dt.Rows[0][1].ToString();
            txt_Tacgia.Text = dt.Rows[0][2].ToString();
            txt_Soluong.Text = dt.Rows[0][3].ToString();
            txt_Domat.Text = dt.Rows[0][4].ToString();
            txt_Ngonngu.Text = dt.Rows[0][5].ToString();
            cmb_TL.Text = dt.Rows[0][6].ToString();
            cmb_NXB.Text = dt.Rows[0][7].ToString();
            txt_SoTrang.Text = dt.Rows[0][8].ToString();
            txt_Taiban.Text = dt.Rows[0][9].ToString();
            cmb_Trangthai.Text = dt.Rows[0][10].ToString();
            DTPicker.Text = dt.Rows[0][11].ToString();
            txt_Matl.Focus();
        }
        void load_them()
        {
            txt_Matl.Focus();
            txt_Matl.Text = Ma_TuDongTang();
            cmb_NXB.DataSource = kn.Get("select MaNXB, TenNXB from NXB");
            cmb_NXB.DisplayMember = "TenNXB";
            cmb_NXB.ValueMember = "MaNXB";


            cmb_TL.DataSource = kn.Get("select * from theloai");
            cmb_TL.DisplayMember = "Tentheloai";
            cmb_TL.ValueMember = "Matheloai";
        }
        private void btn_Huy_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_Luu_Click(object sender, EventArgs e)
        {
            if (ktra_trong() == false)
            {
                MessageBox.Show("Cần nhập đầy đủ các nội dung!", "Thông báo");
                hienthi_Form();
            }
            else
            {
                if (trangthai == 1) Them();
                if (trangthai == 2) Sua();
                this.Close();
            }
        }

        void Them()
        {
            try
            {
                kn.Them_TaiLieu(txt_Matl.Text, txt_Ten.Text, txt_Tacgia.Text, txt_Soluong.Text, txt_Domat.Text, txt_Ngonngu.Text, txt_Taiban.Text, txt_SoTrang.Text, cmb_Trangthai.Text, cmb_NXB.SelectedValue.ToString(), cmb_TL.SelectedValue.ToString(), DTPicker.Text);   
            }
            catch(Exception ex)
            {
                MessageBox.Show("Lỗi: "+ex.ToString(), "Thông báo");
            }
        }

        void Sua()
        {
            try
            {
                kn.Sua_TaiLieu(txt_Matl.Text, txt_Ten.Text, txt_Tacgia.Text, txt_Soluong.Text, txt_Domat.Text, txt_Ngonngu.Text, txt_Taiban.Text, txt_SoTrang.Text, cmb_Trangthai.Text, cmb_NXB.SelectedValue.ToString(), cmb_TL.SelectedValue.ToString(), DTPicker.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.ToString(), "Thông báo");
            }
        }


        

        public string Ma_TuDongTang()
        {
            string s = "select * from TaiLieu";
            dt = kn.Get(s);
            string ma = "";
            int so = 0, i = 1000;
            for (int j = 1; j <= dt.Rows.Count - 1; j++)
            {
                ma = dt.Rows[j - 1][0].ToString();
                ma = ma.Remove(0, 3);
                so = Convert.ToInt32(ma);
                if (so != j) { so = j - 1; i = 0; break; }
            }
            if (i != 0)
            {
                ma = Convert.ToString(dt.Rows[dt.Rows.Count - 1][0].ToString());
                ma = ma.Remove(0, 3);
                so = Convert.ToInt32(ma);
            }

            ma = "MTL";
            so += 1;
            if (so < 10)
                ma = ma + "0000";
            else if (so < 100)
                ma = ma + "000";
            else if (so < 1000)
                ma = ma + "00";
            else if (so < 10000)
                ma = ma + "0";
            ma = ma + so.ToString();
            return ma;
        }
    }
}

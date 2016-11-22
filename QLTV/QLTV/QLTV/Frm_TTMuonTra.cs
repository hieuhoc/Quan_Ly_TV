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
    public partial class Frm_TTMuonTra : Form
    {
        DataTable dt = new DataTable();
        KetNoiCSDL kn = new KetNoiCSDL();
        string maPM = "";
        int trangthai = 0;
        bool check;
        public Frm_TTMuonTra(string ma, bool ck, int tt)
        {
            InitializeComponent();
            maPM = ma;
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
                    txt_Maphieu.Enabled = false;
                    //load_them();
                    load();
                }

            }
            else
            {
                load_them();
                lbl_Title.Text = "Mượn sách";
                txt_Maphieu.Enabled = false;
            }
        }

        bool ktra_trong()
        {
            if (txt_Maphieu.Text == "" || cmb_Bandoc.Text == "" || cmb_Tailieu.Text == "" || cmb_Trangthai.Text == "")
                return false;
            return true;
        }

        void load()
        {
           
            string s = @"select ct.MaPM, bd.HoTen, tl.NhanDe, pm.TrangThai, NgayMuon, NgayTra, GhiChu 
                         from BanDoc bd, PhieuMuon pm, ChitietPhieuMuon ct, TaiLieu tl
                         where pm.MaBD = bd.MaBD and pm.MaPM = ct.MaPM and ct.MaTL = tl.MaTL and ct.Mapm = '" + maPM + "'";
            dt = kn.Get(s);
            txt_Maphieu.Text = maPM;
            cmb_Bandoc.Text = dt.Rows[0][1].ToString();
            cmb_Tailieu.Text = dt.Rows[0][2].ToString();
            if (dt.Rows[0][3].ToString() == "1") cmb_Trangthai.Text = "Đã trả";
            else cmb_Trangthai.Text = "Còn mượn";
            DTPicker_Muon.Text = dt.Rows[0][4].ToString();
            DTPicker_Tra.Text = dt.Rows[0][5].ToString();
            txt_Ghichu.Text = dt.Rows[0][6].ToString();
            cmb_Bandoc.Focus();
        }

        void load_them()
        {
            cmb_Bandoc.Focus();
            maPM = Ma_TuDongTang();
            txt_Maphieu.Text = maPM;
            string s = "select Mabd, hoten from bandoc";
            cmb_Bandoc.DataSource = kn.Get(s);
            cmb_Bandoc.DisplayMember = "hoten";
            cmb_Bandoc.ValueMember = "Mabd";

            s = "select Matl, nhande from tailieu";
            cmb_Tailieu.DataSource = kn.Get(s);
            cmb_Tailieu.DisplayMember = "nhande";
            cmb_Tailieu.ValueMember = "Matl";
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
                kn.Them_TTMT(maPM, cmb_Bandoc.Text, cmb_Tailieu.Text , cmb_Trangthai.Text, DTPicker_Muon.Text, DTPicker_Tra.Text, txt_Ghichu.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.ToString(), "Thông báo");
            }
        }

        void Sua()
        {
            try
            {
                kn.Sua_TTMT(txt_Maphieu.Text, cmb_Bandoc.Text, cmb_Tailieu.Text, cmb_Trangthai.Text, DTPicker_Muon.Text, DTPicker_Tra.Text, txt_Ghichu.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.ToString(), "Thông báo");
            }
        }

        public string Ma_TuDongTang()
        {
            string s = "select * from phieumuon";
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

            ma = "PM";
            so += 1;
            if (so < 10)
                ma = ma + "000";
            else if (so < 100)
                ma = ma + "00";
            else if (so < 1000)
                ma = ma + "0";
            ma = ma + so.ToString();
            return ma;
        }

        private void cmb_Bandoc_TextChanged(object sender, EventArgs e)
        {
            string s = "select Mabd, hoten from bandoc where hoten like N'%"+ cmb_Bandoc.Text +"%'";
            cmb_Bandoc.DataSource = kn.Get(s);
            cmb_Bandoc.DisplayMember = "hoten";
            cmb_Bandoc.ValueMember = "Mabd";
        }

        private void cmb_Tailieu_TextChanged(object sender, EventArgs e)
        {
            string s = "select Matl, nhande from tailieu where nhande like N'%" + cmb_Tailieu.Text + "%'";
            cmb_Tailieu.DataSource = kn.Get(s);
            cmb_Tailieu.DisplayMember = "nhande";
            cmb_Tailieu.ValueMember = "Matl";
        }
    }
}

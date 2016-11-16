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
    public partial class Frm_DangNhap : Form
    {
        KetNoiCSDL CN = new KetNoiCSDL();
        public Frm_DangNhap()
        {
            InitializeComponent();
        }

        private void btn_DangNhap_Click(object sender, EventArgs e)
        {
            string s = "select count(*) from TaiKhoan where ID = '" + txtU.Text + "' and MatKhau = '" + txtP.Text + "'";
             string s2 = "select * from TaiKhoan where ID = '" + txtU.Text + "' and MatKhau = '" + txtP.Text + "'";
            DataTable dt = CN.Get(s);
            DataTable dt2 = CN.Get(s2);
            s = dt.Rows[0][0].ToString();
            if (txtU.Text == "" || txtP.Text == "")
            {
                MessageBox.Show("Thông tin đăng nhập sai!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtU.Focus();
            }
            if (s == "1")
            {
                int pq=int.Parse(dt2.Rows[0]["PhanQuyen"].ToString());
                this.Hide();
                Frm_Main M = new Frm_Main(pq);
                M.Show();
            }
            else
            {
                MessageBox.Show("Thông tin đăng nhập sai!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void Frm_DangNhap_Load(object sender, EventArgs e)
        {

        }
    }
}

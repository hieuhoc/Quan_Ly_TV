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
    public partial class Frm_TTBD : Form
    {
        KetNoiCSDL _con = new KetNoiCSDL();
        private int kt = 0;
        private string mabd;
        public Frm_TTBD()
        {
            InitializeComponent();
        }
        public Frm_TTBD(string ma,int k)
        {
            InitializeComponent();
            mabd = ma;
            kt = k;
        }
        public Frm_TTBD(int k)
        {
            InitializeComponent();
            kt = k;
            lbTittle.Text = "Thêm Học Sinh mới";
            btnLuu.Text = "Thêm Mới";
            txtMaHS.Text = "(Tự động tạo)";
        }
        private void Frm_TTBD_Load(object sender, EventArgs e)
        {
            if(kt>=0)
            {
                cboLop.DataSource = _con.Get(@"select malop,tenlop from Lop");
                cboLop.ValueMember = "malop";
                cboLop.DisplayMember = "tenlop";

                DataTable data = _con.Get(@"select *from BanDoc a,Lop b where a.malop=b.malop and mabd='" + mabd + "'");
                txtMaHS.Text = mabd;
                txtHoTen.Text = data.Rows[0]["HoTen"].ToString();
                cboLop.Text = data.Rows[0]["tenlop"].ToString();
                cboGT.Text = data.Rows[0]["GioiTinh"].ToString();
                txtDiaChi.Text = data.Rows[0]["diachi"].ToString();
                txtCMND.Text = data.Rows[0]["CMND"].ToString();
                txtSDT.Text = data.Rows[0]["DienThoai"].ToString();
                txtNgaySinh.Text = data.Rows[0]["ngaysinh"].ToString();
                txtEmail.Text = data.Rows[0]["Email"].ToString();
                //if (kt >1) btnLuu.Enabled = false;
            }
            else
            {
                cboLop.DataSource = _con.Get(@"select malop,tenlop from Lop");
                cboLop.ValueMember = "malop";
                cboLop.DisplayMember = "tenlop";
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if(kt>=0) _con.Sua_TTBD(txtMaHS.Text, txtHoTen.Text, cboLop.Text, cboGT.Text, txtCMND.Text, txtSDT.Text, txtDiaChi.Text, txtNgaySinh.Text,txtEmail.Text);
           else _con.Them_BD( txtHoTen.Text, cboLop.Text, cboGT.Text, txtDiaChi.Text, txtSDT.Text, txtCMND.Text, txtNgaySinh.Text,txtEmail.Text);
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
    }
}

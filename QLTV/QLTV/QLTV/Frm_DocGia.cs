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
    public partial class Frm_DocGia : Form
    {
        public static int PhanQuyen;
        private bool _dangtimma = false;
        private bool _dangtimten = false;
        private bool _dangtimlop = false;
        KetNoiCSDL _con = new KetNoiCSDL();
        //int PhanQuyen=4;
        public Frm_DocGia()
        {
            if (PhanQuyen < 4)
            {
                btnLammoi.Enabled = btnSua.Enabled = btnThem.Enabled = btnXoa.Enabled = false;
            }
            else
                btnLammoi.Enabled = btnSua.Enabled = btnThem.Enabled = btnXoa.Enabled = true;
            InitializeComponent();
        }
        public Frm_DocGia(int n)
        {
            InitializeComponent();
            //PhanQuyen = n;
        }

        private void Frm_DocGia_Load(object sender, EventArgs e)
        {
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            try
            {
                dgvDocGia.DataSource = _con.Get("select mabd,hoten,gioitinh,ngaysinh,cmnd,tenlop,diachi,dienthoai from bandoc a, lop b where a.malop=b.malop");
            }
            
                catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                }
        }

        private void txtTimMa_TextChanged(object sender, EventArgs e)
        {
            _dangtimma = true;
            string _sql = "";
            if (_dangtimma == true)
            {
                _sql = @"select mabd,hoten,gioitinh,ngaysinh,cmnd,tenlop,diachi,dienthoai from bandoc a, lop b where a.malop=b.malop and mabd like '%" + txtTimMa.Text + "%'";
                if (_dangtimten)
                {
                    _sql += " and hoten like N'%" + txtTimTen.Text + "%'";
                }
                if (_dangtimlop)
                {
                    _sql += " and tenlop like N'%" + txtTimLop.Text + "%'";
                }

                dgvDocGia.DataSource = _con.Get(_sql);
                
            }
        }

        private void txtTimTen_TextChanged(object sender, EventArgs e)
        {
            _dangtimten = true;
            string _sql = "";
            if (_dangtimten == true)
            {
                _sql = @"select mabd,hoten,gioitinh,ngaysinh,cmnd,tenlop,diachi,dienthoai from bandoc a, lop b where a.malop=b.malop and hoten like N'%" + txtTimTen.Text + "%'";
                if (_dangtimma)
                {
                    _sql += " and mabd like N'%" + txtTimMa.Text + "%'";
                }
                if (_dangtimlop)
                {
                    _sql += " and tenlop like N'%" + txtTimLop.Text + "%'";
                }
                dgvDocGia.DataSource = _con.Get(_sql);
            }
        }

        private void txtTimLop_TextChanged(object sender, EventArgs e)
        {
            _dangtimlop = true;
            string _sql = "";
            if (_dangtimlop == true)
            {
                _sql = @"select mabd,hoten,gioitinh,ngaysinh,cmnd,tenlop,diachi,dienthoai from bandoc a, lop b where a.malop=b.malop and tenlop like N'%" + txtTimLop.Text + "%'";
                if (_dangtimma)
                {
                    _sql += " and mabd like N'%" + txtTimMa.Text + "%'";
                }
                if (_dangtimten)
                {
                    _sql += " and hoten like N'%" + txtTimTen.Text + "%'";
                }
                dgvDocGia.DataSource = _con.Get(_sql);
            }
        }

        private void txtTimMa_Click(object sender, EventArgs e)
        {
            if (!_dangtimma) txtTimMa.Text = "";
        }

        private void txtTimTen_Click(object sender, EventArgs e)
        {
            if (!_dangtimten) txtTimTen.Text = "";
        }

        private void txtTimLop_Click(object sender, EventArgs e)
        {
            if (!_dangtimlop) txtTimLop.Text = "";
        }

        private void btnLammoi_Click(object sender, EventArgs e)
        {
            dgvDocGia.DataSource = _con.Get("select mabd,hoten,gioitinh,ngaysinh,cmnd,tenlop,diachi,dienthoai from bandoc a, lop b where a.malop=b.malop");
        }

        private void dgvDocGia_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0 && PhanQuyen == 4)
            {
                btnSua.Enabled = true;
                btnXoa.Enabled = true;
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {

            DialogResult dlrXoa;
            dlrXoa = MessageBox.Show("Bạn chắc chắn muốn xóa?", "Xóa học sinh", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dlrXoa == DialogResult.OK)
            {
                _con.Xoa_BD(dgvDocGia.CurrentRow.Cells[0].Value.ToString());
                dgvDocGia.DataSource = _con.Get("select mabd,hoten,gioitinh,ngaysinh,cmnd,tenlop,diachi,dienthoai from bandoc a, lop b where a.malop=b.malop");
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            Frm_TTBD frmTTBD = new Frm_TTBD(-1);
            frmTTBD.ShowDialog();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            Frm_TTBD frmTTBD = new Frm_TTBD(dgvDocGia.CurrentRow.Cells[0].Value.ToString(), PhanQuyen);
            frmTTBD.ShowDialog();

        }

        private void dgvDocGia_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                dgvDocGia.CurrentRow.Selected = true; //dữ liệu đc chọn cả dòng
            }
            catch
            { }
        }

        private void dgvDocGia_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Frm_TTBD frmTTBD = new Frm_TTBD(dgvDocGia.CurrentRow.Cells[0].Value.ToString(),PhanQuyen);
            frmTTBD.ShowDialog();
        }

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace QLTV
{
    public partial class Frm_QLND : Form
    {
        KetNoiCSDL con = new KetNoiCSDL();
        public Frm_QLND()
        {
            InitializeComponent();
        }

        private void Frm_QLND_Load(object sender, EventArgs e)
        {
            dgv.DataSource = con.Get("select * from TaiKhoan");
        }

        private void btn_Them_Click(object sender, EventArgs e)
        {
            try
            {
                //SqlConnection conn = new SqlConnection(connectionString);
                con.MoKN();
                int CurrentIndex = dgv.CurrentCell.RowIndex;
                string ID = Convert.ToString(dgv.Rows[CurrentIndex].Cells[0].Value.ToString());
                string MatKhau = Convert.ToString(dgv.Rows[CurrentIndex].Cells[1].Value.ToString());
                string PhanQuyen = Convert.ToString(dgv.Rows[CurrentIndex].Cells[2].Value.ToString());
                string MaBD = Convert.ToString(dgv.Rows[CurrentIndex].Cells[3].Value.ToString());
                //string insertStr = "Insert into Sinhvien Values('" + Masv + "','" + Holot + "','" + Ten + "','" + Phai + "','" + Ngaysinh + "','" + Makhoa + "')";
                //SqlCommand insertCmd = new SqlCommand(insertStr, con);
                //insertCmd.CommandType = CommandType.Text;
                //insertCmd.ExecuteNonQuery();
                dgv.DataSource = con.Get("Insert into TaiKhoan Values('" + ID + "','" + MatKhau + "','" + PhanQuyen + "','" + MaBD + "')");
                dgv.DataSource = con.Get("select * from TaiKhoan");
                MessageBox.Show("Bạn đã lưu thành công!", "THÔNG BÁO", MessageBoxButtons.OK);
                con.DongKN();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_Sua_Click(object sender, EventArgs e)
        {
            try
            {
                //SqlConnection conn = new SqlConnection(connectionString);
                con.MoKN();
                int CurrentIndex = dgv.CurrentCell.RowIndex;
                string ID = Convert.ToString(dgv.Rows[CurrentIndex].Cells[0].Value.ToString());
                string MatKhau = Convert.ToString(dgv.Rows[CurrentIndex].Cells[1].Value.ToString());
                string PhanQuyen = Convert.ToString(dgv.Rows[CurrentIndex].Cells[2].Value.ToString());
                string MaBD = Convert.ToString(dgv.Rows[CurrentIndex].Cells[3].Value.ToString());
                dgv.DataSource = con.Get("Update TaiKhoan set ID='" + ID + "',MatKhau='" + MatKhau + "',PhanQuyen='" + PhanQuyen + "',MaBD='" + MaBD + "' where ID='" + ID + "'");
                dgv.DataSource = con.Get("select * from TaiKhoan");
                MessageBox.Show("Bạn đã sửa thành công!", "THÔNG BÁO", MessageBoxButtons.OK);
                con.DongKN();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_Xoa_Click(object sender, EventArgs e)
        {
            try
            {
                //SqlConnection conn = new SqlConnection(connectionString);
                con.MoKN();
                int CurrentIndex = dgv.CurrentCell.RowIndex;
                string ID = Convert.ToString(dgv.Rows[CurrentIndex].Cells[0].Value.ToString());
                dgv.DataSource = con.Get("Delete from TaiKhoan where ID='" + ID + "'");
                dgv.DataSource = con.Get("select * from TaiKhoan");
                MessageBox.Show("Bạn đã xóa thành công!", "THÔNG BÁO", MessageBoxButtons.OK);
                con.DongKN();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txt_LamMoi_Click(object sender, EventArgs e)
        {
            dgv.DataSource = con.Get("select * from TaiKhoan");
        }

        private void btn_Thoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_TimKiem_Click(object sender, EventArgs e)
        {
            if (rdb_TaiKhoan.Checked == true)
            {
                dgv.DataSource = con.Get("select * from TaiKhoan where ID='" + txt_TimKiem.Text + "'");
            }
            else if (rdb_MatKhau.Checked == true)
            {
                dgv.DataSource = con.Get("select * from TaiKhoan where MatKhau='" + txt_TimKiem.Text + "'");
            }
            else if (rdb_Quyen.Checked == true)
            {
                dgv.DataSource = con.Get("select * from TaiKhoan where PhanQuyen='" + txt_TimKiem.Text + "'");
            }
        }
    }
}

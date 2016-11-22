using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QLTV
{
    class KetNoiCSDL
    {
        public SqlConnection con = null;
        public void MoKN()
        {
            try
            {
                con = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=QL_ThuVien;Integrated Security=True");
               // Data Source=.;Initial Catalog=QL_ThuVien;Integrated Security=True
                con.Open();
            }
            catch
            {
                MessageBox.Show("Không khởi tạo được kết nối!");
            }
        }
        public void DongKN()
        {
            con.Close();
        }
        public DataTable Get(string sql)
        {
            MoKN();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            DongKN();
            return dt;
        }
        public void Excecute(string sql) //hàm thực thi câu lệnh sql
        {
            try
            {
                MoKN();
                SqlCommand cmd = new SqlCommand(sql, con);
                int count;
                count = cmd.ExecuteNonQuery();
                if (count > 0)
                {
                    MessageBox.Show("Thành công", "Thông báo");
                }
                else
                {
                    MessageBox.Show("Không Thành công", "Thông báo");
                }
                DongKN();
            }
            catch(Exception e)
            {
                MessageBox.Show("Không thành công, Lỗi truy vấn!"+e.ToString());
            }
            return;
        }
        public void Xoa_BD(string mabd)
       
        {
            MoKN();
            SqlCommand cmd = new SqlCommand("Xoa_BD",con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter para = new SqlParameter("@mabd",mabd);
            cmd.Parameters.Add(para);
            try
            {
                int count = cmd.ExecuteNonQuery();
                if (count > 0) MessageBox.Show("Xóa thành công!", "Thông báo");
                else MessageBox.Show("Xóa không thành công!", "Thông báo");
            }
            catch
            {
                MessageBox.Show("Xóa không thành công!", "Thông báo");
            }
        }
        public void Sua_TTBD(string mabd, string ten, string lop, string gt, string CMND, string sdt, string diachi, string ngaysinh,string email)
        {
            MoKN();
            SqlCommand cmd = new SqlCommand("SuaBanDoc", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@mabd", mabd));
            cmd.Parameters.Add(new SqlParameter("@hoten", ten));
            cmd.Parameters.Add(new SqlParameter("@gioitinh", gt));
            cmd.Parameters.Add(new SqlParameter("@ngaysinh", DateTime.Parse(ngaysinh)));
            cmd.Parameters.Add(new SqlParameter("@diachi", diachi));
            cmd.Parameters.Add(new SqlParameter("@CMND", CMND));
            cmd.Parameters.Add(new SqlParameter("@dienthoai", sdt));
            cmd.Parameters.Add(new SqlParameter("@lop", lop));
            cmd.Parameters.Add(new SqlParameter("@Email", email));
            try
            {
                int count = cmd.ExecuteNonQuery();
                if (count > 0) MessageBox.Show("Sửa thành công!", "Thông báo");
                else MessageBox.Show("Sửa không thành công!", "Thông báo");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sửa không thành công!\n Lỗi: " + ex.ToString(), "Thông báo");
            }
            DongKN();
        }
        public void Them_BD( string ten, string lop, string gt, string diachi, string sdt, string CMND, string ngaysinh,string email)
        {
            MoKN();
            SqlCommand cmd = new SqlCommand("AddBanDoc", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@hoten", ten));
            cmd.Parameters.Add(new SqlParameter("@gioitinh", gt));
            cmd.Parameters.Add(new SqlParameter("@ngaysinh", DateTime.Parse(ngaysinh)));
            cmd.Parameters.Add(new SqlParameter("@diachi", diachi));
            cmd.Parameters.Add(new SqlParameter("@CMND", CMND));
            cmd.Parameters.Add(new SqlParameter("@dienthoai", sdt));
            cmd.Parameters.Add(new SqlParameter("@lop", lop));
            cmd.Parameters.Add(new SqlParameter("@Email", email));
            try
            {
                int count = cmd.ExecuteNonQuery();
                if (count > 0) MessageBox.Show("Thêm thành công!", "Thông báo");
                else MessageBox.Show("Thêm không thành công!", "Thông báo");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Thêm không thành công!\n Lỗi: " + ex.ToString(), "Thông báo");
            }
            DongKN();
        }
        public void Sua_TaiLieu(string matl, string nhande, string tacgia, string soluong, string domat, string ngonngu, string taiban, string sotrang, string trangthai, string manxb, string maTloai, string ngaynhap)
        {
            MoKN();
            SqlCommand cmd = new SqlCommand("Sua_sach", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@matl", matl));
            cmd.Parameters.Add(new SqlParameter("@tacgia", tacgia));
            cmd.Parameters.Add(new SqlParameter("@nhande", nhande));
            cmd.Parameters.Add(new SqlParameter("@soluong", Convert.ToInt32(soluong)));
            cmd.Parameters.Add(new SqlParameter("@domat", Convert.ToInt32(domat)));
            cmd.Parameters.Add(new SqlParameter("@ngonngu", ngonngu));
            cmd.Parameters.Add(new SqlParameter("@maTloai", maTloai));
            cmd.Parameters.Add(new SqlParameter("@manxb", manxb));
            cmd.Parameters.Add(new SqlParameter("@sotrang", Convert.ToInt32(sotrang)));
            cmd.Parameters.Add(new SqlParameter("@taiban", Convert.ToInt32(taiban)));
            cmd.Parameters.Add(new SqlParameter("@trangthai", trangthai));
            cmd.Parameters.Add(new SqlParameter("@ngaynhap", DateTime.Parse(ngaynhap)));
            try
            {
                int count = cmd.ExecuteNonQuery();
                if (count > 0) MessageBox.Show("Sửa thành công!", "Thông báo");
                else MessageBox.Show("Sửa không thành công!", "Thông báo");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sửa không thành công!\n Lỗi: " + ex.ToString(), "Thông báo");
            }
            DongKN();
        }

        public void Them_TaiLieu(string matl, string nhande, string tacgia, string soluong, string domat, string ngonngu, string taiban, string sotrang, string trangthai, string manxb, string maTloai, string ngaynhap)
        {
            MoKN();
            SqlCommand cmd = new SqlCommand("Them_sach", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@matl", matl));
            cmd.Parameters.Add(new SqlParameter("@tacgia", tacgia));
            cmd.Parameters.Add(new SqlParameter("@nhande", nhande));
            cmd.Parameters.Add(new SqlParameter("@soluong", soluong));
            cmd.Parameters.Add(new SqlParameter("@domat", domat));
            cmd.Parameters.Add(new SqlParameter("@ngonngu", ngonngu));
            cmd.Parameters.Add(new SqlParameter("@maTloai", maTloai));
            cmd.Parameters.Add(new SqlParameter("@manxb", manxb));
            cmd.Parameters.Add(new SqlParameter("@sotrang", sotrang));
            cmd.Parameters.Add(new SqlParameter("@taiban", taiban));
            cmd.Parameters.Add(new SqlParameter("@trangthai", trangthai));
            cmd.Parameters.Add(new SqlParameter("@ngaynhap", DateTime.Parse(ngaynhap)));
            try
            {
                int count = cmd.ExecuteNonQuery();
                if (count > 0) MessageBox.Show("Thêm thành công!", "Thông báo");
                else MessageBox.Show("Thêm không thành công!", "Thông báo");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Thêm không thành công!\n Lỗi: " + ex.ToString(), "Thông báo");
            }
            DongKN();
        }
        public void Sua_TTMT(string mapm, string bandoc, string nhande, string trangthai, string ngaynhap, string ngaytra, string ghichu)
        {
            int TT;
            string s;
            DataTable dt = new DataTable();
            if (trangthai == "Đã trả") TT = 1;
            else TT = 0;
            //if (TT == 0) ngaytra = "";

            s = "select mabd from bandoc where hoten = N'" + bandoc + "'";
            dt = Get(s);
            bandoc = dt.Rows[0][0].ToString();

            s = "select matl from tailieu where nhande = N'" + nhande + "'";
            dt = Get(s);
            nhande = dt.Rows[0][0].ToString();
            MoKN();
            SqlCommand cmd = new SqlCommand("Sua_TTMT", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@mapm", mapm));
            cmd.Parameters.Add(new SqlParameter("@bandoc", bandoc));
            cmd.Parameters.Add(new SqlParameter("@nhande", nhande));
            cmd.Parameters.Add(new SqlParameter("@trangthai", TT));
            cmd.Parameters.Add(new SqlParameter("@ngaynhap", DateTime.Parse(ngaynhap)));
            cmd.Parameters.Add(new SqlParameter("@ngaytra", DateTime.Parse(ngaytra)));
            cmd.Parameters.Add(new SqlParameter("@ghichu", ghichu));
            try
            {
                int count = cmd.ExecuteNonQuery();
                if (count > 0) MessageBox.Show("Sửa thành công!", "Thông báo");
                else MessageBox.Show("Sửa không thành công!", "Thông báo");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sửa không thành công!\n Lỗi: " + ex.ToString(), "Thông báo");
            }
            DongKN();
        }

        public void Them_TTMT(string mapm, string bandoc, string nhande, string trangthai, string ngaynhap, string ngaytra, string ghichu)
        {
            int TT;
            string s;
            DataTable dt = new DataTable();
            if (trangthai == "Đã trả") TT = 1;
            else TT = 0;
            //if (TT == 0) ngaytra = "";

            s = "select mabd from bandoc where hoten = N'" + bandoc + "'";
            dt = Get(s);
            bandoc = dt.Rows[0][0].ToString();

            s = "select matl from tailieu where nhande = N'" + nhande + "'";
            dt = Get(s);
            nhande = dt.Rows[0][0].ToString();

            MoKN();
            SqlCommand cmd = new SqlCommand("Them_TTMT", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@mapm", mapm));
            cmd.Parameters.Add(new SqlParameter("@bandoc", bandoc));
            cmd.Parameters.Add(new SqlParameter("@nhande", nhande));
            cmd.Parameters.Add(new SqlParameter("@trangthai", TT));
            cmd.Parameters.Add(new SqlParameter("@ngaynhap", DateTime.Parse(ngaynhap)));
            cmd.Parameters.Add(new SqlParameter("@ngaytra", DateTime.Parse(ngaytra)));
            cmd.Parameters.Add(new SqlParameter("@ghichu", ghichu));
            try
            {
                int count = cmd.ExecuteNonQuery();
                if (count > 0) MessageBox.Show("Thêm thành công!", "Thông báo");
                else MessageBox.Show("Thêm không thành công!", "Thông báo");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Thêm không thành công!\n Lỗi: " + ex.ToString(), "Thông báo");
            }
            DongKN();
        }
    }
}

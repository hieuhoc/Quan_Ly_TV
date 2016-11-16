﻿using System;
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
    }
}

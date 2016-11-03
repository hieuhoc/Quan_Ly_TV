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
    }
}

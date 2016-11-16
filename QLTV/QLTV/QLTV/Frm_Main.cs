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
    public partial class Frm_Main : Form
    {
        private int phanquyen;
        public Frm_Main()
        {
            InitializeComponent();
        }
        public Frm_Main(int s)
        {
            InitializeComponent();
            phanquyen = s;
            if(s<4)
            {
                DGToolStripMenuItem.Enabled = false;
            }
        }
        private void sáchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_Sach Sach = new Frm_Sach();
            Sach.ShowDialog();
        }

        private void độcGiảToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_DocGia DocGia = new Frm_DocGia(phanquyen);
            DocGia.ShowDialog();
        }

        private void thôngTinMượntrảToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_thongtinmuon_tra ttmuon_tra = new Frm_thongtinmuon_tra();
            ttmuon_tra.ShowDialog();
        }

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Frm_Main_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void Frm_Main_Load(object sender, EventArgs e)
        {

        }
    }
}

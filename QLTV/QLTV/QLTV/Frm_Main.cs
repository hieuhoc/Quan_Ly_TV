using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace QLTV
{
    public partial class Frm_Main : Form
    {
        private int phanquyen;
        public Frm_Main()
        {
            if (phanquyen ==4)
            {
                quảnLýNgườiDùngToolStripMenuItem.Visible = true;
            }
            else quảnLýNgườiDùngToolStripMenuItem.Visible = false;
            InitializeComponent();
        }
        public Frm_Main(int s)
        {
            InitializeComponent();
            phanquyen = s;
            if (s == 4)
            {
                quảnLýNgườiDùngToolStripMenuItem.Enabled = true;
                sáchToolStripMenuItem.Enabled = true;
                DGToolStripMenuItem.Enabled = true;
                thôngTinMượntrảToolStripMenuItem.Enabled = true;
            }
            else if (s <= 3 && s>=2 )
            {
                quảnLýNgườiDùngToolStripMenuItem.Enabled = false;
                sáchToolStripMenuItem.Enabled=true;
                DGToolStripMenuItem.Enabled = true;
                thôngTinMượntrảToolStripMenuItem.Enabled = true;
            }
            else if (s <2 )
            {
                quảnLýNgườiDùngToolStripMenuItem.Enabled = false;
                sáchToolStripMenuItem.Enabled = true;
                DGToolStripMenuItem.Enabled = false;
                thôngTinMượntrảToolStripMenuItem.Enabled = false;
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
            Frm_MuonTra ttmuon_tra = new Frm_MuonTra();
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

        private void trợGiúpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start(@"C:\Users\Hiếu Học\Documents\GitHub\Quan_Ly_TV\QLTV\HDSDSP.docx");
        }

        private void quảnLýNgườiDùngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_QLND QLND = new Frm_QLND();
            QLND.ShowDialog();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hastane_Otomasyon_Sistemi
{
    public partial class FrmGiris : Form
    {
        public FrmGiris()
        {
            InitializeComponent();
        }
        

        private void btnHastaGiris_Click(object sender, EventArgs e)
        {
            frmHastaGiris frmhastaGiris = new frmHastaGiris();
            frmhastaGiris.Show();
            this.Hide();
        }

        private void btnDoktorGiris_Click(object sender, EventArgs e)
        {
            FrmDoktorGiris frmDoktorGiris = new FrmDoktorGiris();
            frmDoktorGiris.Show();
            this.Hide();
        }

        private void btnSekreterGiris_Click(object sender, EventArgs e)
        {
            FrmSekreterGiris frmSekreterGiris = new FrmSekreterGiris();
            frmSekreterGiris.Show();
            this.Hide();
        }

        private void FrmGiris_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }
        
        private void timer1_Tick(object sender, EventArgs e)
        {
            
            label11.Text = DateTime.Now.Minute.ToString();
            label12.Text = DateTime.Now.Hour.ToString() + " : ";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}

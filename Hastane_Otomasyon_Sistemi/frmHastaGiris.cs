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

namespace Hastane_Otomasyon_Sistemi
{
    public partial class frmHastaGiris : Form
    {
        public frmHastaGiris()
        {
            InitializeComponent();
        }
        sqlBaglantisi bgl = new sqlBaglantisi();
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmHastaKayıt frmHastaKayit = new FrmHastaKayıt();
            frmHastaKayit.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && maskedTextBox2.Text != "")
            {
                SqlCommand komut = new SqlCommand("select * from Tbl_Hastalar where HastaTC=@p1 and HastaSifre=@p2", bgl.baglanti());
                komut.Parameters.AddWithValue("@p1", maskedTextBox2.Text);
                komut.Parameters.AddWithValue("@p2", textBox1.Text);
                SqlDataReader reader = komut.ExecuteReader();
                if (reader.Read())
                {
                    FrmHastaDetay frmHastaDetay = new FrmHastaDetay();
                    frmHastaDetay.tc = maskedTextBox2.Text;
                    frmHastaDetay.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Şifre veya T.C. Hatalı!");
                    maskedTextBox2.Text = "";
                    textBox1.Text = "";
                }
            }
            else MessageBox.Show("Lütfen Alanları Doldurun");
            bgl.baglanti().Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FrmGiris fr = new FrmGiris();
            fr.Show();
            this.Hide();
        }
    }
}

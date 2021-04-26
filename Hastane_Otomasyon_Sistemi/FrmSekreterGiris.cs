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
    public partial class FrmSekreterGiris : Form
    {
        public FrmSekreterGiris()
        {
            InitializeComponent();
        }
        sqlBaglantisi bgl = new sqlBaglantisi();
        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text!="" && maskedTextBox2.Text != "")
            {
                SqlCommand komut = new SqlCommand("select * from Tbl_Sekreter where SekreterTC=@p1 and SekreterSifre=@p2", bgl.baglanti());
                komut.Parameters.AddWithValue("@p1", maskedTextBox2.Text);
                komut.Parameters.AddWithValue("@p2", textBox1.Text);
                SqlDataReader rd = komut.ExecuteReader();
                if (rd.Read())
                {
                    FrmSekreterDetay frs = new FrmSekreterDetay();
                    frs.SekreterTC = maskedTextBox2.Text;
                    frs.Show();
                    this.Hide();
                }
                else MessageBox.Show("HATALI ŞİFRE VEYA T.C.");
                maskedTextBox2.Text = "";
                textBox1.Text = "";
            }
            else
                 MessageBox.Show("Lütfen Alanları Doldurun");
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

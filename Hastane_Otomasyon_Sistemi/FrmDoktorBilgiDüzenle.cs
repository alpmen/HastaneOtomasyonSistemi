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
    public partial class FrmDoktorBilgiDüzenle : Form
    {
        public FrmDoktorBilgiDüzenle()
        {
            InitializeComponent();
        }
        sqlBaglantisi bgl = new sqlBaglantisi();
        public string DoktorTcGuncelle;
        private void FrmDoktorBilgiDüzenle_Load(object sender, EventArgs e)
        {
            //Kimlik Verisini Çekme
            mskkimlikno.Text = DoktorTcGuncelle;

            //Doktorun Diğer Bilgilerini Çekme
            SqlCommand komut = new SqlCommand("select * from Tbl_Doktorlar where DoktorTC=@p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", mskkimlikno.Text);
            SqlDataReader rd = komut.ExecuteReader();
            while (rd.Read())
            {
                txtad.Text = rd[1].ToString();
                txtsoyad.Text = rd[2].ToString();
                cmbbrans.Text = rd[3].ToString();
                txtsifre.Text = rd[5].ToString();
            }
            bgl.baglanti().Close();

            //Combobaxa Branş Çekme
            SqlCommand komut2 = new SqlCommand("select BransAd from Tbl_Branslar ", bgl.baglanti());
            SqlDataReader rd2 = komut2.ExecuteReader();
            while (rd2.Read())
            {
                cmbbrans.Items.Add(rd2[0]);
            }
            bgl.baglanti().Close();


        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                txtsifre.UseSystemPasswordChar = false;
            }
            else
                txtsifre.UseSystemPasswordChar = true;

            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("update Tbl_Doktorlar set DoktorAd=@p1,DoktorSoyad=@p2,DoktorBrans=@p3,DoktorSifre=@p4 where DoktorTC=@p5", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", txtad.Text);
            komut.Parameters.AddWithValue("@p2", txtsoyad.Text);
            komut.Parameters.AddWithValue("@p3", cmbbrans.Text);
            komut.Parameters.AddWithValue("@p4", txtsifre.Text);
            komut.Parameters.AddWithValue("@p5", mskkimlikno.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Güncelleme İşlemi Başarılı");
        }
    }
}

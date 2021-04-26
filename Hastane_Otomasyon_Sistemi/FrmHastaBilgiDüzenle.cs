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
    public partial class FrmHastaBilgiDüzenle : Form
    {
        public FrmHastaBilgiDüzenle()
        {
            InitializeComponent();
        }
        public string TCno;
        sqlBaglantisi bgl = new sqlBaglantisi();
        private void FrmHastaBilgiDüzenle_Load(object sender, EventArgs e)
        {
            mskkimlikno.Text = TCno;
            SqlCommand komut = new SqlCommand("Select * from Tbl_Hastalar where HastaTC=@p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", mskkimlikno.Text);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                txtad.Text = dr[1].ToString();
                txtsoyad.Text = dr[2].ToString();
                msktelefon.Text = dr[4].ToString();
                txtsifre.Text = dr[5].ToString();
                cmbcinsiyet.Text = dr[6].ToString();
            }
        }

        private void btnkayitol_Click(object sender, EventArgs e)
        {
            SqlCommand komut2 = new SqlCommand("update Tbl_Hastalar set HastaAd=@p1,HastaSoyad=@p2,HastaTelefon=@p3,HastaSifre=@p4,HastaCinsiyet=@p5 where HastaTC=@p6",bgl.baglanti());
            komut2.Parameters.AddWithValue("@p1",txtad.Text);
            komut2.Parameters.AddWithValue("@p2",txtsoyad.Text);
            komut2.Parameters.AddWithValue("@p3",msktelefon.Text);
            komut2.Parameters.AddWithValue("@p4",txtsifre.Text);
            komut2.Parameters.AddWithValue("@p5",cmbcinsiyet.Text);
            komut2.Parameters.AddWithValue("@p6",mskkimlikno.Text);
            komut2.ExecuteNonQuery();
            MessageBox.Show("Bilgileriniz Başarıyla Güncellendi", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Warning);

        }
    }
}

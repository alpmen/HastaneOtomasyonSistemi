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
    public partial class FrmSekreterDetay : Form
    {
        public FrmSekreterDetay()
        {
            InitializeComponent();
        }

        public string SekreterTC;
        sqlBaglantisi bgl = new sqlBaglantisi();
private void FrmSekreterDetay_Load(object sender, EventArgs e)
        {
            label3.Text = SekreterTC;
            //Ad Soyad Çekme
            SqlCommand komut = new SqlCommand("select SekreterAdSoyad from Tbl_Sekreter where SekreterTC=@p1",bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", SekreterTC);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                label4.Text = dr[0].ToString();
            }
            bgl.baglanti().Close();

            //Branşları Çekme
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select BransAd from Tbl_Branslar ", bgl.baglanti());
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            //Doktorları çekme
            DataTable dt2 = new DataTable();
            SqlDataAdapter da2 = new SqlDataAdapter("select DoktorAd,DoktorSoyad,DoktorBrans,DoktorTC from Tbl_Doktorlar ", bgl.baglanti());
            da2.Fill(dt2);
            dataGridView2.DataSource = dt2;

            //Branşları getirme
            SqlCommand komutBrns = new SqlCommand("select * from Tbl_Branslar ", bgl.baglanti());
            SqlDataReader drBrns = komutBrns.ExecuteReader();
            while (drBrns.Read())
            {
                cmbbrans.Items.Add(drBrns[1]);
            }
            bgl.baglanti().Close();

            //Randevu Listesi Çekme
            SqlDataAdapter da3 = new SqlDataAdapter("select * from Tbl_Randevular", bgl.baglanti());
            DataTable dt3 = new DataTable();
            da3.Fill(dt3);
            dataGridView3.DataSource = dt3;

            //Saati çekme
            label11.Text = DateTime.Now.Minute.ToString();
            label12.Text = DateTime.Now.Hour.ToString() + " : ";
        }

        private void btnkaydet_Click(object sender, EventArgs e)
        {
            SqlCommand komutRandevu = new SqlCommand("insert into Tbl_Randevular (RandevuTarih,RandevuSaat,RandevuBrans,RandevuDoktor) values(@p1,@p2,@p3,@p4)",bgl.baglanti());
            komutRandevu.Parameters.AddWithValue("@p1",msktarih.Text);
            komutRandevu.Parameters.AddWithValue("@p2",msksaat.Text);
            komutRandevu.Parameters.AddWithValue("@p3",cmbbrans.Text);
            komutRandevu.Parameters.AddWithValue("@p4",cmbdoktor.Text);
            komutRandevu.ExecuteNonQuery();
            MessageBox.Show("Randevu Alındı");
            bgl.baglanti().Close();
        }

        private void cmbbrans_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbdoktor.Items.Clear();
            SqlCommand komutdktr = new SqlCommand("select DoktorAd,DoktorSoyad from Tbl_Doktorlar where DoktorBrans=@p1", bgl.baglanti());
            komutdktr.Parameters.AddWithValue("@p1", cmbbrans.Text);
            SqlDataReader drdktr = komutdktr.ExecuteReader();
            while (drdktr.Read())
            {
                cmbdoktor.Items.Add(drdktr[0] + " " + drdktr[1]);
            }
            bgl.baglanti().Close();

        }

        private void btnduyuruoluştur_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("insert into Tbl_Duyurular (Duyuru) values(@p1)",bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", rchDuyuru.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Duyuru Ekleme İşlemi Başarılı");
        }

        private void btndoktorpaneli_Click(object sender, EventArgs e)
        {
            FrmDoktorPaneli fr = new FrmDoktorPaneli();
            fr.Show();
        }

        private void btnbranspaneli_Click(object sender, EventArgs e)
        {
            FrmBransPaneli fr = new FrmBransPaneli();
            fr.Show();
        }

        

        private void dataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView3.SelectedCells[0].RowIndex;
            txtid.Text = dataGridView3.Rows[secilen].Cells[0].Value.ToString();
            msktarih.Text = dataGridView3.Rows[secilen].Cells[1].Value.ToString();
            msksaat.Text = dataGridView3.Rows[secilen].Cells[2].Value.ToString();
            cmbbrans.Text = dataGridView3.Rows[secilen].Cells[3].Value.ToString();
            cmbdoktor.Text = dataGridView3.Rows[secilen].Cells[4].Value.ToString();
            msktc.Text = dataGridView3.Rows[secilen].Cells[6].Value.ToString();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmDuyurular fr = new FrmDuyurular();
            fr.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FrmGiris fr = new FrmGiris();
            fr.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FrmHastaListesi fr = new FrmHastaListesi();
            fr.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //Branşları Çekme
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select BransAd from Tbl_Branslar ", bgl.baglanti());
            da.Fill(dt);
            dataGridView1.DataSource = dt;
           
            //Doktorları çekme
            DataTable dt2 = new DataTable();
            SqlDataAdapter da2 = new SqlDataAdapter("select DoktorAd,DoktorSoyad,DoktorBrans,DoktorTC from Tbl_Doktorlar ", bgl.baglanti());
            da2.Fill(dt2);
            dataGridView2.DataSource = dt2;
            
            //Randevu Listesi Çekme
            SqlDataAdapter da3 = new SqlDataAdapter("select * from Tbl_Randevular", bgl.baglanti());
            DataTable dt3 = new DataTable();
            da3.Fill(dt3);
            dataGridView3.DataSource = dt3;
        }
    }
}

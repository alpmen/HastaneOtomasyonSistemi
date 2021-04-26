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
    public partial class FrmDoktorDetay : Form
    {
        public FrmDoktorDetay()
        {
            InitializeComponent();
        }
        sqlBaglantisi bgl = new sqlBaglantisi();
        public string tcDoktor;
        private void FrmDoktorDetay_Load(object sender, EventArgs e)
        {
            label3.Text = tcDoktor;
            //Ad Soyad verisini çekme
            SqlCommand komut = new SqlCommand("select DoktorAd,DoktorSoyad from Tbl_Doktorlar where DoktorTC=@p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", tcDoktor);
            SqlDataReader rd = komut.ExecuteReader();
            while (rd.Read())
            {
                label4.Text = rd[0] + " " + rd[1];
            }
            bgl.baglanti().Close();

            //Randevuları Çekme
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select * from Tbl_Randevular where RandevuDoktor='" + label4.Text + "'", bgl.baglanti());
            da.Fill(dt);
            dataGridView1.DataSource = dt;  


        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmDoktorBilgiDüzenle fr = new FrmDoktorBilgiDüzenle();
            fr.DoktorTcGuncelle = tcDoktor;
            fr.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FrmDuyurular fr = new FrmDuyurular();
            fr.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FrmGiris frg = new FrmGiris();
            frg.Show();
            this.Hide();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            richTextBox1.Text = dataGridView1.Rows[secilen].Cells[7].Value.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FrmInternetSitesi fr = new FrmInternetSitesi();
            fr.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select * from Tbl_Randevular where RandevuDoktor='" + label4.Text + "'", bgl.baglanti());
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
    }
}

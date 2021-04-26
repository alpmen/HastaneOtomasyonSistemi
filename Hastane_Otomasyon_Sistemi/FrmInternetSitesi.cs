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
    public partial class FrmInternetSitesi : Form
    {
        public FrmInternetSitesi()
        {
            InitializeComponent();
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

        }

        private void FrmInternetSitesi_Load(object sender, EventArgs e)
        {
            webBrowser2.Navigate("http://gazi.edu.tr/");
        }
    }
}

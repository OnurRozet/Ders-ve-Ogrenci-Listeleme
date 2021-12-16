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


namespace BonusProje
{
    public partial class FrmOgrenciNotlar : Form
    {
        public FrmOgrenciNotlar()
        {
            InitializeComponent();
        }
        public string numara;

        SqlConnection baglanti = new SqlConnection("Data Source=EDGEETECH-WIN\\ONUR;Initial Catalog=BonusOkul;Integrated Security=True");
        private void FrmOgrenciNotlar_Load(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("select DersAd,Sinav1,Sinav2,Sinav3,Proje,Ortalama,Durum from Tbl_Notlar inner join  Tbl_Dersler on Tbl_Notlar.Dersid = Tbl_Dersler.Dersid where Ogrid = 1", baglanti);
            komut.Parameters.AddWithValue("@p1", numara);
            this.Text = numara.ToString();

            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            




        }
    }
}

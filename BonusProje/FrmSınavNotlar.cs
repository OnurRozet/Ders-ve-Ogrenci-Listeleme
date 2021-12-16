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
    public partial class FrmSınavNotlar : Form
    {
        public FrmSınavNotlar()
        {
            InitializeComponent();
        }
        
        DataSet1TableAdapters.Tbl_NotlarTableAdapter ds = new DataSet1TableAdapters.Tbl_NotlarTableAdapter();
        SqlConnection baglanti = new SqlConnection(@"Data Source=EDGEETECH-WIN\\ONUR;Initial Catalog=BonusOkul;Integrated Security=True");
        int sinav1, sinav2, sinav3, proje;
        double ortalama;

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            ds.NotGuncelle(byte.Parse(comboBox1.SelectedValue.ToString()), int.Parse(txtOgrencid.Text), byte.Parse(txtSinav1.Text), byte.Parse(txtSinav2.Text), byte.Parse(txtsinav3.Text), byte.Parse(txtproje.Text), decimal.Parse(txtortalama.Text), bool.Parse(txtdurum.Text), byte.Parse(notid.ToString()));
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
           
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        string durum;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtOgrencid.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            notid = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            txtSinav1.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtSinav2.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            txtsinav3.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            txtproje.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
            txtortalama.Text = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
            txtdurum.Text = dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();
        }

        int notid;

        private void FrmSınavNotlar_Load(object sender, EventArgs e)
        {
           
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select * From Tbl_Notlar", baglanti);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            comboBox1.DisplayMember = "DersAd";
            comboBox1.ValueMember = "Dersid";
            comboBox1.DataSource = dt;
            baglanti.Close();
        }

        private void btnListele_Click(object sender, EventArgs e)
        {
            sinav1 = Convert.ToInt32(txtSinav1.Text);
            sinav2 = Convert.ToInt32(txtSinav2.Text);
            sinav3 = Convert.ToInt32(txtsinav3.Text);
            proje = Convert.ToInt32(txtproje.Text);
            ortalama = (sinav1 + sinav2 + sinav3 + proje) / 4;
            txtortalama.Text = ortalama.ToString();
            if (ortalama >= 50)
            {
                txtdurum.Text = "True";
            }
            else
            {
                txtdurum.Text = "Else";
            }
        }
    }
    
        
        

       
        
        
        


        
        

        
}


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
    public partial class frmOgrenciler : Form
    {
        public frmOgrenciler()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=EDGEETECH-WIN\\ONUR;Initial Catalog=BonusOkul;Integrated Security=True");
        DataSet1TableAdapters.DataTable1TableAdapter ds = new DataSet1TableAdapters.DataTable1TableAdapter();
        private void frmOgrenciler_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ds.OgrenciListesi();
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select * From Tbl_Kulupler", baglanti);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            comboBox1.DisplayMember = "KulupAd";
            comboBox1.ValueMember = "Kulupid";
            comboBox1.DataSource = dt;
            baglanti.Close();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
        string c = "";
        private void btnEkle_Click(object sender, EventArgs e)
        {

            string c="";
            if (radioButton1.Checked==true)
            {
                c = "Kiz";
            }
            if (radioButton2.Checked==true)
            {
                c = "Erkek";    
            }
            ds.OgrenciEkle(txtOgrAd.Text, txtOgrSoyad.Text, Convert.ToInt32(comboBox1.SelectedValue.ToString()), c);
            MessageBox.Show("Ogrenci Ekleme Islemi Gerceklestirilmistir");
        }

        private void btnListele_Click(object sender, EventArgs e)
        {
            ds.OgrenciListesi();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtOgrencid.Text = comboBox1.SelectedValue.ToString();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            ds.OgrenciSilme(int.Parse(txtOgrencid.Text));
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtOgrencid.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtOgrAd.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtOgrSoyad.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            //txtOgrAd.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            //txtOgrAd.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();  cinsiyet ve kulup yap
        }
    }
}

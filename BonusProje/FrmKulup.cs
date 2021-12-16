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
    public partial class FrmKulup : Form
    {
        public FrmKulup()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=EDGEETECH-WIN\\ONUR;Initial Catalog=BonusOkul;Integrated Security=True");
        public void  Liste()
        {
            SqlDataAdapter da = new SqlDataAdapter("Select * From Tbl_Kulupler", baglanti);
            DataTable dt = new DataTable();
            
            da.Fill(dt);
            dataGridView1.DataSource = dt;

        }
        private void FrmKulup_Load(object sender, EventArgs e)
        {
            Liste();
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("insert into Tbl_Kulupler (KulupAd) values (@p1)", baglanti);
            komut.Parameters.AddWithValue("@p1", txtkulupad.Text);
            komut.ExecuteNonQuery();
            
            MessageBox.Show("Kulup Eklenmistir", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            baglanti.Close();
            Liste();
            
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            this.Hide();

            
        }

        private void pictureBox6_MouseHover(object sender, EventArgs e)
        {
            pictureBox6.BackColor = Color.Red;
        }

        private void pictureBox6_MouseLeave(object sender, EventArgs e)
        {
            pictureBox6.BackColor = Color.Transparent;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
            txtkulupad.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtkulupid.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komutsil = new SqlCommand("Delete from Tbl_Kulupler where Kulupid=@p1", baglanti);
            komutsil.Parameters.AddWithValue("@p1", txtkulupid.Text);
            komutsil.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Kulup Silinmistir", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Liste();
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komutgncl = new SqlCommand("Update Tbl_Kulupler set KulupAd=@p1 where Kulupid=@p2", baglanti);
            komutgncl.Parameters.AddWithValue("@p1", txtkulupad.Text);
            komutgncl.Parameters.AddWithValue("@p2", txtkulupid.Text);
            komutgncl.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Kaydiniz Guncellenmistir");
            Liste();
        }
    }
}

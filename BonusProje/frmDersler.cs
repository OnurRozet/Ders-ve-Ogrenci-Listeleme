using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BonusProje
{
    public partial class frmDersler : Form
    {
        public frmDersler()
        {
            InitializeComponent();
        }
        DataSet1TableAdapters.Tbl_DerslerTableAdapter ds = new DataSet1TableAdapters.Tbl_DerslerTableAdapter();
        private void frmDersler_Load(object sender, EventArgs e)
        {
           
            dataGridView1.DataSource = ds.DersListesi();


        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            FrmOgretmen fr = new FrmOgretmen();
            fr.Show();
            this.Hide();
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {

            dataGridView1.DataSource = ds.DersEkle(txtdersad.Text);
            MessageBox.Show("Ders Ekleme Isleminiz Gerceklestirilmistir");
        }

        private void btnListele_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ds.DersListesi();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
           ds.DersSilme(byte.Parse(txtdersid.Text));
            MessageBox.Show("Ders Silme Isleminiz Gerceklestirilmistir");
            
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtdersid.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtdersad.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            ds.DersGuncelle(txtdersad.Text, byte.Parse(txtdersid.Text));
            MessageBox.Show("GUncelleme Isleminiz Gerceklestirilmistir");
        }
    }
}

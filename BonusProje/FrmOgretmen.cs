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
    public partial class FrmOgretmen : Form
    {
        public FrmOgretmen()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FrmKulup fr = new FrmKulup();
            fr.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmDersler fr = new frmDersler();
            fr.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            frmOgrenciler fr = new frmOgrenciler();
            fr.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            FrmSınavNotlar fr = new FrmSınavNotlar();
            fr.Show();

        }
    }
}

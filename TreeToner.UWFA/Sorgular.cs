using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TreeToner.BusinessLogicalLayer.LiteDb;
namespace TreeToner.UWFA
{
    public partial class Sorgular : Form
    {
        KayitlarBll _kayitlarBll;
        public Sorgular()
        {
            InitializeComponent();
            _kayitlarBll = new KayitlarBll();
        }
        private void Sorgular_Load(object sender, EventArgs e)
        {
            var tumListe=_kayitlarBll.GetAll();
            var filitreliListe = tumListe.Where(I => I.sonuc == btnHazir.Text).ToList();
            groupBox2.Text = btnHazir.Text + " listesi";
            lblBaslik.Text = btnHazir.Text;
            dataGridView1.DataSource = filitreliListe;
            dataGridView1.Columns["id"].Visible = false;
            dataGridView1.Columns["musteriId"].Visible = false;
            dataGridView1.Columns["sonuc"].Visible = false;
        }
        private void btnTumKayitlar_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            dataGridView1.DataSource = _kayitlarBll.GetAll();
            groupBox2.Text = button.Text + " listesi";
            lblBaslik.Text = button.Text;
        }
        private void btnParcaBekliyor_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            var tumListe = _kayitlarBll.GetAll();
            var filitreliListe = tumListe.Where(I => I.sonuc == button.Text).ToList();
            groupBox2.Text = button.Text + " listesi";
            lblBaslik.Text = button.Text;
            dataGridView1.DataSource = filitreliListe;
        }
    }
}

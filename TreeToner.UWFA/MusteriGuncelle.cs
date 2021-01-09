using System;
using System.Windows.Forms;
using System.Xml;
using TreeToner.BusinessLogicalLayer.LiteDb;
using TreeToner.Entities;
namespace TreeToner.UWFA
{
    public partial class MusteriGuncelle : Form
    {
        MusteriBll musteriBll;
        Musteri _musteri;
        public MusteriGuncelle(Entities.Musteri musteri)
        {
            InitializeComponent();
            _musteri = musteri;
            musteriBll = new MusteriBll();
        }
     
        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            Musteri m = new Musteri();
            m.id = _musteri.id;
            m.kurumAdi = txtKurumAdi.Text;
            m.adiSoyadi = txtKisiAdi.Text;
            m.telefonI = txtTelefon.Text;
            m.telefonII = txtTelefon2.Text;
            m.mail = txtEmail.Text;
            m.adres = txtAdres.Text;
            musteriBll.Update(m);
            this.Close();
        }
        private void MusteriGuncelle_Load(object sender, EventArgs e)
        {
            txtKurumAdi.Text = _musteri.kurumAdi;
            txtKisiAdi.Text = _musteri.adiSoyadi;
            txtTelefon.Text = _musteri.telefonI;
            txtTelefon2.Text = _musteri.telefonII;
            txtEmail.Text = _musteri.mail;
            txtAdres.Text = _musteri.adres;
        }
        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

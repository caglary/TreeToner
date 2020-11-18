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
            m.adiSoyadi = txtAdSoyad.Text;
            m.telefonI = txtTelefonI.Text;
            m.telefonII = txtTelefonII.Text;
            m.telefonIII = txtTelefonIII.Text;
            m.mail = txtEmail.Text;
            m.adres = txtAdres.Text;
            musteriBll.Update(m);
            this.Close();


        }

        private void MusteriGuncelle_Load(object sender, EventArgs e)
        {

            txtAdSoyad.Text = _musteri.adiSoyadi;
            txtTelefonI.Text = _musteri.telefonI;
            txtTelefonII.Text = _musteri.telefonII;
            txtTelefonIII.Text = _musteri.telefonIII;
            txtEmail.Text = _musteri.mail;
            txtAdres.Text = _musteri.adres;

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

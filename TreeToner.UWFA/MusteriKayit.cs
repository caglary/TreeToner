using LiteDB;
using Microsoft.Office.Interop.Excel;
using System;
using System.Windows.Forms;
using TreeToner.BusinessLogicalLayer.LiteDb;
using TreeToner.Entities;

namespace TreeToner.UWFA
{
    public partial class MusteriKayit : Form
    {
        Musteri _musteri;
        Kayit activeKayit;
        KayitlarBll _kayitlarBll;
        public MusteriKayit(Musteri musteri)
        {
            InitializeComponent();
            _kayitlarBll = new KayitlarBll();
            _musteri = musteri;
        }
        private void MusteriKayit_Load(object sender, EventArgs e)
        {
            activeKayit = null;
            kayitlarListele();
            lblisim.Text = $"{_musteri.adiSoyadi} - Tel:{_musteri.telefonI}";
        }

        private void kayitlarListele()
        {

            dataGridView1.DataSource = _kayitlarBll.GetAll(_musteri.id);
            dataGridView1.Columns["id"].Visible = false;
            dataGridView1.Columns["musteriId"].Visible = false;

            lblTarih.Text = "";
            txtYaziciModel.Text = "";
            txtAciklama.Text = "";
            txtArizaBilgisi.Text = "";
            txtYaziciSeriNo.Text = "";
            txtfiyat.Text = "";
            cmbSonuc.Text = "";
            cbxUsb.Checked = false;
            cbxPower.Checked = false;

        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtYaziciModel.Text))
            {
                try
                {
                    Kayit K = new Kayit();
                    K.id = ObjectId.NewObjectId();
                    K.musteriId = _musteri.id;
                    K.yaziciModel = txtYaziciModel.Text;
                    K.yaziciSeriNo = txtYaziciSeriNo.Text;
                    K.ariza = txtArizaBilgisi.Text;
                    K.sonuc = cmbSonuc.Text;
                    if (string.IsNullOrEmpty(txtfiyat.Text))
                        K.fiyat = 0;
                    else
                    {
                        K.fiyat = Convert.ToDecimal(txtfiyat.Text);
                    }

                    K.aciklama = txtAciklama.Text;
                    if (cbxUsb.Checked == true)
                        K.usbKablosuVar = "Var";
                    else
                    {
                        K.usbKablosuVar = "Yok";
                    }

                    if (cbxPower.Checked == true)
                        K.powerKablosuVar = "Var";
                    else
                    {
                        K.powerKablosuVar = "Yok";
                    }
                    K.tarih = K.id.CreationTime;
                    _kayitlarBll.Add(K);
                    kayitlarListele();
                }
                catch (Exception exception)
                {
                    bllMesajlar.error(exception.Message);
                }
            }
            else
            {
                bllMesajlar.information("Yazıcı Model alanı boş geçilemez.");
            }

        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
          
                activeKayit.yaziciModel = txtYaziciModel.Text;
                activeKayit.yaziciSeriNo = txtYaziciSeriNo.Text;
                activeKayit.ariza = txtArizaBilgisi.Text;
                activeKayit.sonuc = cmbSonuc.Text;
                if (string.IsNullOrEmpty(txtfiyat.Text))
                    activeKayit.fiyat = 0;
                else
                {
                    activeKayit.fiyat = Convert.ToDecimal(txtfiyat.Text);
                }

                activeKayit.aciklama = txtAciklama.Text;
                if (cbxUsb.Checked == true)
                    activeKayit.usbKablosuVar = "Var";
                else
                {
                    activeKayit.usbKablosuVar = "Yok";
                }

                if (cbxPower.Checked == true)
                    activeKayit.powerKablosuVar = "Var";
                else
                {
                    activeKayit.powerKablosuVar = "Yok";
                }

                _kayitlarBll.Update(activeKayit);
                kayitlarListele();

            lblTarih.Text = activeKayit.tarih.ToString().Substring(0,10);
            txtYaziciModel.Text = activeKayit.yaziciModel;
            txtAciklama.Text = activeKayit.aciklama;
            txtArizaBilgisi.Text = activeKayit.ariza;
            txtYaziciSeriNo.Text = activeKayit.yaziciSeriNo;
            txtfiyat.Text = activeKayit.fiyat.ToString();
            cmbSonuc.Text = activeKayit.sonuc;
            if (activeKayit.usbKablosuVar == "Var") cbxUsb.Checked =true;
            else cbxUsb.Checked = false;

            if (activeKayit.powerKablosuVar == "Var") cbxPower.Checked = true;
            else cbxPower.Checked = false;

        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;

            txtYaziciModel.Text = dataGridView1.Rows[secilen].Cells["yaziciModel"].Value == null ? "" : dataGridView1.Rows[secilen].Cells["yaziciModel"].Value.ToString();

            txtYaziciSeriNo.Text = dataGridView1.Rows[secilen].Cells["yaziciSeriNo"].Value == null ? "" : dataGridView1.Rows[secilen].Cells["yaziciSeriNo"].Value.ToString();

            string cbxusb = dataGridView1.Rows[secilen].Cells["usbKablosuVar"].Value == null ? "" : dataGridView1.Rows[secilen].Cells["usbKablosuVar"].Value.ToString();
            if (cbxusb == "Var")
                cbxUsb.Checked = true;
            else
            {
                cbxUsb.Checked = false;
            }

            string cbxpower = dataGridView1.Rows[secilen].Cells["powerKablosuVar"].Value == null ? "" : dataGridView1.Rows[secilen].Cells["powerKablosuVar"].Value.ToString();
            if (cbxpower == "Var")
                cbxPower.Checked = true;
            else
            {
                cbxPower.Checked = false;
            }

            txtArizaBilgisi.Text = dataGridView1.Rows[secilen].Cells["ariza"].Value == null ? "" : dataGridView1.Rows[secilen].Cells["ariza"].Value.ToString();

            txtAciklama.Text = dataGridView1.Rows[secilen].Cells["aciklama"].Value == null ? "" : dataGridView1.Rows[secilen].Cells["aciklama"].Value.ToString();

            cmbSonuc.Text = dataGridView1.Rows[secilen].Cells["sonuc"].Value == null ? "" : dataGridView1.Rows[secilen].Cells["sonuc"].Value.ToString();

            txtfiyat.Text = dataGridView1.Rows[secilen].Cells["fiyat"].Value == null ? "" : dataGridView1.Rows[secilen].Cells["fiyat"].Value.ToString();

            lblTarih.Text = dataGridView1.Rows[secilen].Cells["tarih"].Value == null ? "" : dataGridView1.Rows[secilen].Cells["tarih"].Value.ToString().Substring(0, 10);

            var secilenKayit = _kayitlarBll.Get((ObjectId)dataGridView1.Rows[secilen].Cells["id"].Value);
            activeKayit = secilenKayit;
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (activeKayit != null)
            {
                DialogResult soru = new DialogResult();
                soru = MessageBox.Show($"{_musteri.adiSoyadi} ait kaydı silmek istiyor musunuz?", "BİLGİLENDİRME", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (soru == DialogResult.Yes)
                {
                    _kayitlarBll.Delete(activeKayit);
                    kayitlarListele();
                }
            }
            else
            {
                bllMesajlar.warning("Herhangi bir kayıt seçilmedi.");
            }
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            DialogResult soru = new DialogResult();
            soru = MessageBox.Show("Tablodaki veriler EXCEL'e aktarılacak . Devam etmek istiyor musunuz.",
                "Bilgilendirme", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (soru == DialogResult.Yes)
            {
                Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();

                excel.Visible = true;
                object Missing = Type.Missing;
                Workbook workbook = excel.Workbooks.Add(Missing);
                Worksheet sheet1 = (Worksheet)workbook.Sheets[1];

                int StartCol = 0;
                int StartRow = 1;

                for (int j = 1; j < 10; j++)
                {
                    Range myRange = (Range)sheet1.Cells[StartRow, StartCol + j];

                    
                    if (j == 1)
                        myRange.Value2 = "Yazıcı Model";
                    if (j == 2)
                        myRange.Value2 = "Yazıcı SeriNo";
                    if (j == 3)
                        myRange.Value2 = "Usb Kablo";
                    if (j == 4)
                        myRange.Value2 = "Power Kablo";
                    if (j == 5)
                        myRange.Value2 = "Arızası";
                    if (j == 6)
                        myRange.Value2 = "Açıklama";
                    if (j == 7)
                        myRange.Value2 = "İşlem Durumu";
                    if (j ==8)
                        myRange.Value2 = "Fiyat";
                    if (j == 9)
                        myRange.Value2 = "Tarih";
                }

                StartRow++;
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    for (int j = 1; j < 10; j++)
                    {

                        Range myRange = (Range)sheet1.Cells[StartRow + i, StartCol + j];
                        myRange.Value2 = dataGridView1[j+1, i].Value == null ? "" : dataGridView1[j+1, i].Value;
                        myRange.Select();
                    }

                }
            }

        }

    }
}

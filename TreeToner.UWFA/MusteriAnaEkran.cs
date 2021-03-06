﻿using LiteDB;
using Microsoft.Office.Interop.Excel;
using System;
using System.IO;
using System.Windows.Forms;
using TreeToner.Entities;
using TreeToner.BusinessLogicalLayer.LiteDb;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace TreeToner.UWFA
{
    public partial class MusteriAnaEkran : Form
    {
        MusteriBll musteriBll;
        static Musteri activeMusteri;
        public MusteriAnaEkran()
        {
            InitializeComponent();
            musteriBll = new MusteriBll();
            activeMusteri = new Musteri();
        }
        private void musteri_Load(object sender, EventArgs e)
        {
            listeGetir();
            dgwListe.Columns["id"].Visible = false;
        }
        public void listeGetir()
        {
            dgwListe.DataSource = musteriBll.GetAll();
            lblToplamKayit.Text = $"Toplam Kayıtlı Müşteri Sayısı: {musteriBll.ToplamMusteriSayisi()}";
        }
        public void listeGetir(ObjectId musteriId)
        {
            var liste = musteriBll.GetAll();
            dgwListe.DataSource = liste.FindAll(I => I.id == musteriId);
            lblToplamKayit.Text = $"Toplam Kayıtlı Müşteri Sayısı: {musteriBll.ToplamMusteriSayisi()}";
        }
        private void btnKaydet_Click(object sender, EventArgs e)
        {
            Musteri m = new Musteri();
            m.id = ObjectId.NewObjectId();
            m.kurumAdi = txtKurumAdi.Text;
            m.adiSoyadi = txtKisiAdi.Text;
            m.telefonI = txtTelefonI.Text;
            m.telefonII = txtTelefonII.Text;
            m.mail = txtEmail.Text;
            m.adres = txtAdres.Text;
            m.tarih = m.id.CreationTime;
            int result = musteriBll.Add(m);
            if (result != -1) listeGetir(m.id);
        }
        private void dataGridView1_Click(object sender, EventArgs e)
        {

            int secilen = dgwListe.SelectedCells[0].RowIndex;
            dgwListe.Tag = dgwListe.Rows[secilen].Cells["id"].Value;

            //lblMusteriNo.Text = dgwListe.Rows[secilen].Cells["id"].Value == null ? "" : dgwListe.Rows[secilen].Cells["id"].Value.ToString();
            txtKurumAdi.Text = dgwListe.Rows[secilen].Cells["kurumAdi"].Value == null ? "" : dgwListe.Rows[secilen].Cells["kurumAdi"].Value.ToString();
            txtKisiAdi.Text = dgwListe.Rows[secilen].Cells["adiSoyadi"].Value == null ? "" : dgwListe.Rows[secilen].Cells["adiSoyadi"].Value.ToString();
            txtTelefonI.Text = dgwListe.Rows[secilen].Cells["telefonI"].Value == null ? "" : dgwListe.Rows[secilen].Cells["telefonI"].Value.ToString();
            txtTelefonII.Text = dgwListe.Rows[secilen].Cells["telefonII"].Value == null ? "" : dgwListe.Rows[secilen].Cells["telefonII"].Value.ToString();
            txtEmail.Text = dgwListe.Rows[secilen].Cells["mail"].Value == null ? "" : dgwListe.Rows[secilen].Cells["mail"].Value.ToString();
            txtAdres.Text = dgwListe.Rows[secilen].Cells["adres"].Value == null ? "" : dgwListe.Rows[secilen].Cells["adres"].Value.ToString();
            var secilenMusteri = musteriBll.Get((ObjectId)dgwListe.Tag);
            activeMusteri = secilenMusteri;


        }
        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            int secilen = dgwListe.SelectedCells[0].RowIndex;
            var musteri = musteriBll.Get((ObjectId)dgwListe.Rows[secilen].Cells["id"].Value);
            MusteriGuncelle musteriGuncelleForm = new MusteriGuncelle(musteri);
            musteriGuncelleForm.ShowDialog();
            listeGetir(musteri.id);
        }
        private void btnSil_Click(object sender, EventArgs e)
        {

            DialogResult soru = new DialogResult();
            if (!string.IsNullOrEmpty(txtKurumAdi.Text))
            {
                soru = MessageBox.Show($"{txtKurumAdi.Text} isimli kaydı silmek istiyor musunuz?", "BİLGİLENDİRME", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            }
            else if (!string.IsNullOrEmpty(txtKisiAdi.Text))
            {
                soru = MessageBox.Show($"{txtKisiAdi.Text} isimli kaydı silmek istiyor musunuz?", "BİLGİLENDİRME", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            }
            else
            {
                bllMesajlar.error("Silmek istediğiniz kaydı seçiniz.");
            }



            if (soru == DialogResult.Yes)
            {
                musteriBll.Delete(activeMusteri);
                listeGetir();
                temizle();
            }
        }
        private void temizle()
        {
            txtKurumAdi.Text = "";
            txtKisiAdi.Text = "";
            txtTelefonI.Text = "";
            txtTelefonII.Text = "";
            txtAdres.Text = "";
            txtEmail.Text = "";
        }
        private void btnKayit_Click(object sender, EventArgs e)
        {
            try
            {
                if (activeMusteri.id == null)
                {
                    throw new Exception("Müşteri seçimi yapılmadı.");
                }
                MusteriKayit frm = new MusteriKayit(activeMusteri);
                Form f = System.Windows.Forms.Application.OpenForms["MusteriKayit"];
                if (f == null)
                {
                    frm.Show();
                    temizle();
                }
                else
                {
                    f.Close();
                    frm.Show();
                    temizle();
                }
            }
            catch (Exception exception)
            {
                bllMesajlar.warning(exception.Message);
            }
        }
        private void btnYedekDisari_Click(object sender, EventArgs e)
        {
            //backup işlemi
            string currentDirectory = Directory.GetCurrentDirectory();
            string file = $"{currentDirectory}\\Treetoner.db";
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            DialogResult result = folderBrowserDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                string selectedPath = folderBrowserDialog.SelectedPath;
                File.Copy(file, selectedPath + "\\yedek_Treetoner.db", true);
                bllMesajlar.warning($"{selectedPath} içerisine yedek_Treetoner.db olarak yedek alındı.");
            }
        }
        private void btnYedekIceri_Click(object sender, EventArgs e)
        {
            string currentDirectory = Directory.GetCurrentDirectory();
            string file = $"{currentDirectory}\\Treetoner.db";
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.ShowDialog();
            string filename = openFileDialog.FileName;
            File.Copy(filename, file, true);
            bllMesajlar.warning($"Yedek yükleme işlemi tamamlandı.");
            listeGetir();
        }
        private void btnSorgu_Click(object sender, EventArgs e)
        {
            Sorgular frm = new Sorgular();
            frm.Show();
        }
        private void btnGetAll_Click(object sender, EventArgs e)
        {
            listeGetir();
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
                for (int j = 1; j < 8; j++)
                {
                    Range myRange = (Range)sheet1.Cells[StartRow, StartCol + j];
                    if (j == 1)
                        myRange.Value2 = "İsim Soyisim";
                    if (j == 2)
                        myRange.Value2 = "Telefon Numarası I";
                    if (j == 3)
                        myRange.Value2 = "Telefon Numarası II";
                    if (j == 4)
                        myRange.Value2 = "Telefon Numarası III";
                    if (j == 5)
                        myRange.Value2 = "E-mail";
                    if (j == 6)
                        myRange.Value2 = "Adres";
                    if (j == 7)
                        myRange.Value2 = "Tarih";
                }
                StartRow++;
                for (int i = 0; i < dgwListe.Rows.Count; i++)
                {
                    for (int j = 1; j < 8; j++)
                    {
                        Range myRange = (Range)sheet1.Cells[StartRow + i, StartCol + j];
                        myRange.Value2 = dgwListe[j, i].Value == null ? "" : dgwListe[j, i].Value;
                        myRange.Select();
                    }
                }
            }
        }
        private void btnArama_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtArama.Text))
            {
                dgwListe.DataSource = musteriBll.Search(txtArama.Text);

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            #region Listedeki kayıtları düzenlemek için kullanıldı.
            //KayitlarBll kayitlarBll = new KayitlarBll();
            //var KayitlarListesi = kayitlarBll.GetAll();
            //var musterisiOlmayanKayit = new List<Kayit>();

            //var musteriler = musteriBll.GetAll();
            //var musterisiOlmayanKayitlar = new List<ObjectId>();
            //foreach (var printer in KayitlarListesi)
            //{

            //    Musteri m = new Musteri();
            //    m = musteriler.Where(I => I.id == printer.musteriId).FirstOrDefault();
            //    if (m == null)
            //    {
            //        musterisiOlmayanKayitlar.Add(printer.musteriId);
            //        Kayit k = new Kayit();
            //        k = KayitlarListesi.Where(I => I.id == printer.id).FirstOrDefault();
            //        musterisiOlmayanKayit.Add(k);
            //    }

            //}

            //foreach (var item in musterisiOlmayanKayit)
            //{
            //    kayitlarBll.Delete(item);
            //}
            #endregion


            #region Database içerisindeki isim ve kurum adı null olan kayıtları silme 
            //var liste = musteriBll.GetAll();
            //List< ObjectId> ids = new List<ObjectId>();
            //foreach (var item in liste)
            //{
            //    if (item.kurumAdi == null && item.adiSoyadi == null)
            //        ids.Add(item.id);

            //}

            //foreach (var itemId in ids)
            //{
            //    musteriBll.Delete(new Musteri { id = itemId });
            //}
            #endregion



        }

       
    }
}

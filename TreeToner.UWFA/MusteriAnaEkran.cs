using LiteDB;
using Microsoft.Office.Interop.Excel;
using System;
using System.IO;
using System.Windows.Forms;
using TreeToner.Entities;
using TreeToner.BusinessLogicalLayer.LiteDb;

namespace TreeToner.UWFA
{
    public partial class MusteriAnaEkran : Form
    {

        BusinessLogicalLayer.LiteDb.MusteriBll musteriBll;
        static Entities.Musteri activeMusteri;

        public MusteriAnaEkran()
        {
            InitializeComponent();
            musteriBll = new BusinessLogicalLayer.LiteDb.MusteriBll();
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

        private void btncikis_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            Musteri m = new Musteri();
            m.id = ObjectId.NewObjectId();
            m.adiSoyadi = txtAdSoyad.Text;
            m.telefonI = txtTelefonI.Text;
            m.telefonII = txtTelefonII.Text;
            m.telefonIII = txtTelefonIII.Text;
            m.mail = txtEmail.Text;
            m.adres = txtAdres.Text;
            m.tarih = m.id.CreationTime;
            musteriBll.Add(m);
            listeGetir(m.id);

        }






        private void exceleaktar()
        {


            //    var path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments));
            //    workbook.SaveAs($"{path}\\Musteri_listesi.xlsx", Missing, Missing, Missing, Missing, Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlNoChange, Missing, Missing, Missing, Missing, Missing);
            //    workbook.Close(true, Missing, Missing);
            //    excel.Quit();


            //}


        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {

            int secilen = dgwListe.SelectedCells[0].RowIndex;

            //lblMusteriNo.Text = dgwListe.Rows[secilen].Cells["id"].Value == null ? "" : dgwListe.Rows[secilen].Cells["id"].Value.ToString();

            txtAdSoyad.Text = dgwListe.Rows[secilen].Cells["adiSoyadi"].Value == null ? "" : dgwListe.Rows[secilen].Cells["adiSoyadi"].Value.ToString();

            txtTelefonI.Text = dgwListe.Rows[secilen].Cells["telefonI"].Value == null ? "" : dgwListe.Rows[secilen].Cells["telefonI"].Value.ToString();

            txtTelefonII.Text = dgwListe.Rows[secilen].Cells["telefonII"].Value == null ? "" : dgwListe.Rows[secilen].Cells["telefonII"].Value.ToString();

            txtTelefonIII.Text = dgwListe.Rows[secilen].Cells["telefonIII"].Value == null ? "" : dgwListe.Rows[secilen].Cells["telefonIII"].Value.ToString();

            txtEmail.Text = dgwListe.Rows[secilen].Cells["mail"].Value == null ? "" : dgwListe.Rows[secilen].Cells["mail"].Value.ToString();

            txtAdres.Text = dgwListe.Rows[secilen].Cells["adres"].Value == null ? "" : dgwListe.Rows[secilen].Cells["adres"].Value.ToString();

            var secilenMusteri = musteriBll.Get((ObjectId)dgwListe.Rows[secilen].Cells["id"].Value);
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
            soru = MessageBox.Show($"{txtAdSoyad.Text} kisimli kaydı silmek istiyor musunuz?", "BİLGİLENDİRME", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (soru == DialogResult.Yes)
            {
                musteriBll.Delete(activeMusteri);
                listeGetir();
                temizle();
            }

        }

        private void temizle()
        {

            txtAdSoyad.Text = "";
            txtTelefonI.Text = "";
            txtTelefonII.Text = "";
            txtTelefonIII.Text = "";
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

        private void txtAdSoyad_TextChanged(object sender, EventArgs e)
        {

            //txtTelefonI.Text = "";
            //txtTelefonII.Text = "";
            //txtTelefonIII.Text = "";
            //txtAdres.Text = "";
            //txtEmail.Text = "";
            //dataGridView1.DataSource = bll.MusteriListeAra(txtAdSoyad.Text);
            //lblMusteriNo2.Text = bll.MusteriId(txtAdSoyad.Text).ToString();

        }

        private void btnYedekDisari_Click(object sender, EventArgs e)
        {
            //backup işlemi
            string currentDirectory = Directory.GetCurrentDirectory();
            string file = $"{currentDirectory}\\Treetoner.db";
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            DialogResult result =folderBrowserDialog.ShowDialog();
            if (result==DialogResult.OK)
            {
                string selectedPath=folderBrowserDialog.SelectedPath;
                File.Copy(file, selectedPath + "\\yedek_Treetoner.db",true);
                bllMesajlar.warning($"{selectedPath} içerisine yedek_Treetoner.db olarak yedek alındı.");
            }



        }

        private void btnYedekIceri_Click(object sender, EventArgs e)
        {
            string currentDirectory = Directory.GetCurrentDirectory();
            string file = $"{currentDirectory}\\Treetoner.db";
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.ShowDialog();
            string filename=openFileDialog.FileName;
            File.Copy(filename, file, true);
            bllMesajlar.warning($"Yedek yükleme işlemi tamamlandı.");
            listeGetir();
        }


        private void btnSorgu_Click(object sender, EventArgs e)
        {
            Sorgular frm = new Sorgular();
            frm.Show();



        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

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
    }
}

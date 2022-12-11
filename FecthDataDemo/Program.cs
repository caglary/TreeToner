using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Linq;

namespace FecthDataDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {


            TumMusterileriMysqlEkle();


        }

        private static MySqlCommand Add_Kullanici(MySqlConnection conn, string kullaniciadi, string parola)
        {
            //mysql database içerisine kullanıcı ekler...
            MySqlCommand cmd;
            string sorgu = "INSERT INTO kullanici ( kullaniciadi, kullaniciparola) VALUES (@kullaniciadi,@kullaniciparola)";
            cmd = new MySqlCommand(sorgu, conn);
            cmd.Parameters.AddWithValue("@kullaniciadi", kullaniciadi);
            cmd.Parameters.AddWithValue("@kullaniciparola", parola);

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
            return cmd;
        }

        private static void veriGetir(MySqlConnection conn, out MySqlDataAdapter adapter, out DataTable Table)
        {
            //fetch data
            Table = new DataTable();
            conn.Open();
            adapter = new MySqlDataAdapter("SELECT * FROM musteri", conn);
            adapter.Fill(Table);
            foreach (DataRow dataRow in Table.Rows)
            {

                foreach (var item in dataRow.ItemArray)
                {
                    Console.WriteLine(item);
                }
            }
            conn.Close();
        }

        private static void TumMusterileriMysqlEkle()
        {
            //database içerisindeki müşterileri mysql database içerisine ekliyor.

            MySqlConnection conn = new MySqlConnection("Server=localhost;Database=treetoner;Uid=root;Pwd='';");
            MySqlCommand cmd;
            MySqlDataAdapter adapter;
            DataTable Table;

            TreeToner.DatabaseLogicalLayer.LiteDb.MusteriDll musteri = new TreeToner.DatabaseLogicalLayer.LiteDb.MusteriDll();
            TreeToner.DatabaseLogicalLayer.LiteDb.KayitlarDll kayit = new TreeToner.DatabaseLogicalLayer.LiteDb.KayitlarDll();
            var musteriler = musteri.GetAll();
            var kayitlar = kayit.GetAll();

            foreach (var musteri_ in musteriler)
            {


                int newMusteriID = 0;
                string sorgu_musteri = "INSERT INTO musteri (kurumadi , adisoyadi , telefon , telefon2 ,  mail ,  adres ,  tarih ,kullanici_id) VALUES (@kurumadi , @adisoyadi , @telefon , @telefon2 ,  @mail ,  @adres ,  @tarih ,@kullanici_id);";
                cmd = new MySqlCommand(sorgu_musteri, conn);
                cmd.Parameters.AddWithValue("@kurumadi", musteri_.kurumAdi == null ? "" : musteri_.kurumAdi);
                cmd.Parameters.AddWithValue("@adisoyadi", musteri_.adiSoyadi == null ? "" : musteri_.adiSoyadi);
                cmd.Parameters.AddWithValue("@telefon", musteri_.telefonI == null ? "" : musteri_.telefonI);
                cmd.Parameters.AddWithValue("@telefon2", musteri_.telefonII == null ? "" : musteri_.telefonII);
                cmd.Parameters.AddWithValue("@mail", musteri_.mail == null ? "" : musteri_.mail);
                cmd.Parameters.AddWithValue("@adres", musteri_.adres == null ? "" : musteri_.adres);
                cmd.Parameters.AddWithValue("@tarih", musteri_.tarih);
                cmd.Parameters.AddWithValue("@kullanici_id", 1);
                if (conn.State==ConnectionState.Closed)
                {
                    conn.Open();
                }
                int returnValue = cmd.ExecuteNonQuery();
                if (returnValue == 1)
                {
                    string sorgu_lastId = "SELECT LAST_INSERT_ID();";
                    cmd = new MySqlCommand(sorgu_lastId, conn);
                    newMusteriID = Convert.ToInt32(cmd.ExecuteScalar());

                    //müşteriye ait kayıtları getirelim 
                    var musteriye_ait_kayitlar = kayitlar.Where(I => I.musteriId == musteri_.id).ToList();


                    foreach (var musteri_kayit in musteriye_ait_kayitlar)
                    {
                        //müşteriye ait kayıtlar

                        string sorgu_kayit = "INSERT INTO  musterikayitlari ( musteri_id , yazici_model , yazici_seri_no ,  usb_kablo_durum ,  power_kablo_durum ,  ariza ,  aciklama ,  sonuc ,  fiyat ,  tarih , kullanici_id ) VALUES( @musteri_id , @yazici_model , @yazici_seri_no ,  @usb_kablo_durum ,  @power_kablo_durum ,  @ariza ,  @aciklama ,  @sonuc ,  @fiyat ,  @tarih , @kullanici_id)";

                        cmd = new MySqlCommand(sorgu_kayit, conn);

                        cmd.Parameters.AddWithValue("@musteri_id", newMusteriID);
                        cmd.Parameters.AddWithValue("@yazici_model", musteri_kayit.yaziciModel == null ? "bilinmiyor" : musteri_kayit.yaziciModel);
                        cmd.Parameters.AddWithValue("@yazici_seri_no", musteri_kayit.yaziciSeriNo == null ? "bilinmiyor" : musteri_kayit.yaziciSeriNo);
                        cmd.Parameters.AddWithValue("@usb_kablo_durum", musteri_kayit.usbKablosuVar == null ? "yok" : musteri_kayit.usbKablosuVar);
                        cmd.Parameters.AddWithValue("@power_kablo_durum", musteri_kayit.powerKablosuVar == null ? "yok" : musteri_kayit.powerKablosuVar);
                        cmd.Parameters.AddWithValue("@ariza", musteri_kayit.ariza == null ? "" : musteri_kayit.ariza);
                        cmd.Parameters.AddWithValue("@aciklama", musteri_kayit.aciklama == null ? "" : musteri_kayit.aciklama);
                        cmd.Parameters.AddWithValue("@sonuc", musteri_kayit.sonuc == null ? "" : musteri_kayit.sonuc);
                        cmd.Parameters.AddWithValue("@fiyat", musteri_kayit.fiyat == null ? 0 : musteri_kayit.fiyat);
                        cmd.Parameters.AddWithValue("@tarih", musteri_kayit.tarih == null ? DateTime.Now : musteri_kayit.tarih);
                        cmd.Parameters.AddWithValue("@kullanici_id", 1);
                        returnValue = cmd.ExecuteNonQuery();
                        if (returnValue == 0)
                        {
                            Console.WriteLine("hata var");
                        }

                        //        //Console.WriteLine(" ");
                        //string consoleData = musteri_ + "\n" + data.yaziciModel + " " + data.yaziciSeriNo + " " + data.usbKablosuVar + " " + data.powerKablosuVar + " " + data.ariza + " " + data.aciklama + " " + data.sonuc + " " + data.fiyat + " " + data.tarih.ToShortDateString();
                        //Console.WriteLine(consoleData);


                    }







                }




                //string musteri_ = item.id.ToString() + " " + item.kurumAdi + " " + item.adiSoyadi + " " + item.telefonI + " " + item.telefonII + " " + item.mail + " " + item.adres + " " + item.tarih;




               
            }

            conn.Close();


            Console.WriteLine("Bitti...");
            Console.ReadLine();



        }
    }
}
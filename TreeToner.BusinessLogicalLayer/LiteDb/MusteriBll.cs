using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using TreeToner.BusinessLogicalLayer.Abstract;
using TreeToner.DatabaseLogicalLayer.LiteDb;
using TreeToner.Entities;
namespace TreeToner.BusinessLogicalLayer.LiteDb
{
    public class MusteriBll : IBaseBll<Entities.Musteri>
    {
        DBControl _dbControl;
        MusteriDll _musteriDll;
        KayitlarBll _kayitlarBll;
        public MusteriBll()
        {
            _dbControl = new DBControl();
            _musteriDll = new MusteriDll();
            _kayitlarBll = new KayitlarBll();
        }
        public int Add(Musteri Entity)
        {
            //aynı isme sahip müşteri eklemesin.
            var liste = GetAll();
            bool isName = false;
            bool isCompanyName = false;

            if (!string.IsNullOrEmpty(Entity.adiSoyadi))
            {
                var result = liste.Where(I => I.adiSoyadi == Entity.adiSoyadi).FirstOrDefault();
                if (result == null) isName = false;
                else isName = true;
            }

            if (!string.IsNullOrEmpty(Entity.kurumAdi))
            {
                var result = liste.Where(I => I.kurumAdi == Entity.kurumAdi).FirstOrDefault();
                if (result == null) isCompanyName = false;
                else isCompanyName = true;
            }

            if (!isCompanyName && !isName)
            {
                if (string.IsNullOrEmpty(Entity.adiSoyadi) && string.IsNullOrEmpty(Entity.kurumAdi))
                {
                    return -1;
                }
                else
                {
                    _musteriDll.Add(Entity);
                    return 1;
                }


            }
            else
            {
                bllMesajlar.warning("Eklemek istediğiniz isimde kayıt mevcuttur. Başka bir isimle kaydetmeyi deneyin!");
                return -1;//Ekleme işlemi yapılmadı.
            }
        }
        public void Delete(Musteri Entity)
        {

            _musteriDll.Delete(Entity);



        }
        public Musteri Get(ObjectId IdNumber)
        {
            return _musteriDll.Get(IdNumber);
        }
        public List<Musteri> GetAll()
        {
            return _musteriDll.GetAll();
        }
        public void Update(Musteri Entity)
        {
            _musteriDll.Update(Entity);
        }
        public int ToplamMusteriSayisi()
        {
            return _musteriDll.GetAll().Count;
        }
        public List<Musteri> Search(string paramtext)
        {
            List<Musteri> musteris = new List<Musteri>();
            List<ObjectId> idList = new List<ObjectId>();

            //Musteri sayfasında arama
            IEnumerable<Musteri> searchResultAdSoyad = _musteriDll.GetAll().Where(c=>c.adiSoyadi!=null).Where(
                c => c.adiSoyadi.ToLower().Contains(paramtext.ToLower()));
            if (searchResultAdSoyad != null)
            {
                foreach (var adsoyad in searchResultAdSoyad)
                {
                    idList.Add(adsoyad.id);
                }
            }

            IEnumerable<Musteri> searchResultTelefon1 = _musteriDll.GetAll().Where(c => c.telefonI != null).Where(c => c.telefonI.ToLower().Contains(paramtext.ToLower()));
            if (searchResultTelefon1 != null)
            {
                foreach (var telefon in searchResultTelefon1)
                {
                    idList.Add(telefon.id);
                }
            }

            IEnumerable<Musteri> searchResultTelefon2 = _musteriDll.GetAll().Where(c => c.telefonII != null).Where(c => c.telefonII.ToLower().Contains(paramtext.ToLower()));
            if (searchResultTelefon2 != null)
            {
                foreach (var telefon in searchResultTelefon2)
                {
                    idList.Add(telefon.id);
                }
            }

            //Yazıcı sayfasında arama
            IEnumerable<Kayit> searchResultPrintModel = _kayitlarBll.GetAll().Where(c => c.yaziciModel != null).Where(c => c.yaziciModel.ToLower().Contains(paramtext.ToLower()));
            if (searchResultPrintModel != null)
            {
                foreach (var printModel in searchResultPrintModel)
                {
                    idList.Add(printModel.musteriId);
                }
            }

            IEnumerable<Kayit> searchResultSeriNo = _kayitlarBll.GetAll().Where(c => c.yaziciSeriNo != null).Where(c => c.yaziciSeriNo.ToLower().Contains(paramtext.ToLower()));
            if (searchResultSeriNo != null)
            {
                foreach (var seriNo in searchResultSeriNo)
                {
                    idList.Add(seriNo.musteriId);
                }
            }

















            foreach (var item in idList)
            {
                var musteri = GetAll().Where(I => I.id == item).FirstOrDefault();
                musteris.Add(musteri);
            }
            return musteris;
            //will code
            //return new List<Musteri>();

        }
    }
}

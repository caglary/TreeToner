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
        public MusteriBll()
        {
            _dbControl = new DBControl();
            _musteriDll = new MusteriDll();
        }
        public int Add(Musteri Entity)
        {
            //aynı isme sahip müşteri eklemesin.
            var liste = GetAll();
            var results = liste.Where(I => I.adiSoyadi == Entity.adiSoyadi).FirstOrDefault();
            if (results==null) 
            {
                _musteriDll.Add(Entity);
                return 1;
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
            return _musteriDll.Search(paramtext);
            
        }
    }
}

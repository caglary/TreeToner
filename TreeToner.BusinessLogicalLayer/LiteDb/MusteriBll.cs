using LiteDB;
using System;
using System.Collections.Generic;
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
        public void Add(Musteri Entity)
        {
            _musteriDll.Add(Entity);
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
    }
}

using LiteDB;
using System.Collections.Generic;
using System.Linq;
using TreeToner.Entities;

namespace TreeToner.DatabaseLogicalLayer.LiteDb
{
    public class MusteriDll : IBaseOfDLL<Musteri>
    {
        DBControl dBControl;
        public MusteriDll()
        {
            dBControl = new DBControl();
        }
        public bool Add(Musteri Entity)
        {
            using (var db = new LiteDatabase(dBControl.DatabaseConnectionString))
            {
                var collection = db.GetCollection<Musteri>();
                try
                {
                    return collection.Insert(Entity);
                }
                catch (System.Exception)
                {
                    return false;
                   
                }
               
                
            }
        }

        public bool Delete(Musteri Entity)
        {
            using (var db = new LiteDatabase(dBControl.DatabaseConnectionString))
            {
                var collection = db.GetCollection<Entities.Musteri>();
                return collection.Delete(Entity.id);
               
            }

        }

        public Musteri Get(ObjectId IdNumber)
        {
            using (var db = new LiteDatabase(dBControl.DatabaseConnectionString))
            {
                var collection = db.GetCollection<Entities.Musteri>();
                return collection.FindById(IdNumber);
            }
        }

        public List<Musteri> GetAll()
        {
            using (var db = new LiteDatabase(dBControl.DatabaseConnectionString))
            {
                var collection = db.GetCollection<Entities.Musteri>();
                return collection.FindAll().ToList();
            }
        }

        public bool Update(Musteri Entity)
        {
            using (var db = new LiteDatabase(dBControl.DatabaseConnectionString))
            {
                var collection = db.GetCollection<Entities.Musteri>();
                var m = collection.Find(I => I.id == Entity.id).FirstOrDefault();
                m.adiSoyadi = Entity.adiSoyadi;
                m.telefonI = Entity.telefonI;
                m.telefonII = Entity.telefonII;
                m.telefonIII = Entity.telefonIII;
                m.mail = Entity.mail;
                m.adres = Entity.adres;
                return collection.Update(m);
                

            }

        }
    }
}

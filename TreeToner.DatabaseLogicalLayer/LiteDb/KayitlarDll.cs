using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using TreeToner.Entities;

namespace TreeToner.DatabaseLogicalLayer.LiteDb
{
    public class KayitlarDll : IBaseOfDLL<Kayit>
    {
        DBControl dBControl;
        public KayitlarDll()
        {
            dBControl = new DBControl();
           
        }

        public bool Add(Kayit Entity)
        {
            using (var db=new LiteDatabase(dBControl.DatabaseConnectionString))
            {
                var collection = db.GetCollection<Kayit>();
                try
                {
                    return collection.Insert(Entity);
                }
                catch (Exception)
                {

                    return false;
                }
                
               
            }
        }

        public bool Delete(Kayit Entity)
        {
            using (var db = new LiteDatabase(dBControl.DatabaseConnectionString))
            {
                var collection = db.GetCollection<Kayit>();
                return collection.Delete(Entity.id);

            }
        }

     

        public Kayit Get(ObjectId idNumber)
        {
            using (var db = new LiteDatabase(dBControl.DatabaseConnectionString))
            {
                var collection = db.GetCollection<Kayit>();
                return collection.FindById(idNumber);
                
            }
        }

        public List<Kayit> GetAll()
        {
            using (var db = new LiteDatabase(dBControl.DatabaseConnectionString))
            {
                var collection = db.GetCollection<Kayit>();
                return collection.FindAll().ToList();
            }
        }
        public List<Kayit> GetAll(ObjectId idNumber)
        {
            using (var db = new LiteDatabase(dBControl.DatabaseConnectionString))
            {
                var collection = db.GetCollection<Kayit>();
                return collection.FindAll().Where(I=>I.musteriId==idNumber).ToList();
            }
        }

        public bool Update(Kayit Entity)
        {
            using (var db=new LiteDatabase(dBControl.DatabaseConnectionString))
            {
                var collection = db.GetCollection<Kayit>();
                return collection.Update(Entity);
            }
        }
    }
}

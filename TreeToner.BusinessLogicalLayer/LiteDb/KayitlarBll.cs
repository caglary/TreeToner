using LiteDB;
using System.Collections.Generic;
using TreeToner.BusinessLogicalLayer.Abstract;
using TreeToner.DatabaseLogicalLayer.LiteDb;
using TreeToner.Entities;
namespace TreeToner.BusinessLogicalLayer.LiteDb
{
    public class KayitlarBll : IBaseBll<Entities.Kayit>
    {
        KayitlarDll _dll;
        public KayitlarBll()
        {
            _dll = new KayitlarDll();
        }
        public int Add(Kayit Entity)
        {
            _dll.Add(Entity);
            return 1;
        }
        public void Delete(Kayit Entity)
        {
            _dll.Delete(Entity);
        }
       
        public Kayit Get(ObjectId IdNumber)
        {
           return _dll.Get(IdNumber);
        }
        public List<Kayit> GetAll()
        {
            return _dll.GetAll();
        }
        public List<Kayit> GetAll(ObjectId idNumber)
        {
            return _dll.GetAll(idNumber);
        }
        public void Update(Kayit Entity)
        {
            _dll.Update(Entity);
        }
    }
}

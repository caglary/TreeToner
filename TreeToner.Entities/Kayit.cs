using LiteDB;
using System;
namespace TreeToner.Entities
{
    public class Kayit
   {
       
        public ObjectId id { get; set; }
        public ObjectId musteriId { get; set; }
        public string yaziciModel { get; set; }
        public string yaziciSeriNo { get; set; }
        public string usbKablosuVar { get; set; }
        public string powerKablosuVar { get; set; }
        public string ariza { get; set; }
        public string aciklama { get; set; }
        public string sonuc { get; set; }
        public decimal fiyat { get; set; }
        public DateTime tarih { get; set; }
    }
}

using LiteDB;
using System;
namespace TreeToner.Entities
{
    public class Musteri
    {
        public ObjectId id { get; set; }
        public string adiSoyadi { get; set; }
        public string telefonI { get; set; }
        public string telefonII { get; set; }
        public string telefonIII { get; set; }
        public string mail { get; set; }
        public string adres { get; set; }
        public DateTime tarih { get; set; }
    }
}

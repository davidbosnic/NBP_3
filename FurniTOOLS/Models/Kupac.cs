using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


    public class Kupac
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string ID { get; set; }
        [BsonElement("ime")]
        public string Ime { get; set; }
        [BsonElement("prezime")]
        public string Prezime { get; set; }
        [BsonElement("email")]
        public string Email { get; set; }
        [BsonElement("sifra")]
        public string Sifra { get; set; }
        [BsonElement("grad")]
        public string Grad { get; set; }
        [BsonElement("adresa")]
        public string Adresa { get; set; }
        [BsonElement("brojtelefona")]
        public string BrojTelefona { get; set; }
        [BsonElement("mojenarudzbine")]
        public List<MongoDBRef> MojeNarudzbine_ { get; set; }
        [BsonIgnore]
        public List<Narudzbina> MojeNarudzbine { get; set; }
}
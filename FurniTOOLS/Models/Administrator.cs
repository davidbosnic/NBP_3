using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;


    public class Administrator
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string ID { get; set; }
        [BsonElement("sifra")]
        public string Sifra { get; set; }
        [BsonElement("mail")]
        public string Mail { get; set; }
        [BsonElement("ime")]
        public string Ime { get; set; }
        [BsonElement("prezime")]
        public string Prezime { get; set; }
    }
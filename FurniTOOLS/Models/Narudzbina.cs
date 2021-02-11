using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


    public class Narudzbina
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string ID { get; set; }
        [BsonElement("profilkorisnika")]
        public MongoDBRef ProfilKorisnika { get; set; }
        [BsonElement("narucenstof")]
        public Stof NarucenStof { get; set; }
        [BsonElement("narucenproizvod")]
        public Proizvod NarucenProizvod_ { get; set; }

        [BsonIgnore]
        public Kupac ProfilKorisnika_ { get; set; }
        [BsonElement("narucentipstofa")]
        public TipStofa NarucenStof_ { get; set; }
       




    [BsonElement("kolicina")]
        public int Kolicina { get; set; }
        [BsonElement("vremenarucivanja")]
        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime VremeNarucivanja { get; set; }
        [BsonElement("rokzapotvrdu")]
        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime RokZaPotvrdu { get; set; }
        [BsonElement("krajnjirokisporuke")]
        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime KrajnjiRokIsporuke { get; set; }
        [BsonElement("status")]
        public string Status { get; set; }
       
        [BsonElement("procitana")]
    public bool Procitana { get; set; }

        public double CenaBato()
        {
        double dodatak = 0;
        if (NarucenStof_ != null)
            dodatak += NarucenStof.CenaPoMetruKvadratnom * NarucenProizvod_.PovrsinaMaterijala;
        return Kolicina * (NarucenProizvod_.CenaPoKomadu + dodatak);
        return 0;
        }
    }
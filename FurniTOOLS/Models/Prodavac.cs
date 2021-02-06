using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


    public class Prodavac
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
    [BsonElement("verifikovan")]
    public bool Verifikovan { get; set; }
    [BsonElement("grad")]
    public string Grad { get; set; }
    [BsonElement("adresa")]
    public string Adresa { get; set; }
    [BsonElement("brojTelefona")]
    public string BrojTelefona { get; set; }
    [BsonElement("firma")]
    public string Firma { get; set; }
    [BsonElement("mojistofovi")]
    public List<Stof> MojiStofovi { get; set; }
    [BsonElement("mojiproizvodi")]
    public List<Proizvod> MojiProizvodi{get;set;}
    [BsonElement("mojenarudzbine")]
    public List<MongoDBRef> MojeNarudzbine { get; set; }
    [BsonIgnore]
    public List<Narudzbina> MojeNarudzbine_ { get; set; }
}
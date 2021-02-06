using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


    public class Proizvod
    {
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string ID { get; set; }
    [BsonElement("naziv")]
    public string Naziv { get; set; }
    [BsonElement("sifra")]
    public string Sifra { get; set; }
    [BsonElement("povrsinamaterijala")]
    public double PovrsinaMaterijala { get; set; }
    [BsonElement("visinabaze")]
    public int VisinaBaze { get; set; }
    [BsonElement("visinanaslona")]
    public int VisinaNaslona { get; set; }
    [BsonElement("cenapokomadu")]
    public double CenaPoKomadu { get; set; }
    [BsonElement("urlslike")]
    public string URLSlike { get; set; }
    [BsonElement("mojprodavac")]
    public MongoDBRef MojProdavac { get; set; }
    [BsonIgnore]
    public Prodavac MojProdavac_ { get; set; }


    }
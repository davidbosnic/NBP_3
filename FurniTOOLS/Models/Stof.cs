using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


    public class Stof
    {
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string ID { get; set; }
    [BsonElement("cenapometrukvadratnom")]
    public double CenaPoMetruKvadratnom { get; set; }
    [BsonElement("naziv")]
    public string Naziv { get; set; }
    [BsonElement("urlslike")]
    public string URLSlike { get; set; }
    [BsonElement("prodavac")]
    public MongoDBRef Prodavac_ { get; set; }

    [BsonIgnore]
    public Prodavac Prodavac { get; set; }

    [BsonElement("mojitipovi")]
    public List<TipStofa> MojiTipovi { get; set; }
    }
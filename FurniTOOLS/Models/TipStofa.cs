using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


    public class TipStofa
    {
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string ID { get; set; }
    [BsonElement("sifrastofa")]
    public string SifraStofa { get; set; }
    //potencijalno i ovo treba se obrise
    [BsonIgnore]
    public Stof MojiStof_ { get; set; }
    }
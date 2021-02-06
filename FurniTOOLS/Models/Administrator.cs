using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

[Table("Administratori")]
    public class Administrator
    {

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string ID { get; set; }
        [Required]
        public string Sifra { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 8)]
        public string Mail { get; set; }
        [Required]
        [StringLength(20, MinimumLength = 3,ErrorMessage="Ime mora imati minimum 3 karaktera, a najviše 20.")]
        public string Ime { get; set; }
        [Required]
        [StringLength(20, MinimumLength = 3,ErrorMessage="Prezime mora imati minimum 3 karaktera, a najviše 20.")]
        public string Prezime { get; set; }
    }
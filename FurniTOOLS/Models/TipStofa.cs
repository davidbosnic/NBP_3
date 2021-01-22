using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("TipoviStofova")]
    public class TipStofa
    {
        [Key]
        public int ID { get; set; }
        [Required]
        [StringLength(20,MinimumLength =3,ErrorMessage="Šifra štofa mora biti najmanje 3 karaktera, a najviše 20.")]
        public string SifraStofa { get; set; }
        public Stof MojiStof_ { get; set; }
    }
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("Proizvodi")]
    public class Proizvod
    {
        [Key]
        public int ID { get; set; }
        [Required]
        [StringLength(30,MinimumLength = 3,ErrorMessage ="Naziv je niz od najmanje 6, a najviše 30 karaktera!")]
        public string Naziv { get; set; }
        [Required]
        [StringLength(20, MinimumLength = 6,ErrorMessage ="Šifra je niz od 6 karaktera!")]
        public string Sifra { get; set; }
        [Required]
        [Range(0.00,20.00,ErrorMessage ="Površina materijala utrosenog za izradu proizvoda mora biti broj zaokružen na dve decimale u opsegu od 0.00 do 20.00!")]
        public double PovrsinaMaterijala { get; set; }
        [Required]
        [Range(0,200,ErrorMessage ="Visina baze je izražena u cm i ima opseg od 0 do 150")]
        public int VisinaBaze { get; set; }
        [Required]
        [Range(0, 200, ErrorMessage = "Visina naslona je izražena u cm i ima opseg od 0 do 200")]
        public int VisinaNaslona { get; set; }
        [Required]
        [Range(0.00,5000.00,ErrorMessage ="Cena po komadu je broj u opsegu od 0.00 do 5000.00. Valuta je evro!")]
        public double CenaPoKomadu { get; set; }
        [Required]
        public string URLSlike { get; set; }
        [Required]
        public Prodavac MojProdavac_ { get; set; }


    }
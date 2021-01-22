using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("Stofovi")]
    public class Stof
    {
        [Key]
        public int ID { get; set; }
        [Required]
        [Range(0.01,100.00,ErrorMessage="Cena Po Metru Kvadradnom mora biti najmanje 0.01 evra, a najviše 100 evra.")]
        public double CenaPoMetruKvadratnom { get; set; }
        [Required]
        public string Naziv { get; set; }
        [Required]
        public string URLSlike { get; set; }
        [Required]
        public int ProdavacID { get; set; }
        public List<TipStofa> MojiTipovi { get; set; }
    }
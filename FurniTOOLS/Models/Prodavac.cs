using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("Prodavci")]
    public class Prodavac
    {
        [Key]
        public int ID { get; set; }
        [Required]
        [StringLength(20, MinimumLength = 3,ErrorMessage="Ime mora imati minimum 3 karaktera, a najviše 20.")]
        public string Ime { get; set; }
        [Required]
        [StringLength(20, MinimumLength = 3,ErrorMessage="Prezime mora imati minimum 3 karaktera, a najviše 20.")]
        public string Prezime { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 8,ErrorMessage="Polje email ima minimalnu dužinu od 8 karaktera, a maksimalnu od 50. ")]
        public string Email { get; set; }
        [Required]
        public string Sifra { get; set; }
        [Required]
        public bool Verifikovan { get; set; }
        [Required]
        [StringLength(20, MinimumLength = 3,ErrorMessage="Grad mora imati minimum 3 karaktera, a najviše 20.")]
        public string Grad { get; set; }
        [Required]
        [StringLength(40, MinimumLength = 5,ErrorMessage="Adresa mora imati minimum 5 karaktera, a najviše 40.")]
        public string Adresa { get; set; }
        [Required]
        [StringLength(20, MinimumLength = 10,ErrorMessage="Broj telefona mora biti minimum 10 karaktera, a najviše 20.")]
        [RegularExpression(@"^[0-9]*$",ErrorMessage="Morate uneti brojeve!!")]
        public string BrojTelefona { get; set; }
        [StringLength(20, MinimumLength = 3,ErrorMessage="Firma mora imati minimum 3 karaktera, a najviše 20.")]
        public string Firma { get; set; }
        public List<Stof> MojiStofovi { get; set; }
        public List<Proizvod> MojiProizvodi{get;set;}
    }
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("Kupci")]
    public class Kupac
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
        [StringLength(50, MinimumLength = 8)]
        public string Email { get; set; }
        [Required]
        public string Sifra { get; set; }
        [Required]
        [StringLength(20, MinimumLength = 3,ErrorMessage="Grad mora imati minimum 3 karaktera, a najviše 20.")]
        public string Grad { get; set; }
        [Required]
        [StringLength(40, MinimumLength = 5,ErrorMessage="Adresa mora imati minimum 5 karaktera, a najviše 40.")]
        public string Adresa { get; set; }
        [Required]
        [StringLength(20, MinimumLength = 10,ErrorMessage="Broj telefona mora biti minimum 10 karaktera, a najviše 20.")]
        [RegularExpression(@"^[0-9]*$")]
        public string BrojTelefona { get; set; }
        public List<Narudzbina> MojeNarudzbine { get; set; }
    }
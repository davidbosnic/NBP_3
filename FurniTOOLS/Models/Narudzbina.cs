using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("Narudzbine")]
    public class Narudzbina
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public Kupac ProfilKorisnika_ { get; set; }
        public TipStofa NarucenStof_ { get; set; }
        [Required]
        public Proizvod NarucenProizvod_ { get; set; }
        [Required]
        [Range(1, 500,ErrorMessage="Količina je broj u opsegu od 1 do 500.")]
        public int Kolicina { get; set; }
        [Required]
        [DataType(DataType.Date,ErrorMessage="Datum je obavezno polje!")]
        public DateTime VremeNarucivanja { get; set; }
        [Required]
        [DataType(DataType.Date,ErrorMessage="Datum je obavezno polje!")]
        public DateTime RokZaPotvrdu { get; set; }
        [DataType(DataType.Date,ErrorMessage="Datum je obavezno polje!")]
        public DateTime KrajnjiRokIsporuke { get; set; }
        [Required]
        public string Status { get; set; }
        public string Napomena { get; set; }
        public bool Procitana { get; set; }

        public double CenaBato()
        {
            double dodatak=0;
            if(NarucenStof_!=null)
                dodatak+=NarucenStof_.MojiStof_.CenaPoMetruKvadratnom*NarucenProizvod_.PovrsinaMaterijala;
            return Kolicina*(NarucenProizvod_.CenaPoKomadu+dodatak);
        }
    }
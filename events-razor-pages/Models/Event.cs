using System.ComponentModel.DataAnnotations;

namespace EventsRazorApp.Models
{
    public class Event
    {
        public int Id { get; set; }
        public string Naziv { get; set; }
        public string Lokacija { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime? DatumPocetka { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime? DatumZavrsetka { get; set; }

        public int BrojPolaznika { get; set; }
        public decimal Cijena { get; set; }
        public string Opis { get; set; }
        public bool Aktivan { get; set; }
        public int VrstaId { get; set; }
    }
}
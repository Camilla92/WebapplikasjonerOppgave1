using System;
using System.ComponentModel.DataAnnotations;

namespace WebapplikasjonerOppgave1.Models
{

    public class BussBestilling
    {
        public int Id { get; set; }
        [RegularExpression(@"^[a-zA-ZæøåÆØÅ. \-]{2,20}$")]
        public string Fornavn { get; set; }
        [RegularExpression(@"^[a-zA-ZæøåÆØÅ. \-]{2,20}$")]
        public string Etternavn { get; set; }
        [RegularExpression(@"^[0-9]{8}$")]
        public string Telefonnummer { get; set; }
        [RegularExpression(@"^[0-9]{2}$")]
        public int AntallBarn { get; set; }
        [RegularExpression(@"^[0-9]{2}$")]
        public int AntallVoksne { get; set; }
        public double TotalPris { get; set; }
        public DateTime Tid { get; set; }
        public double BarnePris { get; set; }
        public double VoksenPris { get; set; }
        public string StartStasjon { get; set; }
        public string EndeStasjon { get; set; }

    }

}

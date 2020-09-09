using System;
namespace WebapplikasjonerOppgave1.Models
{

    public class BussBestilling
    {
        public int Id { get; set; }
        public string Fornavn { get; set; }
        public string Etternavn { get; set; }
        public string Telefonnummer { get; set; }
        public int AntallBarn { get; set; }
        public int AntallVoksne { get; set; }
        public double TotalPris { get; set; }
        public DateTime Tid { get; set; }
        public double BarnePris { get; set; }
        public double VoksenPris { get; set; }
        public string StartStasjon { get; set; }
        public string EndeStasjon { get; set; }

    }

}

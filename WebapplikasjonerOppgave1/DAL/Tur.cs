using System;
namespace WebapplikasjonerOppgave1.DAL
{
    public class Tur
    {
        public int TurId { get; set; }
        public Stasjon StartStasjon { get; set; }
        public Stasjon EndeStasjon { get; set; }
        public DateTime Tid { get; set; }
        public double BarnePris { get; set; }
        public double VoksenPris { get; set; }
    }
}

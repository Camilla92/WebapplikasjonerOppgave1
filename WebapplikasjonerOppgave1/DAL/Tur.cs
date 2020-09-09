using System;
namespace WebapplikasjonerOppgave1.DAL
{
    public class Tur
    {
        public int TurId { get; set; }
        public Stasjon StartStasjon { get; set; }
        public Stasjon EndeStasjon { get; set; }
        public DateTime tid { get; set; }
        public double barnePris { get; set; }
        public double voksenPris { get; set; }
    }
}

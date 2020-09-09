using System;
namespace WebapplikasjonerOppgave1.DAL
{
    public class Bestilling
    {
        public int BId {get; set;}
        public virtual Kunde kunde { get; set; }
        public int antallBarn { get; set; }
        public int antallVoksne { get; set; }
        public double totalPris { get; set; }
        public virtual Tur tur { get; set; }
        public String test { get; set; }
        //test test Nikola
    }
}

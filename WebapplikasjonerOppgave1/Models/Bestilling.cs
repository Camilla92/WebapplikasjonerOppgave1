using System;
namespace WebapplikasjonerOppgave1.Models
{

    public class Bestilling
    {
        public string Navn { get; set; }
        public string Telefonnummer { get; set; }
        public Stasjon StartStasjon { get; set; }
        public Stasjon EndeStasjon { get; set; }
        public DateTime Tid { get; set; }

    }

}

using System;
namespace WebapplikasjonerOppgave1.Models
{

        public class Bestilling
        {
            public string Navn { get; set; }
            public string Telefonnummer { get; set; }
            public string StartStasjon { get; set; }
            public string EndeStasjon { get; set; }
            public DateTime Tid { get; set; }
        }
    
}

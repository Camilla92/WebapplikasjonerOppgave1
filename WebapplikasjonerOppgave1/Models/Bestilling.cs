using System;
namespace WebapplikasjonerOppgave1.Models
{
    public class Bestilling
    {
        public class Kunde
        {
            public int KId { get; set; }
            public string Navn { get; set; }
            public string Telefonnummer { get; set; }

            public virtual List<Tur> turer { get; set; }

        }

        public class Tur
        {
            public int TId { get; set; }
            public string Destinasjon { get; set; }
            public Date dato { get; set; }
        }


        //Så en egen model klasse for bestillingen

        public class Bestilling
        {
            public string Navn { get; set; }
            public string Telefonnummer { get; set; }
            public string Destinasjon { get; set; }
            public Date dato { get; set; }
        }
    }
}

using System;
using System.Collections.Generic;

namespace WebapplikasjonerOppgave1.DAL
{
    public class Kunde
    {
        public int KId { get; set; }
        public string Fornavn { get; set; }
        public string Etternavn { get; set; }
        public string Telefonnummer { get; set; }
        public virtual List<Bestilling> bestilling { get; set; }
        //string test
    }
}

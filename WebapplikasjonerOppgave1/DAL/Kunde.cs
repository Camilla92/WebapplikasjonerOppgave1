using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebapplikasjonerOppgave1.DAL
{
    public class Kunde
    {
        [Key]
        public int KId { get; set; }
        public string Fornavn { get; set; }
        public string Etternavn { get; set; }
        public string Telefonnummer { get; set; }
        public string Epost { get; set; }
        public int Kortnummer { get; set; }
    }
}

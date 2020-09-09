using System;
using System.ComponentModel.DataAnnotations;

namespace WebapplikasjonerOppgave1.DAL
{
    public class Stasjon
    {
        [Key]
        public int SId { get; set; }
        public string StasjonsNavn { get; set; }
    }
}

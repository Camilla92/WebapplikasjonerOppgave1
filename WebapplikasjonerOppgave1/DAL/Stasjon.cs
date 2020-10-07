using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebapplikasjonerOppgave1.DAL
{
    public class Stasjon
    {
        [Key]
        public int SId { get; set; }
        public string StasjonsNavn { get; set; }
    }
}

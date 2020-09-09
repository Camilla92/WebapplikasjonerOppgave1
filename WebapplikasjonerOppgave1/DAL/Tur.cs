using System;
using System.ComponentModel.DataAnnotations;

namespace WebapplikasjonerOppgave1.DAL
{
    public class Tur
    {
        [Key]
        public int TurId { get; set; }
        public virtual Stasjon StartStasjon { get; set; }
        public virtual Stasjon EndeStasjon { get; set; }
        public DateTime Tid { get; set; }
        public double BarnePris { get; set; }
        public double VoksenPris { get; set; }
    }
}

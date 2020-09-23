using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebapplikasjonerOppgave1.DAL
{
    public class Tur
    {
        [Key]
        public int TurId { get; set; }
        public virtual Stasjon StartStasjon { get; set; }
        public virtual Stasjon EndeStasjon { get; set; }
        //public DateTime Tid { get; set; }
        public string Dato { get; set; }
        public string Tid { get; set; }
        public double BarnePris { get; set; }
        public double VoksenPris { get; set; }
    }
}

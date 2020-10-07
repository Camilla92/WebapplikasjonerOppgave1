using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebapplikasjonerOppgave1.Models
{
    public class Tur
    {
       
        public int TurId { get; set; }
        public string StartStasjon { get; set; }
        public string EndeStasjon { get; set; }
        public string Dato { get; set; }
        public string Tid { get; set; }
        public double BarnePris { get; set; }
        public double VoksenPris { get; set; }
    }
}

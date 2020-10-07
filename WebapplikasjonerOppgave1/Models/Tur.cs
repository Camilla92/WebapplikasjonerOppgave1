using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebapplikasjonerOppgave1.Models
{
    public class Tur
    {
       
        public int TurId { get; set; }

        [RegularExpression(@"^[a-zA-ZæøåÆØÅ. \-]{2,20}$")]
        public string StartStasjon { get; set; }

        [RegularExpression(@"^[a-zA-ZæøåÆØÅ. \-]{2,20}$")]
        public string EndeStasjon { get; set; }

        [RegularExpression(@"^(0?[1-9]|[12][0-9]|3[01])[\/\-](0?[1-9]|1[012])[\/\-]\d{4}$")]
        public string Dato { get; set; }


        public string Tid { get; set; }

        
        public double BarnePris { get; set; }


        public double VoksenPris { get; set; }
    }
}

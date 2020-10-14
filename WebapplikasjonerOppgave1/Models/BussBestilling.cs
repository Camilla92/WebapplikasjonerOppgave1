using System;
using System.ComponentModel.DataAnnotations;

namespace WebapplikasjonerOppgave1.Models
{

    public class BussBestilling
    {
        public int Id { get; set; }

        //Kunde
        [RegularExpression(@"^[a-zA-ZæøåÆØÅ. \-]{2,20}$")]
        public string Fornavn { get; set; }

        [RegularExpression(@"^[a-zA-ZæøåÆØÅ. \-]{2,20}$")]
        public string Etternavn { get; set; }

        [RegularExpression(@"^[0-9]{8}$")]
        public string Telefonnummer { get; set; }

        [RegularExpression(@"^[^<> ()[\]\\.,;:\s@\']+(\.[^<>()[\]\\.,;:\s@\']+)*)|(\'.+\'))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,})$")]
        public string Epost { get; set; }

        [RegularExpression(@"^[0-9]{16}$")]
        public int Kortnummer { get; set; }

        //Bestilling
        [RegularExpression(@"^([0-9.]{2,4}[0-9]{1,2})?$")]
        public int AntallBarn { get; set; }

        [RegularExpression(@"^([0-9.]{2,4}[0-9]{1,2})?$")]
        public int AntallVoksne { get; set; }

        [RegularExpression(@"^(0?[1-9]|[12][0-9]|3[01])[\/\-](0?[1-9]|1[012])[\/\-]\d{4}$")]
        public string Dato { get; set; }
        

        [RegularExpression(@"^([01]?[0 - 9]|2[0-3]):[0-5][0-9]$")]
        public string Tid { get; set; }

        [RegularExpression(@"^0-9]{1,3}$")]
        public double BarnePris { get; set; }

        [RegularExpression(@"^0-9]{1,3}$")]
        public double VoksenPris { get; set; }

        public string StartStasjon { get; set; }

        public string EndeStasjon { get; set; }

    }

}

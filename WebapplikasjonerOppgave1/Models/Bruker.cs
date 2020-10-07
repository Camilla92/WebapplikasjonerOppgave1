
using System.ComponentModel.DataAnnotations;

namespace WebapplikasjonerOppgave1.Models {
    public class Bruker
    {
        [RegularExpression(@"^[a-zA-ZæøåÆØÅ\.\\-]{2,20}$")]
        public string Brukernavn { get; set; }
        [RegularExpression(@"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{6,}$")]
        public string Passord { get; set; }
    }

}

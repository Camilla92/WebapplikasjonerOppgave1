using System;
namespace WebapplikasjonerOppgave1.DAL
{
    public class Brukere
    {
        
        public int Id { get; set; }
        public string Brukernavn { get; set; }
        public byte[] Passord { get; set; }
        public byte[] Salt { get; set; }

    
    }
}

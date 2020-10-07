using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using WebapplikasjonerOppgave1.Models;

namespace WebapplikasjonerOppgave1.DAL
{
    public interface IBussBestillingRepository
    {
        Task<List<Stasjon>> HentAlleStasjoner();
        Task<List<Tur>> HentAlleTurer();
        Task<List<Stasjon>> HentEndeStasjoner(string startStasjonsNavn);
        Task<bool> Lagre(BussBestilling innBussBestilling);
        Task<bool> OpprettTur(Models.Tur innTur);
    }
}

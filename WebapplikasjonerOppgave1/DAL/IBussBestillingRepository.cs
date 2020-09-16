using System;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace WebapplikasjonerOppgave1.DAL
{
    public interface IBussBestillingRepository
    {
        Task<List<Stasjon>> HentAlleStasjoner();
        Task<Tur> HentEnTur(Stasjon StarStasjon);

    }
}

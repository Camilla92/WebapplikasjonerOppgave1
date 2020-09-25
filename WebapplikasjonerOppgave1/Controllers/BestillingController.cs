using System;
using System.Collections.Generic;
using System.Linq;
using WebapplikasjonerOppgave1.Models;
using Microsoft.AspNetCore.Mvc;
using WebapplikasjonerOppgave1.DAL;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Stasjon = WebapplikasjonerOppgave1.DAL.Stasjon;
using Microsoft.Extensions.Logging;

namespace WebapplikasjonerOppgave1.Controllers
{
    [Route("[controller]/[action]")]
    public class BestillingController : ControllerBase
    {
        private readonly NorwayContext _db;
        private readonly ILogger<BestillingController> _log;

        public BestillingController(NorwayContext db, ILogger<BestillingController> log)
        {
            _db = db;
            _log = log;
        }

        public async Task<ActionResult> HentAlleStasjoner()
        {
            List<Stasjon> alleStasjoner = await _db.Stasjoner.ToListAsync();
            return Ok(alleStasjoner);
        }

        public async Task<List<Stasjon>> HentEndeStasjoner(string startStasjonsNavn)
        {
            List<Tur> alleTurer = await _db.Turer.ToListAsync();
            var endeStasjon = new List<Stasjon>();

            foreach (var turen in alleTurer)
            {
                if (startStasjonsNavn.Equals(turen.StartStasjon.StasjonsNavn))
                {
                    endeStasjon.Add(turen.EndeStasjon);
                }
            }
            return endeStasjon;
        }

        
        public async Task<List<Tur>> hentAlleTurer()
        {
            List<Tur> alleTurer = await _db.Turer.ToListAsync();
            return alleTurer;

        }
        

        public async Task<double> beregnPris(String startStasjonsNavn, String endeStasjonsNavn, String tid, String dato, String antallBarn, String antallVoksne)
        {
            double pris;
            double barnepris = 0;
            double voksenpris = 0;
            //double doubleAntallBarn = Convert.ToDouble(antallBarn);
            //double doubleAntallVoksne = Convert.ToDouble(antallVoksne);
            int intAntallBarn = Convert.ToInt16(antallBarn);
            int intAntallVoksne = Convert.ToInt16(antallVoksne);


            List<Tur> alleTurer = await _db.Turer.ToListAsync();

            foreach (var turen in alleTurer)
            {
                if ((startStasjonsNavn.Equals(turen.StartStasjon.StasjonsNavn)) && (endeStasjonsNavn.Equals(turen.EndeStasjon.StasjonsNavn)) && (tid.Equals(turen.Tid)) && (dato.Equals(turen.Dato)))
                {
                    barnepris = turen.BarnePris;
                    voksenpris = turen.VoksenPris;
                }
            }
            pris = (barnepris * intAntallBarn) + (voksenpris + intAntallVoksne);
            return pris;
        }

        //først bestilling, så tur, så sjekke om kunden finnes fra før av!
        public async Task<bool> lagre(BussBestilling innBussBestilling)
        {

            int kundeID = 0;
            List<Kunde> alleKunder = await _db.Kunder.ToListAsync();

            foreach (var kunde in alleKunder)
            {
                if (innBussBestilling.Fornavn.Equals(kunde.Fornavn) &&
                    innBussBestilling.Etternavn.Equals(kunde.Etternavn))
                {
                    kundeID = kunde.KId;
                }
            }
                try
            {
                var nyBestillingRad = new Bestilling();
                nyBestillingRad.AntallBarn = innBussBestilling.AntallBarn;
                nyBestillingRad.AntallBarn = innBussBestilling.AntallVoksne;
                nyBestillingRad.TotalPris = innBussBestilling.TotalPris;
                nyBestillingRad.Tur.StartStasjon.StasjonsNavn = innBussBestilling.StartStasjon;
                nyBestillingRad.Tur.EndeStasjon.StasjonsNavn = innBussBestilling.EndeStasjon;
                nyBestillingRad.Tur.Dato = innBussBestilling.Dato;
                nyBestillingRad.Tur.Tid = innBussBestilling.Tid;
                //nyBestillingRad.Tur.BarnePris = innBussBestilling.BarnePris;
                //nyBestillingRad.Tur.VoksenPris = innBussBestilling.VoksenPris;

                Kunde funnetKunde = await _db.Kunder.FindAsync(kundeID);

                var sjekkKundeFinnes = await _db.Kunder.FindAsync(innBussBestilling.Id); 
                if(sjekkKundeFinnes == null)
                {
                    var kundeRad = new Kunde();
                    kundeRad.Fornavn = innBussBestilling.Fornavn;
                    kundeRad.Etternavn = innBussBestilling.Etternavn;
                    kundeRad.Telefonnummer = innBussBestilling.Telefonnummer;
                    _db.Kunder.Add(kundeRad);
                    //await _db.SaveChangesAsync();
                } else
                {
                    nyBestillingRad.kunde = funnetKunde;
                }
                _db.Bestillinger.Add(nyBestillingRad);
                await _db.SaveChangesAsync();
                return true; 
            } catch (Exception e)
            {
                _log.LogInformation(e.Message);
                return false;
            }


            /*
            int turID = 0;
            List<Tur> alleTurer = await _db.Turer.ToListAsync();

            foreach (var turen in alleTurer)
            {
                if (innBussBestilling.StartStasjon.Equals(turen.StartStasjon.StasjonsNavn) &&
                    innBussBestilling.EndeStasjon.Equals(turen.EndeStasjon.StasjonsNavn) &&
                    innBussBestilling.Tid.Equals(turen.Tid) && innBussBestilling.Dato.Equals(turen.Dato))
                {
                    turID = turen.TurId;
                }
            }

            Tur funnetTur = _db.Turer.Find(turID);

            var bestilling = new Bestilling()
            {
                AntallBarn = innBussBestilling.AntallBarn,
                AntallVoksne = innBussBestilling.AntallVoksne,
                TotalPris = (innBussBestilling.BarnePris * innBussBestilling.AntallBarn) +
                (innBussBestilling.VoksenPris * innBussBestilling.AntallVoksne),
                Tur = funnetTur
            };


            Kunde funnetKunde = await _db.Kunder.FindAsync(Kunde.KId);

            if (funnetKunde == null)
            {

                var kunde = new Kunde
                {
                    Fornavn = innBussBestilling.Fornavn,
                    Etternavn = innBussBestilling.Etternavn,
                    Telefonnummer = innBussBestilling.Telefonnummer,
                    Bestilling = new List<Bestilling>()
                };

                kunde.Bestilling.Add(bestilling);
                await _db.Kunder.Add(kunde);
                await _db.SaveChangesAsync();
                return true;
            }
            else
            {
                funnetKunde.Bestilling.Add(bestilling);
                await _db.SaveChangesAsync();
                return true;
            }*/
            //bool returOKBestilling = await _db.Lagre(Bestilling bestilling);
            //bool returOKKunde = await _db.Lagre(Bestilling bestilling);


        }
    }

}


        /*
        public async Task<ActionResult> Lagre(BussBestilling innBussBestilling)
        {
            if (ModelState.IsValid)
            {
                bool returOk = await _db.Lagre(innBussBestilling);
                if (!returOk)
                {
                    _log.LogInformation("Bestilling ble ikke registrert");
                    return BadRequest("Bestilling ble ikke registrert");
                }
                return Ok("Bestilling registrert");
            }
            _log.LogInformation("Feil i inputvalidering");
            return BadRequest("Feil i inputvalidering på server");
        }

        public async Task<List<Tur>> hentAlleTurer()
        {
            List<Tur> alleTurer = await _db.Turer.ToListAsync();
            return alleTurer;

        }
        */


/*
public async Task<ActionResult> Lagre(BussBestilling innBussBestilling)
{
    if (ModelState.IsValid)
    {
        bool returOk = await _db.Lagre(innBussBestilling);
        if (!returOk)
        {
            _log.LogInformation("Bestilling ble ikke registrert");
            return BadRequest("Bestilling ble ikke registrert");
        }
        return Ok("Bestilling registrert");
    }
    _log.LogInformation("Feil i inputvalidering");
    return BadRequest("Feil i inputvalidering på server");
}

*/

//return Ok(alleTurer);
//Tur enTur = await _db.HentEndeStasjoner(innStartstasjon);
// Tur enTur = await _db.Turer.FirstOrDefault(k=> k.StartStasjon = innStartstasjon.EndeStasjon);

// Kunde funnetKunde = await _db.Kunder.FirstOrDefault(k => k.Fornavn
// = innBussBestilling.Fornavn && k => k.Etternavn = innBussBestilling.Etternavn);



/* if (enTur == null)
 {
     _log.LogInformation("Turen ble ikke funnet");
     return NotFound("Turen ble ikke funnet");
 }
 return Ok("Turen ble funnet");
*/



/*public async Task<ActionResult> HentEnTur(Stasjon startStasjon, Stasjon endeStasjon)
{
    Tur enTur = await _db.HentEnTur();


    if (enTur == null)
    {
        _log.LogInformation("Turen ble ikke funnet");
        return NotFound("Turen ble ikke funnet");
    }
    return Ok("Turen ble funnet");

}

public async Task<ActionResult> HentEnTur(Stasjon startStasjon, Stasjon endeStasjon, DateTime tid)
{
    Tur enTur = await _db.HentEnTur();


    if (enTur == null)
    {
        _log.LogInformation("Turen ble ikke funnet");
        return NotFound("Turen ble ikke funnet");
    }
    return Ok("Turen ble funnet");

}
*/



/* public async Task<ActionResult> lagre(BussBestilling innBussBestilling)
  {

     var bestilling = new Bestilling()
     {
         AntallBarn = innBussBestilling.AntallBarn,
         AntallVoksne = innBussBestilling.AntallVoksne,
         TotalPris = innBussBestilling.TotalPris,
         Tur = innBussBestilling.Tur,
     };

     Kunde funnetKunde = await _db.Kunder.FirstOrDefault(k => k.Fornavn
     = innBussBestilling.Fornavn && k => k.Etternavn = innBussBestilling.Etternavn);

     if (funnetKunde == null)
     {

         var kunde = new Kunde
         {
             Fornavn = innBussBestilling.Fornavn,
             Etternavn= innBussBestilling.Etternavn,
             Telefonnummer= innBussBestilling.Telefonnummer,
         };

         kunde.Bestillinger = new List<Bestilling>();
         kunde.Bestillinger.Add(bestilling);
         await _db.Kunder.Add(kunde);
         await _db.SaveChangesAsync();

     }
     else
     {

         funnetKunde.Bestillinger.Add(bestilling);
         await _db.SaveChangesAsync();


     }


     bool returOKBestilling = await _db.Lagre(Bestilling innBestilling);
     bool returOKKunde = await _db.Lagre(Bestilling innBestilling);

     var nyBestillingRad = new Bestilling();
      nyBestillingRad.Kunde.Fornavn = innBussBestilling.Fornavn;
      nyBestillingRad.Kunde.Fornavn = innBussBestilling.Etternavn;
  }
}
*/


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
        

        public async Task<ActionResult> Lagre(BussBestilling innBussBestilling)
          {

        int turID = 0;

        List<Tur> alleTurer = await _db.Turer.ToListAsync();

        foreach (var turen in alleTurer)
        {
             if ((innBussBestilling.StartStasjon.Equals(turen.StartStasjon.StasjonsNavn)) && (innBussBestilling.EndeStasjon.Equals(turen.EndeStasjon.StasjonsNavn)) && (innBussBestilling.Tid.Equals(turen.Tid)) && (innBussBestilling.Dato.Equals(turen.Dato)))
             {
                    turID = turen.TurId;
             }
        }

            Tur funnetTur = _db.Turer.Find(turID);

            var bestilling = new Bestilling()
            {
                AntallBarn = innBussBestilling.AntallBarn,
                AntallVoksne = innBussBestilling.AntallVoksne,
                TotalPris = (innBussBestilling.BarnePris * innBussBestilling.AntallVoksne) + (innBussBestilling.VoksenPris * innBussBestilling.BarnePris),
                Tur = funnetTur
             };


            Kunde funnetKunde = await _db.Kunder.FirstOrDefault(k => k.Fornavn
             = innBussBestilling.Fornavn && k=> k.Etternavn = innBussBestilling.Etternavn);

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

             }
             else
             {
                 funnetKunde.Bestilling.Add(bestilling);
                 await _db.SaveChangesAsync();
             }


             bool returOKBestilling = await _db.Lagre(Bestilling bestilling);
             bool returOKKunde = await _db.Lagre(Bestilling bestilling);


            /*
             var nyBestillingRad = new Bestilling();
              nyBestillingRad.Kunde.Fornavn = innBussBestilling.Fornavn;
              nyBestillingRad.Kunde.Fornavn = innBussBestilling.Etternavn;*/
          }
     }

}








/*

        /*public async Task<ActionResult> Lagre(Kunde innKunde, Bestilling innBestilling)
        {
            bool returOk = await _db.Lagre(Kunde innKunde);
            if (!returOk) {
                _log.LogInformation("Kunden ble ikke lagret");
                return BadRequest("Kunden ble ikke lagret");
            }
            return Ok("Kunde lagret");

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



        
        



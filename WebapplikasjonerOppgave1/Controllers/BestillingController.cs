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
using Microsoft.AspNetCore.Http;

namespace WebapplikasjonerOppgave1.Controllers
{
    [Route("[controller]/[action]")]
    public class BestillingController : ControllerBase
    {
        private readonly ILogger<BestillingController> _log;
        private readonly IBussBestillingRepository _db;
        private const string _loggetInn = "loggetInn";

        public BestillingController(IBussBestillingRepository db, ILogger<BestillingController> log)
        {
            _db = db;
            _log = log;
        }

        public async Task<ActionResult> HentAlleStasjoner()
        {
            //sjekker om innloggingssession er true/false
            if (string.IsNullOrEmpty(HttpContext.Session.GetString(_loggetInn)))
            {
                return Unauthorized();
            }
            List<Stasjon> alleStasjoner = await _db.HentAlleStasjoner();
            return Ok(alleStasjoner);
        }

        public async Task<ActionResult> HentAlleTurer()
        {
            //sjekker om innloggingssession er true/false
            if (string.IsNullOrEmpty(HttpContext.Session.GetString(_loggetInn)))
            {
                return Unauthorized();
            }
            List<Tur> alleTurer = await _db.HentAlleTurer();
            return Ok(alleTurer);
        }

        public async Task<ActionResult> HentEndeStasjoner(string startStasjonsNavn)
        {
            //sjekker om innloggingssession er true/false
            if (string.IsNullOrEmpty(HttpContext.Session.GetString(_loggetInn)))
            {
                return Unauthorized();
            }
            List<Stasjon> endeStasjon = await _db.HentEndeStasjoner(startStasjonsNavn);
            return Ok(endeStasjon);
        }

        public async Task<ActionResult> Lagre(BussBestilling innBussBestilling)
        {
            //sjekker om innloggingssession er true/false
            if (string.IsNullOrEmpty(HttpContext.Session.GetString(_loggetInn)))
            {
                return Unauthorized();
            }

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


        //Tor sin kode
        public async Task<ActionResult> LoggInn(Bruker bruker)
        {
            if (ModelState.IsValid)
            {
                bool returnOK = await _db.LoggInn(bruker);
                if (!returnOK)
                {
                    _log.LogInformation("Innloggingen feilet for bruker" + bruker.Brukernavn);
                    HttpContext.Session.SetString(_loggetInn, "");
                    return Ok(false);
                }
                HttpContext.Session.SetString(_loggetInn, "LoggetInn");
                return Ok(true);
            }
            _log.LogInformation("Feil i inputvalidering");
            return BadRequest("Feil i inputvalidering på server");
        }

        //Tor sin kode
        public void LoggUt()
        {
            HttpContext.Session.SetString(_loggetInn, "");
        }


    }
}


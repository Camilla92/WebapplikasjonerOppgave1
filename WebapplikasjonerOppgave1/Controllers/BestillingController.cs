using System;
using System.Collections.Generic;
using WebapplikasjonerOppgave1.Models;
using Microsoft.AspNetCore.Mvc;
using WebapplikasjonerOppgave1.DAL;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace WebapplikasjonerOppgave1.Controllers
{
    [Route("[controller]/[action]")]
    public class BestillingController : ControllerBase
    {
        private readonly ILogger<BestillingController> _log;
        private readonly IBussBestillingRepository _db;

        public BestillingController(IBussBestillingRepository db, ILogger<BestillingController> log)
        {
            _db = db;
            _log = log;
        }

        public async Task<ActionResult> EndreTur(Tur endreTur)
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString(_loggetInn)))
            {
                return Unauthorized();
            }
            if (ModelState.IsValid)
            {
                bool returOK = await _db.EndreTur(endreTur);
                if (!returOK)
                {
                    _log.LogInformation("Endringen kunne ikke utføres");
                    return NotFound("Endringen av turen kunne ikke utføres");
                }
                return Ok("Turen er endret");
            }
            _log.LogInformation("Feil i inputvalidering");
            return BadRequest("Feil i inputvalidering på server");
        }

        public async Task<ActionResult> HentAlleStasjoner()
        {
            List<Stasjon> alleStasjoner = await _db.HentAlleStasjoner();
            return Ok(alleStasjoner);
        }

        public async Task<ActionResult> HentAlleTurer()
        {
            List<Turer> alleTurer = await _db.HentAlleTurer();
            return Ok(alleTurer);
        }

        public async Task<ActionResult> HentEndeStasjoner(string startStasjonsNavn)
        {
            List<Stasjon> endeStasjon = await _db.HentEndeStasjoner(startStasjonsNavn);
            return Ok(endeStasjon);
        }

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

        public async Task<ActionResult> OpprettTur(Tur innTur)
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString(_loggetInn)))
            {
                return Unauthorized();
            }
            if (ModelState.IsValid)
            {
                bool returOK = await _db.OpprettTur(innTur);
                if (!returOK)
                {
                    _log.LogInformation("Tur kunne ikke lagres!");
                    return BadRequest("Tur kunne ikke lagres");
                }
                return Ok("Tur lagret");
            }
            _log.LogInformation("Feil i inputvalidering");
            return BadRequest("Feil i inputvalidering på server");


        }
    }

}
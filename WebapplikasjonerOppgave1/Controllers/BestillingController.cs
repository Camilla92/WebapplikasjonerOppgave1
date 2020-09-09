using System;
using System.Collections.Generic;
using System.Linq;
using WebapplikasjonerOppgave1.Models;
using Microsoft.AspNetCore.Mvc;
using WebapplikasjonerOppgave1.DAL;

namespace WebapplikasjonerOppgave1.Controllers
{
    [Route("[controller]/[action]")]
    public class BestillingController : ControllerBase
    {
        private readonly NorwayContext _db;
        
        public BestillingController(NorwayContext db)
        {
            _db = db;
        }

        [HttpPost]
        public List<string> HentAlleStartStasjoner()
        {
            List<Stasjon> alleStasjoner = _db.Stasjoner.ToList();
            var alleStartStasjoner = new List<string>();
            foreach (var stasjon in alleStasjoner)
            {
                var EnStartStasjon = stasjon.StasjonsNavn;
                alleStartStasjoner.Add(EnStartStasjon);
            };
            return alleStartStasjoner;
        }


    }
}

//TEst
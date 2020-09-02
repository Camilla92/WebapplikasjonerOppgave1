using System;
using System.Collections.Generic;
using System.Linq;
using WebapplikasjonerOppgave1.Models;
using Microsoft.AspNetCore.Mvc;

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

        public List<String> HentAlleStartStasjoner()
        {
            List<Tur> alleTurer = _db.Turer.ToList();
            var alleStartStasjoner = new List<String>();
            foreach (var tur in alleTurer)
            {
                var EnStartStasjon = tur.StartStasjon;
                alleStartStasjoner.Add(EnStartStasjon);
            };
            return alleStartStasjoner;
        }


    }
}

//TEst
﻿using System;
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
        public List<Stasjon> HentAlleStasjoner()
        {
            List<Stasjon> alleStasjoner = _db.Stasjoner.ToList();
            return alleStasjoner;
        }


    }
}

//TEst
using System;
using System.Collections.Generic;
using System.Linq;
using WebapplikasjonerOppgave1.Models;
using Microsoft.AspNetCore.Mvc;
using WebapplikasjonerOppgave1.DAL;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Stasjon = WebapplikasjonerOppgave1.Models.Stasjon;

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

        public List<Stasjon> HentAlleStasjoner()
        {
            try
            {
                List<Stasjon> alleStasjoner = _db.Stasjoner.ToList();
                return alleStasjoner;
            }
            catch (Exception e)
            {
                return null;
            }
        }

       /* public bool lagre(BussBestilling innBussBestilling)
        {
            var nyBestillingRad = new Bestilling();
            nyBestillingRad.Kunde.Fornavn = innBussBestilling.Fornavn;
            nyBestillingRad.Kunde.Fornavn = innBussBestilling.Etternavn;

        }*/
        

        }
    }


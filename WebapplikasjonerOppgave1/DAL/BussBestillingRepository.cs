using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using WebapplikasjonerOppgave1.Models;

namespace WebapplikasjonerOppgave1.DAL
{
    public class BussBestillingRepository : IBussBestillingRepository
    {
        private readonly NorwayContext _db;
        private ILogger<BussBestillingRepository> _log;

        public BussBestillingRepository(NorwayContext db, ILogger<BussBestillingRepository> log)
        {
            _db = db;
            _log = log;
        }

        public async Task<List<Stasjon>> HentAlleStasjoner()
        {
            List<Stasjon> alleStasjoner = await _db.Stasjoner.ToListAsync();
            return alleStasjoner;
        }

        public async Task<List<Tur>> HentAlleTurer()
        {
            List<Tur> alleTurer = await _db.Turer.ToListAsync();
            return alleTurer;
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

        public async Task<bool> Lagre(BussBestilling innBussBestilling)
        {
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

            double totalpris = (innBussBestilling.AntallBarn * funnetTur.BarnePris) + (innBussBestilling.AntallVoksne * funnetTur.VoksenPris);


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
                nyBestillingRad.AntallVoksne = innBussBestilling.AntallVoksne;
                nyBestillingRad.TotalPris = totalpris;
                nyBestillingRad.Tur = funnetTur;


                Kunde funnetKunde = await _db.Kunder.FindAsync(kundeID);

                if (funnetKunde == null)
                {
                    var kundeRad = new Kunde();
                    kundeRad.Fornavn = innBussBestilling.Fornavn;
                    kundeRad.Etternavn = innBussBestilling.Etternavn;
                    kundeRad.Telefonnummer = innBussBestilling.Telefonnummer;
                    _db.Kunder.Add(kundeRad);
                    await _db.SaveChangesAsync();
                    nyBestillingRad.kunde = kundeRad;

                }
                else
                {
                    nyBestillingRad.kunde = funnetKunde;
                }
                _db.Bestillinger.Add(nyBestillingRad);
                await _db.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                _log.LogInformation(e.Message);
                return false;
            }
        }

        public static byte[] LagHash(string passord, byte[] salt)
        {
            return KeyDerivation.Pbkdf2(
                    password: passord,
                    salt: salt,
                    prf: KeyDerivationPrf.HMACSHA512,
                    iterationCount: 1000,
                    numBytesRequested: 32);
        }
    }
}

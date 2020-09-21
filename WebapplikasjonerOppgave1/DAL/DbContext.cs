using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebapplikasjonerOppgave1.DAL;

namespace WebapplikasjonerOppgave1.Models
{
    public class NorwayContext : DbContext
    {
        public NorwayContext(DbContextOptions<NorwayContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        public virtual DbSet<Kunde> Kunder { get; set; }
        public virtual DbSet<Tur> Turer { get; set; }
        public virtual DbSet<Stasjon> Stasjoner { get; set; }
        public virtual DbSet<Bestilling> Bestillinger { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }

        internal Task<bool> Lagre(Kunde kunde, Kunde innKunde)
        {
            throw new NotImplementedException();
        }

        internal Task<bool> Lagre(Kunde innKunde, Bestilling innBestilling)
        {
            throw new NotImplementedException();
        }

        internal Task<bool> Lagre(BussBestilling innBussBestilling)
        {
            throw new NotImplementedException();
        }
    }
}

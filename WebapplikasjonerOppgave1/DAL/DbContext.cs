using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using WebapplikasjonerOppgave1.DAL;

namespace WebapplikasjonerOppgave1.Models
{
    public class NorwayContext : DbContext
    {
        public DbSet<Kunde> Kunder { get; set; }
        public DbSet<Tur> Turer { get; set; }
        public DbSet<Stasjon> Stasjoner { get; set; }
        public DbSet<Bestilling> Bestillinger { get; set; }

        public NorwayContext(DbContextOptions<NorwayContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }
    }
}

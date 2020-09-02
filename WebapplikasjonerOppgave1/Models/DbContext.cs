using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace WebapplikasjonerOppgave1.Models
{
    
    public class Kunde
    {
        [Key]
        public int KId { get; set; }
        public string Navn { get; set; }
        public string Telefonnummer { get; set; }

        public virtual List<Tur> Turer { get; set; }

    }

    public class Tur
    {
        [Key]
        public int RId { get; set; }
        public string StartStasjon { get; set; }
        public string EndeStasjon { get; set; }
        public DateTime Tid { get; set; }
    }

  
    public class NorwayContext : DbContext
    {
        public DbSet<Kunde> Kunder { get; set; }
        public DbSet<Tur> Turer { get; set; }

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

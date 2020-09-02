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

        public virtual List<Tur> turer { get; set; }

    }

    public class Tur
    {
        [Key]
        public int TId { get; set; }
        public string Destinasjon { get; set; }
        public DateTime dato { get; set; }
    }

  
    public class NorwayContext : DbContext
    {
        public DbSet<Kunde> kunder { get; set; }
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

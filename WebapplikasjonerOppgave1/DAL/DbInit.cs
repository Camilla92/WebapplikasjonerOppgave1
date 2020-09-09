using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;


namespace WebapplikasjonerOppgave1.Models
{
    public static class DbInit
    {
        public static void Initialize(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<NorwayContext>();

                // må slette og opprette databasen hver gang når den skalinitieres (seed`es)
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                DateTime date1 = new DateTime (2008, 3, 1, 7, 0, 0 );
                DateTime date2 = new DateTime(2008, 3, 2, 9, 0, 0);


                var tur1 = new Tur { StartStasjon = "Oslo", EndeStasjon = "Bergen", Tid = date1};
                var tur2 = new Tur { StartStasjon = "Tromsø", EndeStasjon = "Stavanger", Tid = date2 };

                var kunde1 = new Kunde { Navn = "Ole Olsen", Telefonnummer = "12345678" };


                context.Turer.Add(tur1);
                context.Turer.Add(tur2);
                context.Kunder.Add(kunde1);

                context.SaveChanges();
            }
        }
    }
}


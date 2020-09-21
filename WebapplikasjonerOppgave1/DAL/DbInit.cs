using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using WebapplikasjonerOppgave1.DAL;
using WebapplikasjonerOppgave1.Models;

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



                /*---------OPPRETTER STASJONER--------*/
                var stasjon1 = new Stasjon { StasjonsNavn = "Oslo" };
                var stasjon2 = new Stasjon { StasjonsNavn = "Bergen" };
                var stasjon3 = new Stasjon { StasjonsNavn = "Trondheim" };
                var stasjon4 = new Stasjon { StasjonsNavn = "Bodø" };

                context.Stasjoner.Add(stasjon1);
                context.Stasjoner.Add(stasjon2);
                context.Stasjoner.Add(stasjon3);
                context.Stasjoner.Add(stasjon4);


                /*---------OPPRETTER DATOER--------*/
                string dato1 = "12/12/2020";
                //string dato2 = "24/12/2020";

                /*---------OPPRETTER TIDER--------*/
                string tid1 = "09:00";
                string tid2 = "15:00";
                string tid3 = "20:00";



                /*---------OPPRETTER TURER--------*/
                var tur1 = new Tur { StartStasjon = stasjon1, EndeStasjon = stasjon2, Tid = tid1, Dato = dato1, BarnePris = 50, VoksenPris = 100};
                var tur2 = new Tur { StartStasjon = stasjon1, EndeStasjon = stasjon3, Tid = tid2, Dato = dato1, BarnePris = 50, VoksenPris = 200 };
                var tur3 = new Tur { StartStasjon = stasjon1, EndeStasjon = stasjon4, Tid = tid3, Dato = dato1, BarnePris = 50, VoksenPris = 100 };
                var tur4 = new Tur { StartStasjon = stasjon2, EndeStasjon = stasjon1, Tid = tid1, Dato = dato1, BarnePris = 50, VoksenPris = 200 };
                var tur5 = new Tur { StartStasjon = stasjon2, EndeStasjon = stasjon3, Tid = tid2, Dato = dato1, BarnePris = 50, VoksenPris = 100 };
                var tur6 = new Tur { StartStasjon = stasjon2, EndeStasjon = stasjon4, Tid = tid3, Dato = dato1, BarnePris = 50, VoksenPris = 200 };
                var tur7 = new Tur { StartStasjon = stasjon3, EndeStasjon = stasjon1, Tid = tid1, Dato = dato1, BarnePris = 50, VoksenPris = 100 };
                var tur8 = new Tur { StartStasjon = stasjon3, EndeStasjon = stasjon1, Tid = tid2, Dato = dato1, BarnePris = 50, VoksenPris = 200 };
                var tur9 = new Tur { StartStasjon = stasjon3, EndeStasjon = stasjon1, Tid = tid3, Dato = dato1, BarnePris = 50, VoksenPris = 100 };
                var tur10 = new Tur { StartStasjon = stasjon4, EndeStasjon = stasjon1, Tid = tid1, Dato = dato1, BarnePris = 50, VoksenPris = 200 };
                var tur11 = new Tur { StartStasjon = stasjon4, EndeStasjon = stasjon2, Tid = tid2, Dato = dato1, BarnePris = 50, VoksenPris = 100 };
                var tur12 = new Tur { StartStasjon = stasjon4, EndeStasjon = stasjon3, Tid = tid3, Dato = dato1, BarnePris = 50, VoksenPris = 200 };

                context.Turer.Add(tur1);
                context.Turer.Add(tur2);
                context.Turer.Add(tur3);
                context.Turer.Add(tur4);
                context.Turer.Add(tur5);
                context.Turer.Add(tur6);
                context.Turer.Add(tur7);
                context.Turer.Add(tur8);
                context.Turer.Add(tur9);
                context.Turer.Add(tur10);
                context.Turer.Add(tur11);
                context.Turer.Add(tur12);

                context.SaveChanges();

            }
        }
    }
}


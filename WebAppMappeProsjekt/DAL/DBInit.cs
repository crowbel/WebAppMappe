using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppMappeProsjekt.Model
{
    public class DBInit
    {
        public static void Initialize(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<RuteContext>();
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
                var dest1 = new Destinasjoner { Land = "Norge", Sted = "Oslo" };
                var dest2 = new Destinasjoner { Land = "Danmark", Sted = "Fredrikshavn" };

                var rute1 = new Ruter { FraDestinasjon = dest1, TilDestinasjon = dest2, PrisBarn = 99, PrisVoksen = 199 };
                var rute2 = new Ruter { FraDestinasjon = dest2, TilDestinasjon = dest1, PrisBarn = 99, PrisVoksen = 199 };

                var avgang1 = new AvgangerTable { RuteNr = rute1, AvgangTid = new DateTime(2021, 10, 10, 19, 00, 00) };
                var avgang2 = new AvgangerTable { RuteNr = rute2, AvgangTid = new DateTime(2021, 11, 10, 18, 30, 00) };
                var avgang3 = new AvgangerTable { RuteNr = rute2, AvgangTid = new DateTime(2021, 11, 12, 18, 30, 00) };

                var dest3 = new Destinasjoner { Land = "Norge", Sted = "Kristiansand" };
                var dest4 = new Destinasjoner { Land = "Sverige", Sted = "Goteborg" };

                var rute3 = new Ruter { FraDestinasjon = dest3, TilDestinasjon = dest4, PrisBarn = 129, PrisVoksen = 209 };
                var rute4 = new Ruter { FraDestinasjon = dest4, TilDestinasjon = dest3, PrisBarn = 129, PrisVoksen = 209 };

                var rute5 = new Ruter { FraDestinasjon = dest3, TilDestinasjon = dest2, PrisBarn = 89, PrisVoksen = 169 };
                var rute6 = new Ruter { FraDestinasjon = dest2, TilDestinasjon = dest3, PrisBarn = 89, PrisVoksen = 169 };

                var avgang4 = new AvgangerTable { RuteNr = rute3, AvgangTid = new DateTime(2021, 10, 20, 19, 00, 00) };
                var avgang5 = new AvgangerTable { RuteNr = rute4, AvgangTid = new DateTime(2021, 11, 11, 18, 30, 00) };
                var avgang6 = new AvgangerTable { RuteNr = rute4, AvgangTid = new DateTime(2021, 11, 20, 18, 30, 00) };

                var avgang7 = new AvgangerTable { RuteNr = rute5, AvgangTid = new DateTime(2021, 10, 20, 19, 00, 00) };
                var avgang8 = new AvgangerTable { RuteNr = rute6, AvgangTid = new DateTime(2021, 11, 11, 12, 45, 00) };
                var avgang9 = new AvgangerTable { RuteNr = rute6, AvgangTid = new DateTime(2021, 11, 11, 18, 30, 00) };

                context.Destinasjoner.Add(dest1);
                context.Destinasjoner.Add(dest2);
                context.Ruter.Add(rute1);
                context.Ruter.Add(rute2);
                context.Avganger.Add(avgang1);
                context.Avganger.Add(avgang2);
                context.Avganger.Add(avgang3);

                context.Destinasjoner.Add(dest3);
                context.Destinasjoner.Add(dest4);
                context.Ruter.Add(rute3);
                context.Ruter.Add(rute4);
                context.Avganger.Add(avgang4);
                context.Avganger.Add(avgang5);
                context.Avganger.Add(avgang6);


                context.Ruter.Add(rute5);
                context.Ruter.Add(rute6);
                context.Avganger.Add(avgang7);
                context.Avganger.Add(avgang8);
                context.Avganger.Add(avgang9);

                context.SaveChanges();

            }
        }
    }
}

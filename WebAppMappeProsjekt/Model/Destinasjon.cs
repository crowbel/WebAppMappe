using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppMappeProsjekt.Model
{
    public class Destinasjoner
    {
        public int Id { get; set; }

        public string Navn { get; set; }

        public string Land { get; set; }
    }


    public class DestinasjonContext : DbContext
    {
        public DestinasjonContext(DbContextOptions<DestinasjonContext> options)
                : base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<Destinasjon> Destinasjoner { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }
    }
}

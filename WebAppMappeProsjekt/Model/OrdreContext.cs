using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppMappeProsjekt.Model
{
    public class Ordrer
    {

        //TODO fyll inn lokale variabler
        virtual public AvgangerTable Avgang { get; set; }
        virtual public Ruter Rute { get; set; }
    }
    public class OrdreContext : DbContext
    {
        public OrdreContext(DbContextOptions<OrdreContext> options) : base(options)
        {
            Database.EnsureCreated();
          
        }

        public DbSet<Ordrer> Ordrer { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }
    }
}

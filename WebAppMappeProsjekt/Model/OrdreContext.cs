using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppMappeProsjekt.Model
{
    public class Ordrer
    {
        public int Id { get; set; }
        public int antallBarn { get; set; }
        public int antallVoksne { get; set; }
        public string refPerson { get; set; }
        
        virtual public AvgangerTable Avgang { get; set; }
        
        virtual public Ruter RuteNr { get; set; }
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

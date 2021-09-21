using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppMappeProsjekt.Models;

namespace WebAppMappeProsjekt.Model
{
    public class Ruter
    {

        virtual public Destinasjoner FraDestinasjon { get; set; }
        virtual public Destinasjoner tilDestinasjon { get; set; }
    }
    public class AvgangerTable
    {
        virtual public Ruter RuteNr { get; set; }
    }
    public class Destinasjoner
    {

    }
    public class RuteContext : DbContext
    {
        public RuteContext(DbContextOptions<RuteContext> options) 
            : base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<Rute> Ruter { get; set; }
        public DbSet<Avganger> AvgangerDb { get; set; }
        public DbSet<Destinasjon> Destinasjoner { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }
    }
}

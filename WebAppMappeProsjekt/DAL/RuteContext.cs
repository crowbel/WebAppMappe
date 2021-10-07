using Microsoft.EntityFrameworkCore;
using System;

namespace WebAppMappeProsjekt.Model
{
    public class Ruter
    {
        public int Id { get; set; }

        virtual public Destinasjoner FraDestinasjon { get; set; }
        virtual public Destinasjoner TilDestinasjon { get; set; }
        public int PrisBarn { get; set; }
        public int PrisVoksen { get; set; }
    }
    public class AvgangerTable
    {
        public int Id { get; set; }
        public DateTime AvgangTid { get; set; }
        virtual public Ruter RuteNr { get; set; }
    }

    public class Destinasjoner
    {
        public int Id { get; set; }
        public string Sted { get; set; }
        public string Land { get; set; }
    }
    public class Ordrer
    {
        public int Id { get; set; }
        public int AntallBarn { get; set; }
        public int AntallVoksen { get; set; }
        public string RefPers { get; set; }

        virtual public AvgangerTable AvgangNr { get; set; }
        virtual public Ruter RuteNr { get; set; }
    }
    public class RuteContext : DbContext
    {
        public RuteContext(DbContextOptions<RuteContext> options) 
            : base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<Ruter> Ruter { get; set; }
        public DbSet<AvgangerTable> Avganger { get; set; }
        public DbSet<Destinasjoner> Destinasjoner { get; set; }
        public DbSet<Ordrer> Ordrer { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }
    }
}

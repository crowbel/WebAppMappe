using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppMappeProsjekt.Model;

namespace WebAppMappeProsjekt.Models
{
    public class Rute
    {
        public int Id { get; set; }
        virtual public Destinasjoner FraDestinasjon { get; set; }
        virtual public Destinasjoner TilDestinasjon { get; set; }
        public int PrisBarn { get; set; }
        public int PrisVoksen { get; set; }
    }
}

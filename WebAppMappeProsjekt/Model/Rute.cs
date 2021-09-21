using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppMappeProsjekt.Models
{
    public class Rute
    {
        public int Id { get; set; }
        public int FraDestinasjon { get; set; }
        public int TilDestinasjon { get; set; }
        public int PrisBarn { get; set; }
        public int PrisVoksen { get; set; }
    }
}

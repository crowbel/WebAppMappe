using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebAppMappeProsjekt.Models;

namespace WebAppMappeProsjekt.Model
{
    public class BillettOrdre
    {
        public int Id { get; set; }
        public int AntallBarn { get; set; }
        public int AntallVoksen { get; set; }
        public string RefPers { get; set; }
        public int AvgangNr { get; set; }
        public int RuteNr { get; set; }
        

    }


}

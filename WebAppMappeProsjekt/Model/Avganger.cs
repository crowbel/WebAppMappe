using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebAppMappeProsjekt.Models;

namespace WebAppMappeProsjekt.Model
{
    public class Avganger
    {
        public int Id { get; set; }
        public DateTime AvgangTid { get; set; }
        public int RuteNr{ get; set; }
        

    }

    
}

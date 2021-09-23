using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppMappeProsjekt.Model;

namespace WebAppMappeProsjekt.Controllers
{
    [Route("[controller]/[action]")]
    public class RuteController : ControllerBase
    {
        private readonly RuteContext _db;

        public RuteController(RuteContext db) 
        {
            _db = db;
        }
         
        public async Task<List<Ruter>> HentAlleRuter()
        {
            try
            {
                List<Ruter> alleRuter = await _db.Ruter.Select(r => new Ruter
                {
                    Id = r.Id,
                    FraDestinasjon = r.FraDestinasjon,
                    TilDestinasjon = r.TilDestinasjon,
                    PrisBarn = r.PrisBarn,
                    PrisVoksen = r.PrisVoksen
                }).ToListAsync();
                
                return alleRuter;
            }
            catch
            {
                return null;
            }
        } 
    }
}

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
        private readonly RuteContext _db; // RuteContext ikke merget inn enda.

        public RuteController(RuteContext db) //RuteContext ikke merget inn enda.
        {
            _db = db;
        }
        public async Task<List<Destinasjon>> HentAlleDestinasjoner()
        {
            try
            {
                List<Destinasjon> destinasjoner = await _db.Destinasjoner.Select(d => new Destinasjon
                {
                    Id = d.Id,
                    Sted = d.Sted,
                    Land = d.Land
                }).ToListAsync();
                return destinasjoner;

            }catch(Exception e)
            {
                return null;
            }
        }

        //Metode for HentAlleRuter følger her.

        /*
         
        public async Task<List<Rute>> HentAlleRuter()
        {
            try
            {
                List<Rute> alleRuter = await _db.Ruter.Select(k => new Rute
                {
                    Id = r.Id,
                    FraDestinasjon = r.FraDestinajon,
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
    
         */ 
    }
}

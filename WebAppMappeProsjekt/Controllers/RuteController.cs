using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppMappeProsjekt.Model;
using WebAppMappeProsjekt.Models;

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

            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<List<Rute>> HentAlleRuter()
        {
            try
            {
                List<Rute> alleRuter = await _db.Ruter.Select(r => new Rute
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

        
        public async Task<List<Rute>> HentMatchendeRuter(int id)
        {
            var compareObjekt = await _db.Destinasjoner.FindAsync(id);

            try
            {
                List<Rute> matchendeRuter = await _db.Ruter.Select(r => new Rute
                {
                    Id = r.Id,
                    FraDestinasjon = r.FraDestinasjon,
                    TilDestinasjon = r.TilDestinasjon,
                    PrisBarn = r.PrisBarn,
                    PrisVoksen = r.PrisVoksen
                    
                }).ToListAsync();

                matchendeRuter.Sort(id, matchendeRuter.Count, null);

                return matchendeRuter;
            }
            catch
            {
                return null;
            }
        }
      
    }
}

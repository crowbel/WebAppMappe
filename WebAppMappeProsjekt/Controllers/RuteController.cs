using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
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
                    
                }).Where(r => r.Id == id)
                .ToListAsync();

                return matchendeRuter;
            }
            catch
            {
                return null;
            }
        }
        public async Task<List<Avganger>> HentAvganger(int RuteId, DateTime Tid)
        {

            Console.WriteLine(Tid.ToString());
            try
            {
                
                List<Avganger> avganger = await _db.Avganger.Select(a => new Avganger
                {
                    Id = a.Id,
                    AvgangTid = a.AvgangTid,
                    RuteNr = a.RuteNr
                }).Where(a => a.RuteNr.Id == RuteId && DateTime.Compare(a.AvgangTid.Date, Tid.Date) == 0)
                .ToListAsync();
                return avganger;
            }
            catch
            {
                //TODO send http error
                return null;
            }
        }

        public async Task<Avganger> HentEnAvgang(int id)
        {
            try
            {
                AvgangerTable enAvgang = await _db.Avganger.FindAsync(id);
                var hentetAvgang = new Avganger()
                {
                    Id = enAvgang.Id,
                    AvgangTid = enAvgang.AvgangTid,
                    RuteNr = enAvgang.RuteNr,

                };

                return hentetAvgang;
            }
            catch
            {
                return null;
            }
        }
    }
}
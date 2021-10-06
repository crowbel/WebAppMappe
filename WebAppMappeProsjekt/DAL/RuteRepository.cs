using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppMappeProsjekt.Model;
using WebAppMappeProsjekt.Models;

namespace WebAppMappeProsjekt.DAL
{
    public class RuteRepository : IRuteRepository
    {
        private readonly RuteContext _db;
        public RuteRepository(RuteContext db)
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
            catch
            {
                return null;
            }
        }
        public async Task<List<Rute>> HentMatchendeRuter(int id)
        {
            try
            {
                List<Rute> matchendeRuter = await _db.Ruter.Select(r => new Rute
                {
                    Id = r.Id,
                    FraDestinasjon = r.FraDestinasjon,
                    TilDestinasjon = r.TilDestinasjon,
                    PrisBarn = r.PrisBarn,
                    PrisVoksen = r.PrisVoksen

                }).Where(r => r.FraDestinasjon.Id==id)
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
                
                return null;
            }
        }
        public async Task<Avganger> HentAvgang(int id)
        {
            try
            {
                AvgangerTable enAvgang = await _db.Avganger.FindAsync(id);
                Avganger avgang = new Avganger
                {
                    Id = enAvgang.Id,
                    AvgangTid = enAvgang.AvgangTid,
                    RuteNr = enAvgang.RuteNr
                };
                return avgang;
            }
            catch
            {
                return null;
            }
        }
    }
}

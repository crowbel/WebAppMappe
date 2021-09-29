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
            try
            {
                List<Avganger> avganger = await _db.Avganger.Select(a => new Avganger
                {
                    Id = a.Id,
                    AvgangTid = a.AvgangTid,
                    RuteNr = a.RuteNr
                }).Where(a => a.Id == RuteId && a.AvgangTid == Tid)
                .ToListAsync();
                return avganger;
            }
            catch
            {
                //TODO send http error
                return null;
            }
        }
    }
}

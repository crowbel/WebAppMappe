﻿using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppMappeProsjekt.Model;

namespace WebAppMappeProsjekt.DAL
{
    public class OrdreRepository : IOrdreRepository
    {
        private readonly OrdreContext _db;
        public OrdreRepository(OrdreContext db)
        {
            _db = db;
        }

        public async Task<bool> LagreOrdre(BillettOrdre innOrdre)
        {
            try
            {
                var nyOrdre = new Ordrer();
                nyOrdre.AntallBarn = innOrdre.AntallBarn;
                nyOrdre.AntallVoksen = innOrdre.AntallVoksen;
                nyOrdre.RefPers = innOrdre.RefPers;
                nyOrdre.AvgangNr = innOrdre.AvgangNr;
                nyOrdre.RuteNr = innOrdre.RuteNr;

                _db.Ordrer.Add(nyOrdre);
                await _db.SaveChangesAsync();
                return true;


            }
            catch
            {
                return false;
            }
        }

        public async Task<List<BillettOrdre>> HentAlle()
        {
            try
            {
                List<BillettOrdre> alleOrdrer = await _db.Ordrer.Select(b => new BillettOrdre
                {
                    Id = b.Id,
                    AntallBarn = b.AntallBarn,
                    AntallVoksen = b.AntallVoksen,
                    RefPers = b.RefPers,
                    AvgangNr = b.AvgangNr,
                    RuteNr = b.RuteNr


                }).ToListAsync();

                return alleOrdrer;
            }
            catch
            {
                return null;
            }
        }

        public async Task<BillettOrdre> HentEn (int id)
        {
            try
            {
                Ordrer enOrder = await _db.Ordrer.FindAsync(id);
                var hentetOrder = new BillettOrdre()
                {
                    Id = enOrder.Id,
                    AntallBarn = enOrder.AntallBarn,
                    AntallVoksen = enOrder.AntallVoksen,
                    RefPers = enOrder.RefPers,
                    AvgangNr = enOrder.AvgangNr,
                    RuteNr = enOrder.RuteNr
                };

                return hentetOrder;
            }
            catch
            {
                return null;
            }
        }
    }
}
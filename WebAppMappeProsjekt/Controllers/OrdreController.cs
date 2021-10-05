using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using WebAppMappeProsjekt.Model;

namespace WebAppMappeProsjekt.Controllers
{
    [Route("[controller]/[action]")]
    public class OrdreController : ControllerBase
    {
        private readonly RuteContext _db;

        private ILogger<OrdreController> _log;

        public OrdreController (RuteContext db, ILogger<OrdreController> log)
        {
            _db = db;
            _log = log;
        }

        public async Task<int> LagreOrdre(BillettOrdre innOrdre)
        {
            try
            {
                var nyOrdre = new Ordrer();
                nyOrdre.AntallBarn = innOrdre.AntallBarn;
                nyOrdre.AntallVoksen = innOrdre.AntallVoksen;
                nyOrdre.RefPers = innOrdre.RefPers;
                var sjekkAvgang = _db.Avganger.Find(innOrdre.AvgangNr);
                nyOrdre.AvgangNr = sjekkAvgang;
                nyOrdre.RuteNr = innOrdre.RuteNr;

                _db.Ordrer.Add(nyOrdre);
                await _db.SaveChangesAsync();
                return nyOrdre.Id;
            }
            catch
            {
                return -1;
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

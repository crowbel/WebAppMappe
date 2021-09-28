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
        private readonly OrdreContext _db;

        private ILogger<OrdreController> _log;

        public OrdreController (OrdreContext db, ILogger<OrdreController> log)
        {
            _db = db;
            _log = log;
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
    }
}

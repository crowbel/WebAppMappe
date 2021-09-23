using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAppMappeProsjekt.Model;

namespace WebAppMappeProsjekt.Controllers
{
    [Route("[controller]/[action]")]
    public class OrdreController : ControllerBase
    {
        private readonly OrdreContext _db;

        public OrdreController (OrdreContext db)
        {
            _db = db;
        }

        public async Task<bool> LagreOrdre(BillettOrdre innOrdre)
        {
            try
            {
                var nyOrdre = new Ordrer();
                nyOrdre.antallBarn = innOrdre.AntallBarn;
                nyOrdre.antallVoksne = innOrdre.AntallVoksen;
                nyOrdre.refPerson = innOrdre.RefPers;
                nyOrdre.Avgang = innOrdre.AvgangNr;
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
                    AntallBarn = b.antallBarn,
                    AntallVoksen= b.antallVoksne,
                    RefPers = b.refPerson,
                    AvgangNr = b.Avgang,
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

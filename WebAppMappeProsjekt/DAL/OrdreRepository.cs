using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppMappeProsjekt.Model;

namespace WebAppMappeProsjekt.DAL
{
    public class OrdreRepository : IOrdreRepository
    {
        private readonly RuteContext _db;
        public OrdreRepository(RuteContext db)
        {
            _db = db;
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
                var sjekkRute = _db.Ruter.Find(innOrdre.RuteNr);

                nyOrdre.AvgangNr = sjekkAvgang;
                nyOrdre.RuteNr = sjekkRute;

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
                    AvgangNr = b.AvgangNr.Id,
                    RuteNr = b.RuteNr.Id


                }).ToListAsync();

                return alleOrdrer;
            }
            catch
            {
                return null;
            }
        }
        public async Task<BillettOrdre> HentEn(int id)
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
                    AvgangNr = enOrder.AvgangNr.Id,
                    RuteNr = enOrder.RuteNr.Id
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
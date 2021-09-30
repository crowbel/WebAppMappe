using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebAppMappeProsjekt.DAL;
using WebAppMappeProsjekt.Model;

namespace WebAppMappeProsjekt.Controllers
{
    [Route("[controller]/[action]")]
    public class OrdreController : ControllerBase
    {
        private readonly IOrdreRepository _db;

        public OrdreController(IOrdreRepository db)
        {
            _db = db;
        }

        public async Task<int> LagreOrdre(BillettOrdre innOrdre)
        {
            return await _db.LagreOrdre(innOrdre);
        }

        public async Task<List<BillettOrdre>> HentAlle()
        { 
            return await _db.HentAlle();
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

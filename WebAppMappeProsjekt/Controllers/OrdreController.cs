using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebAppMappeProsjekt.DAL;
using WebAppMappeProsjekt.Model;

namespace WebAppMappeProsjekt.Controllers
{
    [Route("[controller]/[action]")]
    public class OrdreController : ControllerBase
    {
        private readonly IOrdreRepository _db;

        private ILogger<OrdreController> _log;

        public OrdreController(IOrdreRepository db, ILogger<OrdreController> log)
        {
            _db = db;
            _log = log;
        }

        public async Task<int> LagreOrdre(BillettOrdre innOrdre)
        {
            return await _db.LagreOrdre(innOrdre);
        }

        public async Task<List<BillettOrdre>> HentAlle()
        {
            _log.LogInformation("Hallo Loggen!");
            return await _db.HentAlle();
        }


        public async Task<BillettOrdre> HentEn(int id)
        {
            return await _db.HentEn(id);
        }


        
    }
}

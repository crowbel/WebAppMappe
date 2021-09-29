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

        public async Task<bool> LagreOrdre(BillettOrdre innOrdre)
        {
            return await _db.LagreOrdre(innOrdre);
        }

        public async Task<List<BillettOrdre>> HentAlle()
        { 
            return await _db.HentAlle();
        }
    } 
}

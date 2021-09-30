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

        public async Task<ActionResult> LagreOrdre(BillettOrdre innOrdre)
        {
            bool returOk = await _db.LagreOrdre(innOrdre);
            if (!returOk)
            {
                _log.LogInformation("Ordre ble ikke lagret");
                return BadRequest("Ordren ble ikke lagret");
            }
            return Ok("Ordre ble lagret");
            
        }

        public async Task<ActionResult> HentAlle()
        {
            List<BillettOrdre> alleBillettOrdre = await _db.HentAlle();
            return Ok(alleBillettOrdre);
            
        }

        public async Task<ActionResult> HentEn(int id)
        {
            BillettOrdre enBillettOrdre = await _db.HentEn(id);            
            if (enBillettOrdre == null)
            {
                _log.LogInformation("Fant ikke orderen");
                return NotFound("Fant ikke orderen");
            }
            return Ok(enBillettOrdre);
        }
    }
}

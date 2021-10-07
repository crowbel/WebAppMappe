using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebAppMappeProsjekt.DAL;
using WebAppMappeProsjekt.Model;
using WebAppMappeProsjekt.Models;

namespace WebAppMappeProsjekt.Controllers
{
    [Route("[controller]/[action]")]
    public class RuteController : ControllerBase
    {
        private readonly IRuteRepository _db;
        private ILogger<RuteController> _log;

        public RuteController(IRuteRepository db, ILogger<RuteController> log)
        {
            _db = db;
            _log = log;
        }

        public async Task<ActionResult> HentAlleDestinasjoner()
        {
            List<Destinasjon> alleDestinasjoner = await _db.HentAlleDestinasjoner();
            if(alleDestinasjoner == null)
            {
                _log.LogInformation("Databasen for Destinasjoner er tom!");
                return NotFound("Feil i database! Prøv igjen senere");
            }
            return Ok(alleDestinasjoner);
        }

        public async Task<ActionResult> HentMatchendeRuter(int id)
        {
            List<Rute> alleMatchendeRuter = await _db.HentMatchendeRuter(id);
            if(alleMatchendeRuter == null)
            {
                _log.LogInformation("Fant ikke noen matchende ruter");
                return NotFound("Fant ikke noen matchende ruter");
            }
            return Ok(alleMatchendeRuter);
        }

        public async Task<ActionResult> HentAvganger(int RuteId, DateTime Tid)
        {
            List<Avganger> matchendeAvganger = await _db.HentAvganger(RuteId, Tid);
            if(matchendeAvganger == null)
            {
                _log.LogInformation("Fant ingen matchende avganger");
                return NotFound("Fant ingen matchende avganger");
            }
            return Ok(matchendeAvganger);
        }
        public async Task<ActionResult> HentAvgang(int id)
        {
            Avganger avgang = await _db.HentAvgang(id);
            if(avgang == null)
            {
                _log.LogInformation("Fant ikke avgang med id " + id);
                return NotFound("Fant ikke avgang med id" + id);
            }
            return Ok(avgang);
        }
    }
}
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
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
        public RuteController(IRuteRepository db)
        {
            _db = db;
        }

        public async Task<List<Destinasjon>> HentAlleDestinasjoner()
        {
            return await _db.HentAlleDestinasjoner();
        }

        public async Task<List<Rute>> HentMatchendeRuter(int id)
        {
            return await _db.HentMatchendeRuter(id);
        }

        public async Task<List<Avganger>> HentAvganger(int RuteId, DateTime Tid)
        {
            return await _db.HentAvganger(RuteId, Tid);
        }
    }
}
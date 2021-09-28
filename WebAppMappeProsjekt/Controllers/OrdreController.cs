using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
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

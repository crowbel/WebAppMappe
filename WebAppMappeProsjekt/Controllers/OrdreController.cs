using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
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
            return true;
        }

        public async Task<List<BillettOrdre>> HentAlle()
        {
            return null;
        }
    }
}

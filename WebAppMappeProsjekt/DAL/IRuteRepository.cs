using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppMappeProsjekt.Model;
using WebAppMappeProsjekt.Models;

namespace WebAppMappeProsjekt.DAL
{
    public interface IRuteRepository
    {
        Task<List<Destinasjon>> HentAlleDestinasjoner();
        Task<List<Rute>> HentMatchendeRuter(int id);
        Task<List<Avganger>> HentAvganger(int RuteId, DateTime Tid);
        Task<Avganger> HentAvgang(int id);
    }
}

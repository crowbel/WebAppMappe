using System.Collections.Generic;
using System.Threading.Tasks;
using WebAppMappeProsjekt.Model;

namespace WebAppMappeProsjekt.DAL
{
    public interface IOrdreRepository
    {
        Task<bool> LagreOrdre(BillettOrdre innOrdre);
        Task<List<BillettOrdre>> HentAlle();
    }
}

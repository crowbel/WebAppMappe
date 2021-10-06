using System.Collections.Generic;
using System.Threading.Tasks;
using WebAppMappeProsjekt.Model;

namespace WebAppMappeProsjekt.DAL
{
    public interface IOrdreRepository
    {
        Task<int> LagreOrdre(BillettOrdre innOrdre);
        Task<List<BillettOrdre>> HentAlle();
        Task<BillettOrdre> HentEn(int id);
    }
}

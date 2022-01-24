using System.Threading.Tasks;
using BackRestFull.Models;

namespace BackRestFull.Repository
{
    public interface ICurrencyRepository
    {
        Task<ResponseCurrencysDTO> GetAll();
    }
}

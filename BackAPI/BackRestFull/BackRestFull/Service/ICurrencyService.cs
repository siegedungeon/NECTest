using System.Threading.Tasks;
using BackRestFull.Models;

namespace BackRestFull.Service
{
    public interface ICurrencyService
    {
        Task<ResponseCurrencysDTO> GetAll();
    }
}

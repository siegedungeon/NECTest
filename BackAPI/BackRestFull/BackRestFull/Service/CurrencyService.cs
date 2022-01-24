using BackRestFull.Models;
using System.Threading.Tasks;
using BackRestFull.Repository;

namespace BackRestFull.Service
{
    public class CurrencyService : ICurrencyService
    {
        private readonly ICurrencyRepository _currencyRepository;
        public CurrencyService(ICurrencyRepository currencyRepositor)
        {
                _currencyRepository=currencyRepositor;
        }
        public Task<ResponseCurrencysDTO> GetAll()=> _currencyRepository.GetAll();
    }
}

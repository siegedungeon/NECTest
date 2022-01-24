using System.Threading.Tasks;
using FrontAngular.Models;

namespace FrontAngular.Services
{
    public interface IConsumoService
    {
        Task<ResponseCurrencysDTO> GetAll();
    }
}

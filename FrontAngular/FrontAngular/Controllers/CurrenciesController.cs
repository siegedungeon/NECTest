using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FrontAngular.Models;
using FrontAngular.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace FrontAngular.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CurrenciesController : ControllerBase
    {

        private readonly ILogger<CurrenciesController> _logger;
        private readonly IConsumoService _consumoService;

        public CurrenciesController(ILogger<CurrenciesController> logger,IConsumoService seriConsumoService)
        {
            _logger = logger;
            _consumoService=seriConsumoService;
        }

        [HttpGet]
        public async Task<IEnumerable<CurrencyDTO>> Get()
        {
            var result = await _consumoService.GetAll();
            return result.Currencys.ToArray();
        }
    }
}

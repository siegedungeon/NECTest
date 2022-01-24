using System;
using System.Threading.Tasks;
using BackRestFull.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAppRest.Atributes;

namespace BackRestFull.Controllers
{
    [ApiKey]
    [Route("api/[controller]")]
    [ApiController]
    public class CryptoCurrencyController : ControllerBase
    {
        private readonly ICurrencyService _Service;
        public CryptoCurrencyController(ICurrencyService service)
        {
            _Service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var result = await _Service.GetAll();
                return Ok(result);

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}

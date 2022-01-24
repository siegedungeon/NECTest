using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using FrontAngular.Models;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace FrontAngular.Services
{
    public class ConsumoService : IConsumoService
    {
        private readonly IConfiguration _configuration;
        private string apiKey = "";
        private string apiRouteEndpoint = "";

        public ConsumoService(IConfiguration configuration)
        {
            _configuration = configuration;
            apiKey = _configuration.GetValue<string>("ApiKey");
            apiRouteEndpoint = _configuration.GetValue<string>("apiRouteEndpoint");
        }

        public async Task<ResponseCurrencysDTO> GetAll()
        {
            using var client = new HttpClient();
            using var request = new HttpRequestMessage(HttpMethod.Get, apiRouteEndpoint);
            request.Headers.Add("ApiKey", apiKey);
            using var response = await client
                       .SendAsync(request, HttpCompletionOption.ResponseHeadersRead)
                       .ConfigureAwait(false);
            response.EnsureSuccessStatusCode();
            if (response.StatusCode == HttpStatusCode.OK)
            {
                var responseBody = await response.Content.ReadAsStringAsync();

                var returnedObj = JsonConvert.DeserializeObject<ResponseCurrencysDTO>(responseBody);

                return returnedObj;
            }

            return null;
        }
    }
}

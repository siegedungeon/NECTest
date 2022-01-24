using BackRestFull.Models;
using CoinMarketCap;
using CoinMarketCap.Models.Cryptocurrency;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BackRestFull.Repository
{
    public class CurrencyRepository : ICurrencyRepository
    {
        private readonly IConfiguration _configuration;
        private string apiKeyCap = "";
        private CoinMarketCapClient _client;

        public CurrencyRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            apiKeyCap = _configuration.GetValue<string>("AppSettings:ApiKeyCapCurrency");
            _client = new CoinMarketCapClient(apiKeyCap);
        }

        public async Task<ResponseCurrencysDTO> GetAll()
        {
            var currency = _client.GetLatestListings(new ListingLatestParameters());

            var btc = currency.Data.Find(a => a.Symbol == "BTC");
            var ETH = currency.Data.Find(a => a.Symbol == "ETH");
            var BNB = currency.Data.Find(a => a.Symbol == "BNB");
            var USDT = currency.Data.Find(a => a.Symbol == "USDT");
            var ADA = currency.Data.Find( a=> a.Symbol == "ADA");

            var Currencys = new List<CurrencyDTO>()
            {
                {
                    new CurrencyDTO(){
                    Id = btc.Id,
                    Name = btc.Name,
                    Value = btc.Quote["USD"].Price}

                },
                {
                    new CurrencyDTO(){
                        Id = ETH.Id,
                        Name = ETH.Name,
                        Value = ETH.Quote["USD"].Price}
                },
                {
                    new CurrencyDTO(){
                        Id = BNB.Id,
                        Name = BNB.Name,
                        Value = BNB.Quote["USD"].Price}
                },
                {
                    new CurrencyDTO(){
                        Id = USDT.Id,
                        Name = USDT.Name,
                        Value = USDT.Quote["USD"].Price}
                },
                {
                    new CurrencyDTO(){
                        Id = ADA.Id,
                        Name = ADA.Name,
                        Value = ADA.Quote["USD"].Price}
                }
            };

            return new ResponseCurrencysDTO()
            {
                Currencys = Currencys
            };

        }
    }
}

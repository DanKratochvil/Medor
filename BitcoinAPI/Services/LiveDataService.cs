using BitcoinAPI.Interfaces;
using BitcoinAPI.Models;
using BitcoinAPI.Models.CNB;
using BitcoinAPI.Models.CoinDesk;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;

namespace BitcoinAPI.Services
{
    public class LiveDataService : ILiveData
    {
        private readonly AppDbContext _appDbContext;
        private readonly HttpClient httpClient = new();

        public LiveDataService(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<BtcRateData> GetLiveData()
        {
            using var result = await httpClient.GetAsync("https://data-api.coindesk.com/spot/v1/latest/tick?market=coinbase&instruments=BTC-EUR");
            result.EnsureSuccessStatusCode();
            var response = await result.Content.ReadAsStringAsync();
            var rate = JsonConvert.DeserializeObject<CoinDeskResponse>(response)?.Data?.Rate;
            var rateUpdate = DateTimeOffset.FromUnixTimeSeconds(rate?.PriceLastUpdate ?? 0).LocalDateTime;

            return new BtcRateData { RateEUR = rate?.Price ?? 0m, RateEUR_CZK = await GetEurCzkKRate(), RateUpdate = rateUpdate };
        }

        public async Task SaveBtcRateDataAsync(BtcRateData btcRateData)
        {
            await _appDbContext.BtcRateData.AddAsync(btcRateData);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task<decimal> GetEurCzkKRate()
        {
            using var result = await httpClient.GetAsync("https://api.cnb.cz/cnbapi/exrates/daily");
            result.EnsureSuccessStatusCode();
            var response = await result.Content.ReadAsStringAsync();
            var data = JsonConvert.DeserializeObject<CNBResponse>(response)?.Data;
            return data?.FirstOrDefault(r => r.CurrencyCode == "EUR")?.Rate ?? 0m;
        }
    }
}

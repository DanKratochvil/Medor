using BitcoinAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace BitcoinAPI.Interfaces
{
    public interface ILiveData
    {
        public Task<BtcRateData> GetLiveData();
        public Task SaveBtcRateDataAsync(BtcRateData btcRateData);
        public Task<decimal> GetEurCzkKRate();
    }
}

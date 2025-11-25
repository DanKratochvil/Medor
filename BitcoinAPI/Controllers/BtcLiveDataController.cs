using BitcoinAPI.Interfaces;
using BitcoinAPI.Models;
using BitcoinAPI.Models.CNB;
using BitcoinAPI.Models.CoinDesk;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics.Metrics;
using System.Net.Http;
using System.Reflection.Metadata;

namespace BitcoinAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BtcLiveDataController : ControllerBase
    {
        private readonly ILogger<BtcLiveDataController> _logger;
        private readonly HttpClient httpClient = new();
        private readonly ILiveData _liveDataService;

        public BtcLiveDataController(ILogger<BtcLiveDataController> logger, ILiveData liveDataService)
        {
            _logger = logger;
            _liveDataService = liveDataService;
        }

        [HttpGet]
        public async Task<ActionResult<decimal>> GetLiveData()
        {
            var data = await _liveDataService.GetLiveData();
            _logger.LogInformation("Fetched live BTC data: {@data}", data);
            return Ok(data);
        }

        [HttpPost]
        public async Task<IActionResult> PostLiveData(BtcRateData btcRateData)
        {
            await _liveDataService.SaveBtcRateDataAsync(btcRateData);
            _logger.LogInformation("Saved BTC data: {@data}", btcRateData);
            return Ok(btcRateData);
        }
    }
}

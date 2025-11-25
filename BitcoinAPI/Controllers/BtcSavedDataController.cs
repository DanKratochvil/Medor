using BitcoinAPI.Interfaces;
using BitcoinAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace BitcoinAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BtcSavedDataController : ControllerBase
    {
        private readonly ILogger<BtcLiveDataController> _logger;
        private readonly ISavedData _savedDataService;

        public BtcSavedDataController(ILogger<BtcLiveDataController> logger, ISavedData savedDataService)
        {
            _logger = logger;
            _savedDataService = savedDataService;
        }

        [HttpGet()]
        public async Task<ActionResult<List<BtcRateData>>> GetSavedData()
        {
            var data = await _savedDataService.GetBtcRateDataListAsync();
            _logger.LogInformation("Fetched {data.Count} records", data.Count);
            return Ok(data);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSavedData(int id)
        {
            int deleted = await _savedDataService.DeleteBtcRateDataListAsync(id);
            _logger.LogInformation("Deleted {deleted} records with ID {id}", deleted, id);
            return Ok(deleted);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSavedData(int id, BtcRateData btcRateData)
        {
            await _savedDataService.UpdateBtcRateDataListAsync(id, btcRateData.Note);
            _logger.LogInformation("Updated record with ID {id} to have note: {note}", id, btcRateData.Note);
            return Ok();
        }
    }
}

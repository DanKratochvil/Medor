using BitcoinAPI.Models;

namespace BitcoinAPI.Interfaces
{
    public interface ISavedData
    {       
        public Task<List<BtcRateData>> GetBtcRateDataListAsync();
        public Task<int> DeleteBtcRateDataListAsync(int id);
        public Task<int> UpdateBtcRateDataListAsync(int id, string note);
    }
}

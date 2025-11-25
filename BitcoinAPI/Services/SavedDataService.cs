using BitcoinAPI.Models;
using BitcoinAPI.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BitcoinAPI.Services
{
    public class SavedDataService : ISavedData
    {
        private readonly AppDbContext _appDbContext;
        public SavedDataService(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<List<BtcRateData>> GetBtcRateDataListAsync()
        {
            return await _appDbContext.BtcRateData.ToListAsync();
        }

        public async Task<int> DeleteBtcRateDataListAsync(int id)
        {
            return await _appDbContext.BtcRateData.Where(d => d.ID == id).ExecuteDeleteAsync();
        }

        public async Task<int> UpdateBtcRateDataListAsync(int id, string note)
        {
            var data = await _appDbContext.BtcRateData.FindAsync(id);
            if (data != null)
            {
                data.Note = note;
                return await _appDbContext.SaveChangesAsync();
            }

            return 0;
        }
    }
}

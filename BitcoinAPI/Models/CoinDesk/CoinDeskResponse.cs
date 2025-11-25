using Newtonsoft.Json;

namespace BitcoinAPI.Models.CoinDesk
{
    public class CoinDeskResponse
    {
        [JsonProperty("Data")]
        public BtcEur? Data { get; set; }
    }
}

using Newtonsoft.Json;

namespace BitcoinAPI.Models.CoinDesk
{
    public class BtcEur
    {
        [JsonProperty("BTC-EUR")]
        public BtcRate? Rate { get; set; }
    }
}

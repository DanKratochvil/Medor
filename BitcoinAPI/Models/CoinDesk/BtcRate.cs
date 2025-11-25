using Newtonsoft.Json;

namespace BitcoinAPI.Models.CoinDesk
{  
    public class BtcRate
    {
        [JsonProperty("PRICE_LAST_UPDATE_TS")]
        public long? PriceLastUpdate { get; set; }

        [JsonProperty("PRICE")]
        public decimal? Price { get; set; }
    }
}

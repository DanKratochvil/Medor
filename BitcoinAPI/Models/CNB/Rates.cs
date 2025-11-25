using Newtonsoft.Json;

namespace BitcoinAPI.Models.CNB
{
    public class Rates
    {
        [JsonProperty("amount")]
        public int Amount { get; set; }

        [JsonProperty("currencyCode")]
        public string CurrencyCode { get; set; } = string.Empty;

        [JsonProperty("rate")]
        public decimal Rate { get; set; }
    }
}

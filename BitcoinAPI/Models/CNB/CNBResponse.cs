using Newtonsoft.Json;

namespace BitcoinAPI.Models.CNB
{
    public class CNBResponse
    {
        [JsonProperty("rates")]
        public List<Rates>? Data { get; set; }
    }
}

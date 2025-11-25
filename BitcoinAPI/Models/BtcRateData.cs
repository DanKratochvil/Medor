using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace BitcoinAPI.Models
{
    public class BtcRateData
    {
        [JsonIgnore]
        public int ID { get; set; }

        public DateTime RateUpdate { get; set; }

        [Precision(18, 2)]
        public decimal RateEUR { get; set; }

        [Precision(18, 2)]
        public decimal RateCZK { get; set; }

        [Precision(18, 2)]
        public decimal RateEUR_CZK { get; set; }

        public string Note { get; set; } = string.Empty;
    }
}

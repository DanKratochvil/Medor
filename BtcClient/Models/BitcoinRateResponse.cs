using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BtcClient.Models
{
    [Serializable]
    public class BtcRateResponse
    {        
        public int Id { get; set; }
        public DateTime RateUpdate { get; set; }

        public decimal RateEUR { get; set; }

        public decimal RateCZK { get; set; }

        public decimal RateEUR_CZK { get; set; }

        public string Note { get; set; }
    }
}
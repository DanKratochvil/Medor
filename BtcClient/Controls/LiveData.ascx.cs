using BtcClient.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BtcClient.Controls
{
    public partial class LiveData : System.Web.UI.UserControl
    {
        public event EventHandler RatesSaved;

        protected async void Page_PreRender(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                await RefreshGridAsync();
            }
        }

        protected async void btnLive_Click(object sender, EventArgs e)
        {
            await RefreshGridAsync();
        }

        private async Task<BtcRateResponse> GetBitcoinRateAsync()
        {
            using (var response = await Global.HttpClient.GetAsync("api/BtcLiveData"))
            {
                response.EnsureSuccessStatusCode();
                var content = await response.Content.ReadAsStringAsync();
                var rateResponse = JsonConvert.DeserializeObject<BtcRateResponse>(content);
                rateResponse.RateCZK = Math.Round(rateResponse.RateEUR * rateResponse.RateEUR_CZK, 2);
                return rateResponse;
            }
        }

        protected async void btnSave_Click(object sender, EventArgs e)
        {
            var rates = ViewState["Rates"] as BtcRateResponse;
            if (rates != null)
            {
                var json = JsonConvert.SerializeObject(rates);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                using (var response = await Global.HttpClient.PostAsync("api/BtcLiveData", content))
                    response.EnsureSuccessStatusCode();

                RatesSaved.Invoke(this, EventArgs.Empty);
            }
        }

        private async Task RefreshGridAsync()
        {
            var rateResponse = await GetBitcoinRateAsync();
            ViewState["Rates"] = rateResponse;
            gvLiveData.DataSource = new List<BtcRateResponse> { rateResponse };
            gvLiveData.DataBind();
        }
    }
}
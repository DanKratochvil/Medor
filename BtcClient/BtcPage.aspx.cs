using BtcClient.Controls;
using BtcClient.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BtcClient
{
    public partial class BtcPage : System.Web.UI.Page
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            ucLiveData.RatesSaved += async (s, ev) => await ucSavedData.RefreshGridAsync();
        }


        protected void ucFilterControl_FilterApplied(object sender, EventArgs e)
        {
            ucSavedData.FilterData(
                ucFilterControl.FromDate,
                ucFilterControl.ToDate,
                ucFilterControl.MinPrice,
                ucFilterControl.MaxPrice
            );
        }
    }
}
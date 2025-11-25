using BtcClient.Models;
using BtcClient.Helpers;
using Microsoft.Ajax.Utilities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace BtcClient.Controls
{
    public partial class SavedData : System.Web.UI.UserControl
    {
        public void FilterData(DateTime? fromDate, DateTime? toDate, decimal? minPrice, decimal? maxPrice)
        {
            var data = ViewState["SavedData"] as List<BtcRateResponse>;
            if (data == null) return;

            data = data.Where(d =>
                (!fromDate.HasValue || d.RateUpdate >= fromDate.Value) &&
                (!toDate.HasValue || d.RateUpdate <= toDate.Value) &&
                (!minPrice.HasValue || d.RateCZK >= minPrice.Value) &&
                (!maxPrice.HasValue || d.RateCZK <= maxPrice.Value)
            ).ToList();

            gvSavedData.DataSource = data;
            gvSavedData.DataBind();
        }

        public async Task RefreshGridAsync()
        {
            using (var response = await Global.HttpClient.GetAsync("api/BtcSavedData"))
            {
                response.EnsureSuccessStatusCode();
                var content = await response.Content.ReadAsStringAsync();
                var rateResponse = JsonConvert.DeserializeObject<List<BtcRateResponse>>(content);
                gvSavedData.DataSource = new List<BtcRateResponse>(rateResponse);
                ViewState["SavedData"] = gvSavedData.DataSource;
                gvSavedData.DataBind();
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected async void Page_PreRender(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                await RefreshGridAsync();
            }
        }


        protected async void btnRefresh_Click(object sender, EventArgs e)
        {
            await RefreshGridAsync();
        }

        protected async void gvSavedData_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int id = (int)gvSavedData.DataKeys[e.RowIndex].Value;
            using (var response = await Global.HttpClient.DeleteAsync($"api/BtcSavedData/{id}"))
            {
                response.EnsureSuccessStatusCode();
            }
            await RefreshGridAsync();
        }

        protected async void gvSavedData_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvSavedData.EditIndex = e.NewEditIndex;
            await RefreshGridAsync();
        }

        protected async void gvSavedData_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int id = (int)gvSavedData.DataKeys[e.RowIndex].Value;
            var txtNote = e.NewValues["Note"]?.ToString();
           
            if (!String.IsNullOrEmpty(txtNote))
            {
                var content = new StringContent(JsonConvert.SerializeObject(new BtcRateResponse { Note = txtNote }), Encoding.UTF8, "application/json");
                using (var response = await Global.HttpClient.PutAsync($"api/BtcSavedData/{id}", content))
                {
                    response.EnsureSuccessStatusCode();
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Poznámka musí být vyplněna!');", true);
            }

            gvSavedData.EditIndex = -1;
            await RefreshGridAsync();
        }

        protected async void gvSavedData_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvSavedData.EditIndex = -1;
            await RefreshGridAsync();
        }

        protected void gvSavedData_Sorting(object sender, GridViewSortEventArgs e)
        {
            var saved = ViewState["SavedData"] as List<BtcRateResponse>;
            DataTable dt = Conversion.ToDataTable<BtcRateResponse>(saved);
            if (dt != null)
            {
                string sortDirection = ViewState["SortDirection"] as string ?? "ASC";
                sortDirection = (sortDirection == "ASC") ? "DESC" : "ASC";
                ViewState["SortDirection"] = sortDirection;

                dt.DefaultView.Sort = e.SortExpression + " " + sortDirection;
                gvSavedData.DataSource = dt;
                gvSavedData.DataBind();
            }
        }
    }
}
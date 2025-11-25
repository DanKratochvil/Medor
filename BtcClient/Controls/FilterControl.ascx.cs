using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BtcClient.Controls
{
    public partial class FilterControl : System.Web.UI.UserControl
    {
        public event EventHandler FilterApplied;

        public DateTime? FromDate
        {
            get
            {
                return DateTime.TryParse(txtFromDate.Text, out var dt) ? dt : (DateTime?)null;
            }
        }

        public DateTime? ToDate
        {
            get
            {
                return DateTime.TryParse(txtToDate.Text, out var dt) ? dt : (DateTime?)null;
            }
        }

        public decimal? MinPrice
        {
            get
            {
                return decimal.TryParse(txtMinPrice.Text, out var val) ? val : (decimal?)null;
            }
        }

        public decimal? MaxPrice
        {
            get
            {
                return decimal.TryParse(txtMaxPrice.Text, out var val) ? val : (decimal?)null;
            }
        }
                
        protected void btnClearFilter_Click(object sender, EventArgs e)
        {
            txtFromDate.Text = String.Empty;
            txtToDate.Text = String.Empty;
            txtMinPrice.Text = String.Empty;
            txtMaxPrice.Text = String.Empty;
        }

        protected void btnApplyFilter_Click(object sender, EventArgs e)
        {
            FilterApplied?.Invoke(this, EventArgs.Empty);
        }
    }
}
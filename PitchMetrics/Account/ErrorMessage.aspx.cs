using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PitchMetrics
{
    public partial class ErrorMessage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Exception ex = (Exception)Session["Exception"];
            ex = Server.GetLastError();
            lblError.Text = ex.Message;
        }
    }
}
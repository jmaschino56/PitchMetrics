using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PitchMetrics
{
    public partial class PitchRecap : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string FirstName = (string)Session["FirstName"];
            string LastName = (string)Session["LastName"];
            string nameString = FirstName + " " + LastName;
        }
        protected string dataString(string name)
        {
            string data = "";
            return data;
        }

        protected void gvPitches_PreRender(object sender, EventArgs e)
        {

            if (gvPitches.Rows.Count > 0)
            {
                gvPitches.HeaderRow.Cells[0].HorizontalAlign = HorizontalAlign.Center;
                gvPitches.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        
        }

    }
}
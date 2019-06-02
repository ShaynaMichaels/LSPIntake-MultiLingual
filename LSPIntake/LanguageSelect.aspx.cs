using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LSPIntake
{
    public partial class LanguageSelect : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //lblDebug.Text = "RandomId = " + Session["RandomId"] + " & Email = " + Session["email"];

        }

        protected void rblLanguageSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            Session["language"] = rblLanguageSelect.SelectedValue;

            Response.Redirect("IntakeForm.aspx");
        }
    }
}
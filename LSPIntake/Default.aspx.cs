using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IdentityModel;
using System.Configuration;


namespace LSPIntake
{
    public partial class redirecter : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!(IsPostBack))
            {
                int intDebug = 1;
                if (intDebug == 1)
                {
                    Session["Debug"] = 1;
                    Session["email"] = "moshe.handel@gmail.com";
                    Session["nameidentifier"] = "google-oauth2|117708636609462028155";
                    Session["guid"] = "google-oauth2|117708636609462028155";
                    Response.Redirect("LanguageSelect.aspx");
                }
                //if nothing in querystring, return to login
                if (string.IsNullOrEmpty(Request.QueryString["email"]) && string.IsNullOrEmpty(Request.QueryString["RandomID"]) && intDebug == 0)
                {
                    Response.Redirect("https://login2.nbn.org.il/Account/Claims?Application=LSP");
                    //lblDebugtext.Text = "empty query string";
                }

                //if email, RandomID, and nameidentifier in querystring, proceed with auth0 login
                else if (string.IsNullOrEmpty(Request.QueryString["email"]) == false && string.IsNullOrEmpty(Request.QueryString["RandomID"]) == false && string.IsNullOrEmpty(Request.QueryString["nameidentifier"]) == false)
                {
                    AuthorizationClass oAuthorization = new AuthorizationClass();
                    oAuthorization._strEmail = Request.QueryString["email"];
                    oAuthorization._strNameIdentifier = Request.QueryString["nameidentifier"];
                    oAuthorization._strRandomId = Request.QueryString["RandomID"];
                    oAuthorization.AuthorizationGet(oAuthorization._strEmail, oAuthorization._strNameIdentifier, oAuthorization._strRandomId);
                    oAuthorization._intIsAuthorized = Convert.ToInt32(oAuthorization._dtAuthorization.Rows[0][0]);
                    if (oAuthorization._intIsAuthorized == 1)
                    {
                        Session["email"] = Request.QueryString["email"];
                        Session["nameidentifier"] = Request.QueryString["nameidentifier"];
                        Session["guid"] = Request.QueryString["nameidentifier"];
                        Response.Redirect("LanguageSelect.aspx");

                    }
                    else
                    {
                        //lblDebugtext.Text = "auth0 login, authorized = " + Convert.ToString(oAuthorization._intIsAuthorized);
                        Response.Redirect("https://www.nbn.org.il/application-error/");
                    }
                   
                    

                }

                else
                {

                    Response.Redirect("https://www.nbn.org.il/application-error/");
                    //lblDebugtext.Text = "RandomId from QueryString = " + Request.QueryString["RandomId"] + " RandomId from database = " + gvAuthInfo.Rows[0].Cells[1].Text;
                }

                }
             }
        }
    }


   
   
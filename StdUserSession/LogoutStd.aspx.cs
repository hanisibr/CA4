using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CA4_10385012
{
    public partial class LogoutStd : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(HttpContext.Current.Session["UserID"] == null)
            {
                Response.Redirect("~/PublicFacing/Join.aspx");
            }
        }

        protected void btnlogout_Click(object sender, EventArgs e)
        {
            Session.Remove("UserID");
            Response.Redirect("~/PublicFacing/Default1.aspx");
        }

        protected void btnback_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/StdUserSession/Product1.aspx");
        }
    }
}
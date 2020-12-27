using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CA4_10385012
{
    public partial class Login : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {

            }
        }

        private bool LoginValid(string UserID, string UserPass)
        {
            int rowcount = 0;

            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConStg"].ConnectionString);

            string validquery = "SELECT COUNT(*) FROM UserAcc WHERE UserID = @UserID AND UserPass = @UserPass";

            SqlCommand cmd = new SqlCommand(validquery, conn);
            cmd.Parameters.AddWithValue("UserID", UserID);
            cmd.Parameters.AddWithValue("UserPass", UserPass);

            conn.Open();
            rowcount = (int)cmd.ExecuteScalar();
            conn.Close();

            return (rowcount == 1);

        }

        private bool GetAdmin(string adminid, string adminpass)
        {
            int rowcount = 0;

            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConStg"].ConnectionString);

            string adminquery = "SELECT COUNT(*) FROM AdminAcc WHERE AdminID = @AdminID AND AdminPass = @AdminPass";

            SqlCommand cmd = new SqlCommand(adminquery, conn);
            cmd.Parameters.AddWithValue("AdminID", adminid);
            cmd.Parameters.AddWithValue("AdminPass", adminpass);

            conn.Open();
            rowcount = (int)cmd.ExecuteScalar();
            conn.Close();

            return (rowcount == 1);
        }

        protected void btnLogIn_Click(object sender, EventArgs e)
        {

            // 2 Session 
            bool UsrLogIn = false;
            bool AdminLogIn = false;
            string userid = string.Empty;
            string password = string.Empty;

            userid = txtUserID.Text;
            password = txtPassword.Text;

            UsrLogIn = LoginValid(userid, password);
            AdminLogIn = GetAdmin(userid, password);

            if(UsrLogIn)
            {
                HttpContext.Current.Session["UserID"] = userid;

                Response.Redirect("~/StdUserSession/Default2.aspx?ID=" + userid);
                
            }
            else if(AdminLogIn)
            {
                HttpContext.Current.Session["AdminID"] = userid;

                Response.Redirect("~/AdminSession/Default3.aspx?ID=" + userid);
            }
            else
            {
                Response.Redirect("Join.aspx");
            }
            txtUserID.Text = string.Empty;
            txtPassword.Text = string.Empty;

       
            
           

          
           


           
        }
    }
}
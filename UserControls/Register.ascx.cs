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
    public partial class Register : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
     
            }
        }
        private void AddUser(string userid, string password)
        {
            SqlConnection con = new
                SqlConnection(ConfigurationManager.ConnectionStrings["ConStg"].ConnectionString);

            string query = "INSERT INTO UserAcc(UserID, UserPass) VALUES (@UserID, @UserPass)";

            SqlCommand cmd = new SqlCommand(query, con);

            cmd.Parameters.AddWithValue("@UserID", userid);
            cmd.Parameters.AddWithValue("@UserPass", password);

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        private bool ValidUsrID(string userid)
        {
            int rowcount = 1;

            SqlConnection con = new
               SqlConnection(ConfigurationManager.ConnectionStrings["ConStg"].ConnectionString);

            string query = "SELECT COUNT(*) FROM UserAcc WHERE UserID = @UserID";

            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@UserID", userid);

            con.Open();

            rowcount = (int)cmd.ExecuteScalar();

            con.Close();

            return (rowcount == 0);
        }

        protected void Unnamed_Click(object sender, EventArgs e)
        {

        }

        protected void btnReg_Click(object sender, EventArgs e)
        {

            if (ValidUsrID(txtUserID.Text))
            {
                AddUser(txtUserID.Text, txtPassword.Text);
                lblRegDone.Text = "Registered Successfully";

            }
            else
            {
                lblRegDone.Text = "Fill in the fields";
            }
            
        }   
    }
}
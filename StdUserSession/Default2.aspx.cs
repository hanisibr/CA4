using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CA4_10385012
{
    public partial class Default2 : System.Web.UI.Page
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConStg"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            if(HttpContext.Current.Session["UserID"] == null)
            {
                Response.Redirect("~/PublicFacing/Join.aspx");
            }
            else
            {
                int ImgID = Convert.ToInt32(Request["DI"]);
                rptdisplay.DataSource = RetrieveImg();
                rptdisplay.DataBind();
            }

        }

        private object RetrieveImg()
        {
            
            DataTable dt = new DataTable();
            
            string query = "SELECT * FROM [Image]";
 
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter(query, conn);
            da.Fill(dt);
            conn.Close();

            return dt;
        }
        
    }
}
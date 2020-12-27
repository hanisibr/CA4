using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CA4_10385012.StdUserSession
{
    public partial class Confirm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                string ProdID = Request["ID"];
                SetToDelete.DataSource = GetProd();
                SetToDelete.DataBind();
            }
        }

        private object GetProd()
        {
            DataTable dt = new DataTable();

            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConStg"].ConnectionString);

            string getquery = "SELECT ProdID, ProdPrice FROM Product";

            SqlDataAdapter da = new SqlDataAdapter(getquery, conn);

            conn.Open();
            da.Fill(dt);
            conn.Close();

            return dt;
        }

        private void DeleteProduct(string prodid)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConStg"].ConnectionString);

            string deletequery = "DELETE FROM Product WHERE ProdID = @ProdID";

            SqlCommand cmd = new SqlCommand(deletequery, conn);
            cmd.Parameters.AddWithValue("@ProdID", prodid);

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        protected void btnDelConf_Command(object sender, CommandEventArgs e)
        {
            string prodID = e.CommandArgument.ToString();

            DeleteProduct(prodID);

            Response.Redirect("~/StdUserSession/Product1.aspx");
        }
    }
}
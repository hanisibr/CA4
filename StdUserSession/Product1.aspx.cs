using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CA4_10385012
{
    public partial class Product1 : System.Web.UI.Page
    {
  
        protected void Page_Load(object sender, EventArgs e)
        {
            Cart shopcart = new Cart();

            if (!IsPostBack)
            {
                string prodID = Request["DD"];
                rptprod.DataSource = GetProd();
                rptprod.DataBind();

                lblProd.Text = "Number of items in the cart " + shopcart.GetProductAmount();
                lblTotal.Text = "Total: €" + shopcart.GetProductTotal();

            }
        }

        private object GetProd()
        {
            DataTable dt = new DataTable();

            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConStg"].ConnectionString);

            string getquery = "SELECT * FROM Product";

            SqlDataAdapter da = new SqlDataAdapter(getquery, conn);

            conn.Open();
            da.Fill(dt);
            conn.Close();

            return dt;    
        }

        protected void btnAddCart_Command(object sender, CommandEventArgs e)
        {
            if(HttpContext.Current.Session["UserID"] == null)
            {
                Response.Redirect("~/PublicFacing/Join.aspx");
            }
            else
            {
                string ProdID;

                ProdID = e.CommandArgument.ToString();

                Products pdt = new Products();
                Cart shopcart = new Cart();

                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConStg"].ConnectionString);

                string query = "SELECT * FROM Product WHERE ProdID = @ProdID";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ProdID", ProdID);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    pdt.ProductID = reader["ProdID"].ToString();
                    pdt.ProductName = reader["ProdName"].ToString();
                    pdt.Description = reader["ProdDesc"].ToString();
                    pdt.Price = Convert.ToDecimal(reader["ProdPrice"]);
                }

                shopcart.AddProd(pdt);

                lblProd.Text = "No. of items in the cart" + shopcart.GetProductAmount();
                lblTotal.Text = "Total €" + shopcart.GetProductTotal();

                Response.Redirect("~/StdUserSession/Cart.aspx?ID=" + ProdID);
            }
            

        }
    }
}
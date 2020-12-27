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
    public partial class Cart1 : System.Web.UI.Page
    {
        Products pdt = new Products();
        Cart shopcart = new Cart();
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConStg"].ConnectionString);


        protected void Page_Load(object sender, EventArgs e)
        {

            if (HttpContext.Current.Session["UserID"] == null)
            {
                Response.Redirect("~/PublicFacing/Join.aspx");
            }
            else if(!IsPostBack)
            {
                DisplayCart();

            }

        }

        protected void btnDeleteCart_Command(object sender, CommandEventArgs e)
        {
            string prodID = e.CommandArgument.ToString();
            string query = "SELECT * FROM Product WHERE ProdID = @ProdID";

            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@ProdID", prodID);

            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                pdt.ProductID = reader["ProdID"].ToString();
                pdt.ProductName = reader["ProdName"].ToString();
                pdt.Description = reader["ProdDesc"].ToString();
                pdt.Price = Convert.ToDecimal(reader["ProdPrice"]);
            }

            shopcart.DeleteFromCart(pdt);
            DisplayCart();

        }
        private void DisplayCart()
        {
            rptcart.DataSource = shopcart.GetTheCart();
            rptcart.DataBind();
            lblFinalTotal.Text = "Your Cart Total is €" + shopcart.GetProductTotal();
        }

    }

}
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
    public partial class Product : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (HttpContext.Current.Session["AdminID"] == null)
            {
                Response.Redirect("~/PublicFacing/Join.aspx");
            }
            else if (!IsPostBack)
            {
                rptProdInfo.DataSource = GetProductInfo();
                rptProdInfo.DataBind();
            }
        }

        private object GetProductInfo()
        {
            DataTable dt = new DataTable();

            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConStg"].ConnectionString);

            string query = "SELECT * FROM Product";

            SqlDataAdapter da = new SqlDataAdapter(query, conn);

            conn.Open();
            da.Fill(dt);
            conn.Close();

            return dt;

        }


        protected void btnAdd_Click(object sender, EventArgs e)
        {
            if(ProdUpl.HasFile)
            {
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConStg"].ConnectionString);

                string addquery = "INSERT INTO Product(ProdID, ProdImg, ProdName, ProdDesc, ProdPrice) VALUES (@ProdID, @ProdImg, @ProdName, @ProdDesc, @ProdPrice)";
                byte[] imgbytes = new byte[ProdUpl.PostedFile.InputStream.Length + 1];
                ProdUpl.PostedFile.InputStream.Read(imgbytes, 0, imgbytes.Length);

                SqlCommand cmd = new SqlCommand(addquery, conn);

                cmd.Parameters.AddWithValue("@ProdID", txtProdID.Text);
                cmd.Parameters.AddWithValue("@ProdImg", imgbytes);
                cmd.Parameters.AddWithValue("@ProdName", txtProdName.Text);
                cmd.Parameters.AddWithValue("@ProdDesc", txtProdDesc.Text);
                cmd.Parameters.AddWithValue("@ProdPrice", decimal.Parse(txtProdPrice.Text));

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();

                txtProdID.Text = string.Empty;
                txtProdName.Text = string.Empty;
                txtProdDesc.Text = string.Empty;
                txtProdPrice.Text = string.Empty;

                lblsuccess.Text = "Product Add Successfully";
                rptProdInfo.DataSource = GetProductInfo();
                rptProdInfo.DataBind();
            }
 
        }


        protected void BtnDelete_Command(object sender, CommandEventArgs e)
        {
            string prodid = e.CommandArgument.ToString();

            Response.Redirect("~/StdUserSession/Confirm.aspx?ID=" + prodid);
            
         
        }

        protected void btnViewChgs_Command(object sender, CommandEventArgs e)
        {
            string ProdID = e.CommandArgument.ToString();

            Response.Redirect("~/StdUserSession/Product1.aspx?DD=" + ProdID);
        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {

        }
    }
}
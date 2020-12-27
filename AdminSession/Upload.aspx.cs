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
    public partial class Upload : System.Web.UI.Page
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConStg"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            if(HttpContext.Current.Session["AdminID"] == null)
            {
                Response.Redirect("Join.aspx");
            }
            else if(!IsPostBack)
            {
                rptImg.DataSource = GetImg();
                rptImg.DataBind();
            }
        }

        private object GetImg()
        {
            DataTable dt = new DataTable();

            string imgquery = "SELECT * FROM [Image]";

            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter(imgquery, conn);
            da.Fill(dt);
            conn.Close();

            return dt;
        }
        protected void btnUpl_Click(object sender, EventArgs e)
        {
            if(FilUpl.HasFile)
            {
                string fileName = txtName.Text;
                int id = int.Parse(txtID.Text);
                byte[] imgbytes = new byte[FilUpl.PostedFile.InputStream.Length + 1];
                FilUpl.PostedFile.InputStream.Read(imgbytes, 0, imgbytes.Length);

                string query = "INSERT INTO [Image](ImgID, ImgName, ImgType, Img) VALUES (@ImgID, @ImgName, @ImgType, @Img)";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ImgID", id);
                cmd.Parameters.AddWithValue("@ImgName", fileName);
                cmd.Parameters.AddWithValue("@ImgType", FilUpl.PostedFile.ContentType);
                cmd.Parameters.AddWithValue("@Img", imgbytes);

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();

                txtName.Text = string.Empty;
                lblSuccess.Text = "Upload Success";

                rptImg.DataSource = GetImg();
                rptImg.DataBind();
            
            }
            else
            {
                lblSuccess.Text = "Please choose a file";
            }
        }

        protected void btnViewChgs_Command(object sender, CommandEventArgs e)
        {
            int ImgID = Convert.ToInt32(e.CommandArgument.ToString());
 
            Response.Redirect("~/StdUserSession/Default2.aspx?DI=" + ImgID);
            
        }
    }
}
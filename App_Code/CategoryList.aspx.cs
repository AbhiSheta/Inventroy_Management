using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InventoryManagementSystem
{
    public partial class CategoryList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadCategories();
            }
        }

        private void LoadCategories()
        {
            string connStr = ConfigurationManager.ConnectionStrings["InventoryDBConnection"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string query = "SELECT * FROM Categories";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                GridViewCategories.DataSource = dt;
                GridViewCategories.DataBind();
                if (!string.IsNullOrEmpty(Request.QueryString["msg"]))
                {
                    string msg = Request.QueryString["msg"];
                    ltScript.Text = $"<script>alert('{msg}');</script>";
                }

            }
        }

        protected void GridViewCategories_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = Convert.ToInt32(e.CommandArgument);
            string categoryId = GridViewCategories.DataKeys[index].Value.ToString();

            if (e.CommandName == "EditCategory")
            {
                Response.Redirect("EditCategory.aspx?CategoryID=" + categoryId);
            }
            else if (e.CommandName == "DeleteCategory")
            {
                DeleteCategory(categoryId);
                LoadCategories();
            }
        }

        private void DeleteCategory(string categoryId)
        {
            string connStr = ConfigurationManager.ConnectionStrings["InventoryDBConnection"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string query = "DELETE FROM Categories WHERE CategoryID = @CategoryID";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@CategoryID", categoryId);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
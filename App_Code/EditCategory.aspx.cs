using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InventoryManagementSystem
{
    public partial class EditCategory : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string id = Request.QueryString["CategoryID"];
                if (string.IsNullOrEmpty(id))
                {
                    Response.Redirect("CategoryList.aspx");
                }
                else
                {
                    LoadCategory(id);
                }
            }
        }

        private void LoadCategory(string id)
        {
            string connStr = ConfigurationManager.ConnectionStrings["InventoryDBConnection"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string query = "SELECT * FROM Categories WHERE CategoryID = @CategoryID";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@CategoryID", id);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    hfCategoryID.Value = reader["CategoryID"].ToString();
                    txtName.Text = reader["Name"].ToString();
                    txtDescription.Text = reader["Description"].ToString();
                }
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            string id = hfCategoryID.Value;
            string name = txtName.Text.Trim();
            string description = txtDescription.Text.Trim();

            string connStr = ConfigurationManager.ConnectionStrings["InventoryDBConnection"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string query = "UPDATE Categories SET Name = @Name, Description = @Description WHERE CategoryID = @CategoryID";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Name", name);
                cmd.Parameters.AddWithValue("@Description", description);
                cmd.Parameters.AddWithValue("@CategoryID", id);
                conn.Open();
                cmd.ExecuteNonQuery();
                Response.Redirect("CategoryList.aspx?msg=Category%20updated%20successfully");
            }
        }
    }
}
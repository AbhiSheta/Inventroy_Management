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
    public partial class ProductList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadCategoryFilter();
                LoadProducts();
            }
        }

        private void LoadProducts(string nameFilter = "", string categoryId = "")
        {
            string connStr = ConfigurationManager.ConnectionStrings["InventoryDBConnection"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string query = "SELECT ProductID, Name, Description, Quantity, Price, ImagePath FROM Products WHERE 1=1";
                if (!string.IsNullOrEmpty(nameFilter))
                {
                    query += " AND Name LIKE @Name";
                }
                if (!string.IsNullOrEmpty(categoryId))
                {
                    query += " AND CategoryID = @CategoryID";
                }

                SqlCommand cmd = new SqlCommand(query, conn);
                if (!string.IsNullOrEmpty(nameFilter))
                {
                    cmd.Parameters.AddWithValue("@Name", "%" + nameFilter + "%");
                }
                if (!string.IsNullOrEmpty(categoryId))
                {
                    cmd.Parameters.AddWithValue("@CategoryID", categoryId);
                }

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                GridViewProducts.DataSource = dt;
                GridViewProducts.DataBind();
                if (!string.IsNullOrEmpty(Request.QueryString["msg"]))
                {
                    string msg = Request.QueryString["msg"];
                    ltScript.Text = $"<script>alert('{msg}');</script>";
                }
                
            }
        }
        protected void GridViewProducts_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridViewProducts.PageIndex = e.NewPageIndex;

            string name = txtSearch.Text.Trim();
            string categoryId = ddlFilterCategory.SelectedValue;
            LoadProducts(name, categoryId); 
        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            LoadProducts(txtSearch.Text.Trim(), ddlFilterCategory.SelectedValue);
        }

        protected void ddlFilterCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadProducts(txtSearch.Text.Trim(), ddlFilterCategory.SelectedValue);
        }

        protected void GridViewProducts_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = Convert.ToInt32(e.CommandArgument);
            string productId = GridViewProducts.DataKeys[index].Value.ToString();

            if (e.CommandName == "EditProduct")
            {
                Response.Redirect("EditProduct.aspx?ProductID=" + productId);
            }
            else if (e.CommandName == "DeleteProduct")
            {
                DeleteProduct(productId);
                LoadProducts(); 
            }
        }
        private void DeleteProduct(string productId)
        {
            string connStr = ConfigurationManager.ConnectionStrings["InventoryDBConnection"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string query = "DELETE FROM Products WHERE ProductID = @ProductID";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ProductID", productId);
                
                    string msg = Request.QueryString["msg"];
                    ltScript.Text = $"<script>alert('{msg}');</script>";
                
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
        private void LoadCategoryFilter()
        {
            string connStr = ConfigurationManager.ConnectionStrings["InventoryDBConnection"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string query = "SELECT CategoryID, Name FROM Categories";
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                ddlFilterCategory.DataSource = reader;
                ddlFilterCategory.DataTextField = "Name";
                ddlFilterCategory.DataValueField = "CategoryID";
                ddlFilterCategory.DataBind();

                ddlFilterCategory.Items.Insert(0, new ListItem("-- All Categories --", ""));
            }
        }

        


    }
}
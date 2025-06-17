using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InventoryManagementSystem
{
    public partial class EditProduct : System.Web.UI.Page
    {
        int productId;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!int.TryParse(Request.QueryString["ProductID"], out productId))
            {
                Response.Redirect("ProductList.aspx");
            }

            if (!IsPostBack)
            {
                LoadCategories();
                LoadProductDetails(productId.ToString());
            }
        }


        private void LoadCategories()
        {
            string connStr = ConfigurationManager.ConnectionStrings["InventoryDBConnection"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string query = "SELECT CategoryID, Name FROM Categories";
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                ddlCategory.DataSource = reader;
                ddlCategory.DataTextField = "Name";
                ddlCategory.DataValueField = "CategoryID";
                ddlCategory.DataBind();

                ddlCategory.Items.Insert(0, new ListItem("-- Select Category --", ""));
            }
        }

        private void LoadProductDetails(string productId)
        {
            string connStr = ConfigurationManager.ConnectionStrings["InventoryDBConnection"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string query = "SELECT * FROM Products WHERE ProductID = @ProductID";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ProductID", productId);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    hfProductID.Value = reader["ProductID"].ToString();
                    txtName.Text = reader["Name"].ToString();
                    txtDescription.Text = reader["Description"].ToString();
                    txtQuantity.Text = reader["Quantity"].ToString();
                    txtPrice.Text = reader["Price"].ToString();
                    ddlCategory.SelectedValue = reader["CategoryID"].ToString();
                    if (!string.IsNullOrEmpty(reader["ImagePath"].ToString()))
                    {
                        imgCurrent.ImageUrl = reader["ImagePath"].ToString();
                    }
                }
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            string connStr = ConfigurationManager.ConnectionStrings["InventoryDBConnection"].ConnectionString;
            string newImagePath = imgCurrent.ImageUrl;

            if (fuImage.HasFile)
            {
                string fileName = Path.GetFileName(fuImage.FileName);
                newImagePath = "~/Images/" + fileName;
                string physicalPath = Server.MapPath(newImagePath);
                fuImage.SaveAs(physicalPath);
            }

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string query = @"UPDATE Products 
                                 SET Name = @Name,
                                     Description = @Description,
                                     Quantity = @Quantity,
                                     Price = @Price,
                                     CategoryID = @CategoryID,
                                     ImagePath = @ImagePath
                                 WHERE ProductID = @ProductID";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Name", txtName.Text);
                cmd.Parameters.AddWithValue("@Description", txtDescription.Text);
                cmd.Parameters.AddWithValue("@Quantity", txtQuantity.Text);
                cmd.Parameters.AddWithValue("@Price", txtPrice.Text);
                cmd.Parameters.AddWithValue("@CategoryID", ddlCategory.SelectedValue);
                cmd.Parameters.AddWithValue("@ImagePath", newImagePath);
                cmd.Parameters.AddWithValue("@ProductID", productId);

                conn.Open();
                cmd.ExecuteNonQuery();
                Response.Redirect("ProductList.aspx?msg=Product%20updated%20successfully");

            }
        }
    }
}
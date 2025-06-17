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
    public partial class AddProduct : System.Web.UI.Page
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
                string query = "SELECT CategoryID, Name FROM Categories";
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                ddlCategory.DataSource = reader;
                ddlCategory.DataTextField = "Name";
                ddlCategory.DataValueField = "CategoryID";
                ddlCategory.DataBind();
                conn.Close();
            }

            ddlCategory.Items.Insert(0, new System.Web.UI.WebControls.ListItem("-- Select Category --", ""));
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            string connStr = ConfigurationManager.ConnectionStrings["InventoryDBConnection"].ConnectionString;
            string imagePath = null;

            if (fuImage.HasFile)
            {
                string fileName = Path.GetFileName(fuImage.FileName);
                imagePath = "~/Images/" + fileName;
                string physicalPath = Server.MapPath(imagePath);
                fuImage.SaveAs(physicalPath);
            }

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string query = @"INSERT INTO Products 
                        (Name, Description, Quantity, Price, CategoryID, ImagePath) 
                        VALUES 
                        (@Name, @Description, @Quantity, @Price, @CategoryID, @ImagePath)";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Name", txtName.Text);
                cmd.Parameters.AddWithValue("@Description", txtDescription.Text);
                cmd.Parameters.AddWithValue("@Quantity", txtQuantity.Text);
                cmd.Parameters.AddWithValue("@Price", txtPrice.Text);
                cmd.Parameters.AddWithValue("@CategoryID", ddlCategory.SelectedValue);
                cmd.Parameters.AddWithValue("@ImagePath", (object)imagePath ?? DBNull.Value);

                conn.Open();
                cmd.ExecuteNonQuery();

                lblMessage.Text = "Product added successfully!";
            }
        }


        private void ClearForm()
        {
            txtName.Text = "";
            txtDescription.Text = "";
            txtQuantity.Text = "";
            txtPrice.Text = "";
            ddlCategory.SelectedIndex = 0;
        }
    


       
    }
}
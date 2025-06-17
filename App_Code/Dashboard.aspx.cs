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
    public partial class Dashboard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Username"] == null)
            {
                Response.Redirect("Login.aspx");
            }

            
                if (!IsPostBack)
                {
                    LoadSummary();
                    LoadLowStockAlerts();
                }
            }
        

        private void LoadSummary()
        {
            string connStr = ConfigurationManager.ConnectionStrings["InventoryDBConnection"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();

                SqlCommand cmd1 = new SqlCommand("SELECT COUNT(*) FROM Products", conn);
                lblTotalProducts.Text = cmd1.ExecuteScalar().ToString();

                SqlCommand cmd2 = new SqlCommand("SELECT COUNT(*) FROM Categories", conn);
                lblTotalCategories.Text = cmd2.ExecuteScalar().ToString();

                SqlCommand cmd3 = new SqlCommand("SELECT SUM(Quantity) FROM Products", conn);
                lblTotalQuantity.Text = Convert.ToString(cmd3.ExecuteScalar() ?? 0);

                SqlCommand cmd4 = new SqlCommand("SELECT SUM(Quantity * Price) FROM Products", conn);
                decimal totalValue = Convert.ToDecimal(cmd4.ExecuteScalar() ?? 0);
                lblTotalValue.Text = totalValue.ToString("N2");
            }
        }
        protected void btnAddProduct_Click(object sender, EventArgs e)
{
    Response.Redirect("AddProduct.aspx");
}

protected void btnAddCategory_Click(object sender, EventArgs e)
{
    Response.Redirect("AddCategory.aspx");
}

protected void lnkTotalProducts_Click(object sender, EventArgs e)
{
    Response.Redirect("ProductList.aspx");
}
        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("Login.aspx");
        }
        protected void lnkTotalCategories_Click(object sender, EventArgs e)
        {
            Response.Redirect("CategoryList.aspx");
        }
        private void LoadLowStockAlerts()
        {
            string connStr = ConfigurationManager.ConnectionStrings["InventoryDBConnection"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT Name, Quantity FROM Products WHERE Quantity < 10", conn);
                SqlDataReader reader = cmd.ExecuteReader();
                List<string> lowStockItems = new List<string>();

                while (reader.Read())
                {
                    string productName = reader["Name"].ToString();
                    int quantity = Convert.ToInt32(reader["Quantity"]);
                    lowStockItems.Add($"{productName} (Qty: {quantity})");
                }

                rptLowStock.DataSource = lowStockItems;
                rptLowStock.DataBind();

                divLowStock.Visible = lowStockItems.Count > 0;
            }
        }


    }
}
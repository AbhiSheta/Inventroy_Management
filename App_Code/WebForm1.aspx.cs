using System;
using System.Data.SqlClient;
namespace InventoryManagementSystem
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string connStr = System.Configuration.ConfigurationManager.ConnectionStrings["InventoryDBConnection"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                try
                {
                    conn.Open();
                    Response.Write("✅ Connection successful!");
                }
                catch (Exception ex)
                {
                    Response.Write("❌ Connection failed: " + ex.Message);
                }
            }
        }
    }
}


// use chat window
// add error handling
namespace BuggyBits4.Pages
{
    using BuggyBits4.Common;
    using System;
    using System.Data;

    public partial class AllProducts : System.Web.UI.Page
    {
        private readonly DataLayer dataLayer = new DataLayer();

        protected void Page_Load(object sender, EventArgs e)
        {
            // add error handling
            DataTable dt = dataLayer.GetAllProducts();
            string ProductsTable = "<table><tr><td><B>Product ID</B></td><td><B>Product Name</B></td><td><B>Description</B></td></tr>";

            foreach (DataRow dr in dt.Rows)
            {
                ProductsTable += "<tr><td>" + dr[0] + "</td><td>" + dr[1] + "</td><td>" + dr[2] + "</td></tr>";
            }
            ProductsTable += "</table>";
            tblProducts.Text = ProductsTable;
        }

        protected void ClearCacheAndHeap()
        {
            // Clear the cache memory
            Cache.Clear();

            // Clear the heap memory
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
        }
    }
}
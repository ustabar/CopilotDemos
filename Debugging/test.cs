using System;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Mvc;

namespace SqlDumpDemo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            string connectionString = "YourConnectionString"; // replace with your connection string
            string queryString = "YourSqlQuery"; // replace with your SQL query

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Console.WriteLine(String.Format("{0}", reader[0]));
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            return Ok("Query executed. Check the console for output.");
        }
    }
}
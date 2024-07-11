using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Diagnostics;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using System.Net.Security;
using System.Net.Sockets;
using ticket_system.Data;
using ticket_system.Pages.Tickets;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace ticket_system.Pages.Customers
{
    public class NewCustomerModel : PageModel
    {
        public Customer customer = new Customer();
        public string errorMessage = "";
        public string successMessage = "";
        public void OnGet()
        {
        }
        public IActionResult OnPost()
        {
            customer.Name = Request.Form["name"];

            if (customer.Name.Length == 0)
            {
                errorMessage = "All fields are required";
                return Page();
            }

            try
            {
                string connectionString = "Server=LAPTOP-97T368JO;Database=Ticket_Problem;Trusted_Connection=True; TrustServerCertificate=True;";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string sql = "INSERT INTO Customers (Name)" +
                        "VALUES (@name);";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@name", customer.Name);
                        command.ExecuteNonQuery();
                    }

                    string idQurry ="SELECT ID FROM Customers WHERE Name = @name";
                    int cId = -1;
                    using(SqlCommand command = new SqlCommand(idQurry, connection))
                    {
                        command.Parameters.AddWithValue("@name", customer.Name);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                cId = reader.GetInt32(0);
                            }
                        }    
                    }
                    return RedirectToPage("/Customers/CustomerTickets", new { id = cId });
                }
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                return Page();
            }

            //return RedirectToPage("/Customers/CustomerTickets");
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Diagnostics;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using System.Net.Security;
using ticket_system.Data;
using ticket_system.Pages.Tickets;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace ticket_system.Pages.Customers
{
    public class NewTicketModel : PageModel
    {
        public TicketInfo ticket = new TicketInfo();
        public Customer customer = new Customer();
        public string errorMessage = "";
        public string successMessage = "";

        public void OnGet()
        {
            customer.id = Request.Query["id"];
        }
        public IActionResult OnPost()
        {
            //String customerName = Request.Query["ID"];
            ticket.problem = Request.Form["Problem"];
            customer.id = Request.Query["id"];




            //If the somthing is not filled in
            if (ticket.problem.Length == 0)
            {
                errorMessage = "All fields are required";
                return Page();
            }
            //save the new Ticket to database

            try
            {
                string connectionString = "Server=LAPTOP-97T368JO;Database=Ticket_Problem;Trusted_Connection=True; TrustServerCertificate=True;";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    //Status Link
                    string statusQuarry = "SELECT ID FROM Statuses WHERE TicketStatus = 'Open'";
                    int statusID;
                    using (SqlCommand command = new SqlCommand(statusQuarry, connection))
                    {
                        statusID = Convert.ToInt32(command.ExecuteScalar());
                    }

                    /*
                    string customerQuarry = "SELECT ID FROM Customers WHERE Name = @name";
                    using(SqlCommand sqlCommand = new SqlCommand(customerQuarry, connection))
                    {
                        sqlCommand.Parameters.AddWithValue("@name", customerName);
                        customerId = Convert.ToInt32(sqlCommand.ExecuteScalar());
                    }
                     */

                    //new Ticket insert 
                    string insertTicketQuarry = "INSERT INTO Tickets (CustomerID, StatusID, Problem) " +
                            "VALUES (@name, @statusId, @problem);";
                    using (SqlCommand command = new SqlCommand(insertTicketQuarry, connection))
                    {
                        command.Parameters.AddWithValue("@statusId", statusID);
                        command.Parameters.AddWithValue("@name", customer.id);//customerId
                        command.Parameters.AddWithValue("@problem", ticket.problem);
                        command.ExecuteNonQuery();
                    }
                }
                successMessage = "New Ticket Entered";
                //after a sucsessfull submition go back to the list of tickets of the customer tickets
                return RedirectToPage("/Customers/CustomerTickets", new { id = customer.id });
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                return Page();
            }

            //ticket.customer = ""; ticket.problem = "";
            //successMessage = "New Ticket Entered";
            //Response.Redirect("/Customer/CustomerTickets?id=customerId");
        }
    }
}

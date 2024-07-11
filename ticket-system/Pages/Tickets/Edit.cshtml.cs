using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using System.Security.Cryptography;

namespace ticket_system.Pages.Tickets
{
    public class EditModel : PageModel
    {
        
        public TicketInfo ticketInfo = new TicketInfo();
        public String errorMessage = "";
        public String succsesMessage = "";
        public void OnGet()
        {
            String id = Request.Query["id"];

            ticketInfo.id = id;

            try
            {
                String connectionString = "Server=LAPTOP-97T368JO;Database=Ticket_Problem;Trusted_Connection=True; TrustServerCertificate=True;";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    String getProblem = "SELECT Problem FROM Tickets WHERE id = @id;";
                    using (SqlCommand command = new SqlCommand(getProblem, connection))
                    {
                        command.Parameters.AddWithValue("@id", id);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if(reader.Read())
                                ticketInfo.problem = reader.GetString(0);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
            }
        }

        public void OnPost() 
        {
            int Cid;
            ticketInfo.id = Request.Form["id"];
            ticketInfo.problem = Request.Form["problem"];

            if (ticketInfo.problem.Length == 0)
            {
                errorMessage = "All Fields are required";
                return;
            }

            try
            {
                string connectionString = "Server=LAPTOP-97T368JO;Database=Ticket_Problem;Trusted_Connection=True; TrustServerCertificate=True;";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    String sql = "SELECT CustomerID FROM Tickets WHERE Tickets.ID = @ID";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@ID", ticketInfo.id);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                Cid = reader.GetInt32(0);
                            }
                            else
                            {
                                Cid = -1;
                            }
                        }
                    }
                    String UpDateSql = "UPDATE Tickets SET problem=@problem WHERE id=@id";
                    using (SqlCommand command = new SqlCommand(UpDateSql, connection))
                    {
                        command.Parameters.AddWithValue("@problem", ticketInfo.problem);
                        command.Parameters.AddWithValue("@id", ticketInfo.id);

                        command.ExecuteNonQuery();
                    }
                }
            } catch (Exception ex)
            {
                errorMessage = ex.Message;
                Console.WriteLine("An error occurred: " + ex.Message);
                return;
            }
            // Come back to this________________________*****
            //return RedirectToAction("CustomerTickets",new {id = Cid});
            Response.Redirect($"/Customers/CustomerTickets?id={Cid}");
        }
    }
}

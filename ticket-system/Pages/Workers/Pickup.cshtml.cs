using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;

namespace ticket_system.Pages.Workers
{
    //public class PickupModel : PageModel
    //{
    //    public class Pickup : PageModel
    //    {
            

    //        public void OnGet()
    //        {

    //        }
    //        public IActionResult OnPost()
    //        {
    //            Worker worker = new Worker();
    //            TicketInfo ticket = new TicketInfo();
    //            worker.id = Request.Form["id"];
    //            ticket.id = Request.Form["ticketId"];

    //            try
    //            {
    //                String connnectionString = "Server=LAPTOP-97T368JO;Database=Ticket_Problem;Trusted_Connection=True; TrustServerCertificate=True;";
    //                using (SqlConnection connection = new SqlConnection(connnectionString))
    //                {
    //                    connection.Open();
    //                    String sqlStatus = "SELECT ID FROM Statuses WHERE TicketStatus = 'In Progress'";

    //                    using (SqlCommand command = new SqlCommand(sqlStatus, connection))
    //                    {
    //                        using (SqlDataReader reader = command.ExecuteReader())
    //                        {
    //                            if (reader.Read())
    //                                ticket.status = "" + reader.GetInt32(0);
    //                        }
    //                    }

    //                    String ticketQurry = "UPDATE Tickets SET WorkerID = @wId, StatusID = @sId WHERE Tickets.ID = @tId";

    //                    using (SqlCommand command = new SqlCommand(ticketQurry, connection))
    //                    {
    //                        command.Parameters.AddWithValue("@wId", worker.id);
    //                        command.Parameters.AddWithValue("@sId", ticket.status);
    //                        command.Parameters.AddWithValue("@tId", ticket.id);

    //                        command.ExecuteNonQuery();
    //                    }
    //                }

    //                return RedirectToPage("/Workers/availableTickets", new { id = worker.id });
    //            }
    //            catch (Exception ex)
    //            {
    //                Console.WriteLine("An error occurred: " + ex.Message);
    //                return Page();
    //            }
    //        }

    //    }
    //    public class TicketInfo
    //    {
    //        public String? id;
    //        public String? worker;
    //        public String? customer;
    //        public String? status;
    //        public String? problem;
    //    }
    //}
}

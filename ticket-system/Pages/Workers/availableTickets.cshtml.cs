using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using System.Net.NetworkInformation;
using ticket_system.Data;

namespace ticket_system.Pages.Workers
{
    public class availableTicketsModel : PageModel
    {
        public Status status = new Status();
        public Worker worker = new Worker();
        public List<TicketInfo> listTickets = new List<TicketInfo>();
        
        public void OnGet()
        {
            worker.id = Request.Query["id"];

            try
            {
                
                String connnectionString = "Server=LAPTOP-97T368JO;Database=Ticket_Problem;Trusted_Connection=True; TrustServerCertificate=True;";

                using (SqlConnection connection = new SqlConnection(connnectionString))
                {
                    connection.Open();

                    String sqlStatusID = "SELECT ID FROM Statuses WHERE TicketStatus = 'Open'";
                    using (SqlCommand command = new SqlCommand(sqlStatusID, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if(reader.Read())
                                status.ID = reader.GetInt32(0);
                        }
                    }


                    String sqlQurry = "SELECT Tickets.ID, Workers.Name, Customers.Name, Statuses.TicketStatus, Tickets.Problem " +
                                      "FROM Tickets " +
                                      "INNER JOIN Customers ON Tickets.CustomerID = Customers.ID " +
                                      "LEFT JOIN Workers ON Tickets.WorkerID = Workers.ID " +
                                      "INNER JOIN Statuses ON  Tickets.StatusID = Statuses.ID " +
                                      "WHERE Tickets.StatusID = @SID;";

                    using (SqlCommand command = new SqlCommand(sqlQurry, connection))
                    {
                        command.Parameters.AddWithValue("@SID", status.ID);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                TicketInfo ticketInfo = new TicketInfo();

                                ticketInfo.id = "" + reader.GetInt32(0);

                                if (reader.IsDBNull(1))
                                    ticketInfo.worker = "N/A";
                                else
                                    ticketInfo.worker = reader.GetString(1);

                                ticketInfo.customer = reader.GetString(2);
                                ticketInfo.status = reader.GetString(3); ;
                                ticketInfo.problem = reader.GetString(4);

                                listTickets.Add(ticketInfo);
                            }
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.ToString());
            }

        }

        public class TicketInfo
        {
            public String? id;
            public String? worker;
            public String? customer;
            public String? status;
            public String? problem;
        }
    }

}

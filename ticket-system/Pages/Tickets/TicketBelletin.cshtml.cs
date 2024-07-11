using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;



namespace ticket_system.Pages.Tickets
{
    public class TicketBelletinModel : PageModel
    {
        public List<TicketInfo> listTickets = new List<TicketInfo>();

        public void OnGet()
        {
            try
            {
                String connnectionString = "Server=LAPTOP-97T368JO;Database=Ticket_Problem;Trusted_Connection=True; TrustServerCertificate=True;";

                using (SqlConnection connection = new SqlConnection(connnectionString))
                {
                    connection.Open();

                    String sql = "SELECT Tickets.ID, Workers.Name, Customers.Name, Statuses.TicketStatus, Tickets.Problem " +
                                 "FROM Tickets " +
                                 "INNER JOIN Customers ON Tickets.CustomerID = Customers.ID " +
                                 "LEFT JOIN Workers ON Tickets.WorkerID = Workers.ID " +
                                 "INNER JOIN Statuses ON  Tickets.StatusID = Statuses.ID ";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                TicketInfo ticketInfo = new TicketInfo();

                                ticketInfo.id = "" + reader.GetInt32(0);

                                if (reader.IsDBNull(1))
                                    ticketInfo.worker = "N/A";
                                else
                                    ticketInfo.worker =reader.GetString(1);

                                ticketInfo.customer = reader.GetString(2);
                                ticketInfo.status = reader.GetString(3); ;
                                ticketInfo.problem = reader.GetString(4);

                                listTickets.Add(ticketInfo);
                            }
                        }
                    }
                    
                }

            }
            catch  (Exception ex)
            { 
                Console.WriteLine("Exception: " + ex.ToString()); 
            }

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

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using ticket_system.Data;
using ticket_system.Pages.Tickets;
using static ticket_system.Pages.Customers.CustomerTicketsModel;

namespace ticket_system.Pages.Customers
{
    public class CustomerTicketsModel : PageModel
    {
        public String? customerName;
        public Customer customer = new Customer();
        public List<TicketInfo> listTickets = new List<TicketInfo>();
        public void OnGet()
        {
            customer.id = Request.Query["id"];

            try
            {
                String connectionString = "Server=LAPTOP-97T368JO;Database=Ticket_Problem;Trusted_Connection=True; TrustServerCertificate=True;";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    String ReturnName = "SELECT Name FROM Customers WHERE ID = @ID";
                    using (SqlCommand command = new SqlCommand(ReturnName,connection))
                    {
                        command.Parameters.AddWithValue("@ID", customer.id);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                                customerName = reader.GetString(0);
                        }
                    }

                    //The propper id is showing for all the section of the list now i just need to show what the id's are pointing to. 
                    //String sql = "SELECT * FROM Tickets WHERE customerID = @ID;"; 

                    String sql = "SELECT Tickets.ID, Workers.Name, Customers.Name, Statuses.TicketStatus, Tickets.Problem " +
                                 "FROM Tickets " +
                                 "INNER JOIN Customers ON Tickets.CustomerID = Customers.ID " +
                                 "LEFT JOIN Workers ON Tickets.WorkerID = Workers.ID " +
                                 "INNER JOIN Statuses ON  Tickets.StatusID = Statuses.ID " +
                                 "WHERE customerID = @ID;";
                    /*using (SqlCommand command = new SqlCommand(sql, connection)) 
                    {
                        command.Parameters.AddWithValue("@ID", customerId);

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

                                ticketInfo.customer = "" + reader.GetInt32(2);
                                ticketInfo.status = "" + reader.GetInt32(3); ;
                                ticketInfo.problem = reader.GetString(4);

                                listTickets.Add(ticketInfo);
                            }
                        }
                    }*/
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@ID", customer.id);

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

                                ticketInfo.customer = "" + reader.GetString(2);
                                ticketInfo.status = "" + reader.GetString(3);
                                ticketInfo.problem = reader.GetString(4);

                                listTickets.Add(ticketInfo);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
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

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;

namespace ticket_system.Pages.Workers
{
    public class WorkerModel : PageModel
    {
        public List<Worker> listWorker = new List<Worker>();

        public void ReadingSql(SqlDataReader reader)
        {
            while (reader.Read())
            {
                Worker worker = new Worker();

                worker.id = "" + reader.GetInt32(0);
                worker.Name = reader.GetString(1);

                listWorker.Add(worker);
            }
        }

        public void OnGet()
        {
            try
            {
                String connectionString = "Server=LAPTOP-97T368JO;Database=Ticket_Problem;Trusted_Connection=True; TrustServerCertificate=True;";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    String sql = "SELECT * FROM Workers;";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            ReadingSql(reader);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.Message);
            }
        }
    }

    public class Worker
    {
        public String? id;
        public String? Name;
    }
}

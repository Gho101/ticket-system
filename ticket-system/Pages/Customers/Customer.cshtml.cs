using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;


namespace ticket_system.Pages.Customers
{
    public class CustomerModel : PageModel
    {
        public List<Customer> listCustomers = new List<Customer>();

        public void ReadingSql(SqlDataReader reader)
        {
            while (reader.Read())
            {
                Customer customer = new Customer();

                customer.id = "" + reader.GetInt32(0);
                customer.Name = reader.GetString(1);

                listCustomers.Add(customer);
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
                    String sql = "SELECT * FROM Customers;";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using(SqlDataReader reader = command.ExecuteReader())
                        {
                            ReadingSql(reader);
                        }
                    }
                }
            }
            catch(Exception ex) 
            {
                Console.WriteLine("Exception: " + ex.ToString());
            }
        }
    }

    public class Customer
    {
        public String? id;
        public String? Name;
    }
}

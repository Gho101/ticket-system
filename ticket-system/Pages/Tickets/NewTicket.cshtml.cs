using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.Security;

namespace ticket_system.Pages.Tickets
{
    public class NewTicketModel : PageModel
    {
        public TicketInfo ticket = new TicketInfo();
        public String errorMessage = "";
        public String successMessage = "";

        public void OnGet()
        {
        }
        public void OnPost() 
        {
            ticket.customer = Request.Form["Name"];
            ticket.problem = Request.Form["Problem"];


            //If the somthing is not filled in
            if (ticket.customer.Length == 0 || ticket.problem.Length == 0)
            {
                errorMessage = "All fields are required";
                return;
            }
            //save the new Ticket to database

            ticket.customer = ""; ticket.problem = "";
            successMessage = "New Ticket Entered";
        }
    }
}

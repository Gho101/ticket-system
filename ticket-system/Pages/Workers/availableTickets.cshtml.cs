using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ticket_system.Pages.Workers
{
    public class availableTicketsModel : PageModel
    {
        public String? customerName;
        public List<TicketInfo> listTickets = new List<TicketInfo>();
        public void OnGet()
        {
        }

        public class TicketInfo
        {
            public String? id;
            public String? customer;
            public String? problem;
        }
    }

}

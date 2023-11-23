using System.ComponentModel.DataAnnotations.Schema;

namespace ticket_system.Data
{
    public class Status
    {
        public int ID { get; set; }

        [Column(TypeName = "nvarchar(250)")]
        public string TicketStatus { get; set; } = "";
    }
}

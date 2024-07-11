/*
 * This File Is how the database should created and format the data Tabel for Status
 */
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

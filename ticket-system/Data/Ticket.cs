using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ticket_system.Data
{
    public class Ticket
    {
        public int ID { get; set; }
        public int WorkerID { get; set; }
        public int StatusID { get; set; }
        public int CustomerID { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(250)")]
        public string Problem { get; set; } = "";

    }
}

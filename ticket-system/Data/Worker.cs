/*
 * This File Is how the database should created and format the data Tabel for Worker
 */
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ticket_system.Data
{
    public class Worker
    {
        public int ID { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(250)")]
        public string Name { get; set; } = "";
    }
}

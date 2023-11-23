
/*
 * This File Is how the database should created and format the data Tabel for custumers
 */
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ticket_system.Data
{
    public class Customer
    {
        public int ID { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(250)")]
        public string Name { get; set; } = "";


    }
}

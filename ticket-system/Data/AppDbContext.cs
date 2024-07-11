using Microsoft.AspNetCore.Authentication;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;

namespace ticket_system.Data
{
    //This page will create the database (db) if its not created and also update the db if there was any changes 

    public class AppDbContext:DbContext
    {
        public IConfiguration _config { get; set; }

        public AppDbContext(IConfiguration config)
        {
            _config = config;
        }
        //creat an conection to the db sever
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_config.GetConnectionString("DatabaseConnection"));
        }

        //this is the objects that holds the contents of the tables that will be created in the db respectively  
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Worker> Workers { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Status> Statuses { get; set; }
    }
}

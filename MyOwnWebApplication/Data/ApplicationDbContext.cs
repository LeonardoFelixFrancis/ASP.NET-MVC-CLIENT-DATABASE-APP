using Microsoft.EntityFrameworkCore;
using MyOwnWebApplication.Models;

namespace MyOwnWebApplication.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        
        public DbSet<Client> Clients { get; set; }  
    }
}

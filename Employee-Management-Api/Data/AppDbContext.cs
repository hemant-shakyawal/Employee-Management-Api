using Employee_Management_Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Employee_Management_Api.Data
{
    public class AppDbContext:DbContext
    {

        public DbSet<Employee>Employees { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options)
            :base(options)
        {
            
        }
    }
}

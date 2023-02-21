using method2.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace method2.Data
{
    public class APIDbContext :DbContext
    {
        public APIDbContext(DbContextOptions options) :base(options)
        { 
        }   

        public DbSet<Employee> Employees { get; set; }    
    }
}

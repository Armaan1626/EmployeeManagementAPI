using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
namespace EmployeeManagementAPI
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }
        public DbSet<Designation> Designations { get; set; }
    }
}

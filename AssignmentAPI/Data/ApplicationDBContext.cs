using AssignmentAPI.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace AssignmentAPI.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) :base(options)
        {
            
        }

        public DbSet<User> Users { get;set; }

        public DbSet<Permission> Permissions { get;set; }

        public DbSet<Role> Roles { get;set; }
    }
}

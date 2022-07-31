using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using transport.Models;

namespace transport.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<student> students { get; set; }
        public DbSet<teacher>  teachers{ get; set; }
        public DbSet<desire> desires{ get; set; }

    }
}
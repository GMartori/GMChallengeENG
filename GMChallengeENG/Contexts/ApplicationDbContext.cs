using Microsoft.EntityFrameworkCore;
using GMChallengeENG.Entities;

namespace GMChallengeENG.Contexts
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Users> Users { get; set; }
    }
}

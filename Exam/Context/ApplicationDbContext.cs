using Exam.Models;
using Microsoft.EntityFrameworkCore;

namespace FragTracker.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<ProPlayer> ProPlayers { get; set; }
    }
}
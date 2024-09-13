using MCQApplication.Models;
using Microsoft.EntityFrameworkCore;

namespace MCQApplication.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<fyit> fyit { get; set; }
		public DbSet<fyit1> fyit1 { get; set; }
		public DbSet<Syit> Syit { get; set; }
		public DbSet<Syit1> Syit1 { get; set; }
		public DbSet<Feedback> Feedback { get; set; }
    }
}

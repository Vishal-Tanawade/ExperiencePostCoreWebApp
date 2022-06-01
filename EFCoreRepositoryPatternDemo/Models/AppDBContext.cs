using Microsoft.EntityFrameworkCore;

namespace EFCoreRepositoryPatternDemo.Models
{
    public class AppDBContext: DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Seed();
        }

        public DbSet<ClsEmployee> coreEmployees { get; set; }
        public DbSet<ClsSkill> coreSkill { get; set; }
    }
}

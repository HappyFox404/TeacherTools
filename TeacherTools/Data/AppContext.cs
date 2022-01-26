using Microsoft.EntityFrameworkCore;
using TeacherTools.Models;

namespace TeacherTools.Data
{
    public class AppContext : DbContext
    {
        public DbSet<Account> Accounts { get; set; }

        public AppContext() { 
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("server=localhost;" +
                "user=root;" +
                "password=root;" +
                "database=teachertools;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

    }
}

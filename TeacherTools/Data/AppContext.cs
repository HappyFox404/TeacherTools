using Microsoft.EntityFrameworkCore;
using TeacherTools.Models;

namespace TeacherTools.Data
{
    public class AppContext : DbContext
    {
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Group> Courses { get; set; }
        public DbSet<Score> Scores  { get; set; }

        public AppContext() {
            Database.EnsureDeleted();
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
            modelBuilder.Entity<Account>().HasData(new Account[] {
                new Account() {Login = "Admin", Password = "admin"},
                new Account() {Login = "User", Password = "password123"}
            });

            modelBuilder.Entity<Student>().HasKey(st => new { st.FirstName, st.LastName, st.Birthday });
            modelBuilder.Entity<Group>().HasKey(c => new { c.Name, c.DateCreate });
            modelBuilder.Entity<Score>().HasNoKey();
        }

    }
}

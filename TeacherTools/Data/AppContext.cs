﻿using Microsoft.EntityFrameworkCore;
using TeacherTools.Function;
using TeacherTools.Models;

namespace TeacherTools.Data
{
    public class AppContext : DbContext
    {
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Student> Students { get; set; }
        //public DbSet<Group> Courses { get; set; }
        public DbSet<Score> Scores  { get; set; }

        public AppContext() {
            //Database.EnsureDeleted();
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
            var acc1 = new Account() { Login = "Admin", Password = Utils.GetMD5("admin") };
            var acc2 = new Account() { Login = "User", Password = Utils.GetMD5("password123") };
            modelBuilder.Entity<Account>().HasData(new Account[] {
                acc1,
                acc2
            });

            modelBuilder.Entity<Student>().HasOne(st => st.Account).WithMany(acc => acc.Students).HasForeignKey(st => st.AccountId).HasPrincipalKey(acc => acc.Login);
            modelBuilder.Entity<Student>().HasIndex(st => new { st.FirstName, st.LastName, st.Birthday, st.AccountId }).IsUnique();

            modelBuilder.Entity<Score>().HasNoKey();
        }

    }
}

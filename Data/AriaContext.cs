using dotNetStudy.Models;
using dotNetStudy.TestClass;
using Microsoft.EntityFrameworkCore;

namespace dotNetStudy.Data
{
    public class AriaContext : DbContext
    {
        public AriaContext(DbContextOptions<AriaContext> options) : base(options) { }

        public DbSet<TestUser> TestUsers { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Avatar> Avatars { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Entity configurations
            modelBuilder.Entity<TestUser>().ToTable("테스트 테이블");
            modelBuilder.Entity<User>().ToTable("유저");
            modelBuilder.Entity<Avatar>().ToTable("캐릭터");

            // Add any other configuration you need for your entities
        }
    }
}
using dotNetStudy.TestClass;
using dotNetStudy.Models;
using Microsoft.EntityFrameworkCore;

namespace dotNetStudy.Data
{
    public class AriaContext : DbContext
    {
        public AriaContext(DbContextOptions<AriaContext> options) : base(options) { }

        public DbSet<TestUser> TestUsers { get; set; }
        public DbSet<User> Users { get; set; }
    }
}

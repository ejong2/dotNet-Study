using dotNetStudy.TestClass;
using Microsoft.EntityFrameworkCore;

namespace dotNetStudy.Data
{
    public class AriaContext : DbContext
    {
        public AriaContext(DbContextOptions<AriaContext> options) : base(options) { }

        public DbSet<TestUser> Users { get; set; }
    }
}

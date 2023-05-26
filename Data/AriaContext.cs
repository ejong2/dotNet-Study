using dotNetStudy.Models;
using Microsoft.EntityFrameworkCore;

namespace dotNetStudy.Data
{
    public class AriaContext : DbContext
    {
        public AriaContext(DbContextOptions<AriaContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
    }
}

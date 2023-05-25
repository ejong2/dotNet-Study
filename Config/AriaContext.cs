using Microsoft.EntityFrameworkCore;

namespace dotNetStudy.Config
{
    public class AriaContext : DbContext
    {
        public AriaContext(DbContextOptions<AriaContext> options) : base(options) { }

    }
}

using Microsoft.EntityFrameworkCore;

namespace gamerTag.Models
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options)
            : base(options)
        {
        }

        public DbSet<gamerTag.Models.MyDb> MyDb { get; set; }
    }
}


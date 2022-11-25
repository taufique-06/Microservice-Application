using Microsoft.EntityFrameworkCore;
using PlatformService.Models;

namespace PlatformService.Data
{
    public class PlatfromDbContext:DbContext
    {
        public PlatfromDbContext(DbContextOptions<PlatfromDbContext> db) : base(db)
        {

        }

       public DbSet<Platform> Platforms { get; set; }
    }
}

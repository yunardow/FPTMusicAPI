using Microsoft.EntityFrameworkCore;

namespace FPTMusicAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Artist> Artists { get; set; }
    }
}

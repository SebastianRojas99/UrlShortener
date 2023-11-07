using Microsoft.EntityFrameworkCore;
using URLshorter.Entities;

namespace URLshorter
{
    public class URLshorterContext : DbContext
    {
        public URLshorterContext(DbContextOptions<URLshorterContext> options) : base(options)
        {
        }

        public DbSet<XYZ> XYZs { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<User> Users { get; set; }
    }
}

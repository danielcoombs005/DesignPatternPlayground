using DesignPatternsPlayground.Models;
using Microsoft.EntityFrameworkCore;

namespace DesignPatternsPlayground.Repositories
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {

        }

        public DbSet<User> User { get; set; }
    }
}

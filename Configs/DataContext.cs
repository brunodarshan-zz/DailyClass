using Microsoft.EntityFrameworkCore;
using DailyClass.Domains.UserAggregate;

namespace DailyClass.Configs {
    public class DataContext : DbContext {
        public DataContext(DbContextOptions<DataContext> options) : base(options) {}

        public DbSet<User> Users { get; set; }
    }
}
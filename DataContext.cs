using Microsoft.EntityFrameworkCore;
using DailyClass.UserAggregate;

namespace DailyClass {
    class DataContext : DbContext {
        public DataContext(DbContextOptions<DataContext> options) : base(options) {}

        public DbSet<User> Users { get; set; }
    }
}
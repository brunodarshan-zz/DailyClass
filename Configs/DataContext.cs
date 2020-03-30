using Microsoft.EntityFrameworkCore;
using DailyClass.Domains.UserAggregate;
using DailyClass.Domains.CourseAggregate;
using DailyClass.Domains.ModuleAggregate;

namespace DailyClass.Configs {
    public class DataContext : DbContext {
        public DataContext(DbContextOptions<DataContext> options) : base(options) {}

        public DbSet<User> Users { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Module> Modules { get; set; }

    }
}
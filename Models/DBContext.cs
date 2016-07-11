using Microsoft.EntityFrameworkCore;

namespace aspnetcoreapp.Models
{
    // >dotnet ef migrations add testMigration
    // >dotnet ef database update
    public class DBContext: DbContext
    {
        public DBContext(DbContextOptions<DBContext> options)
            : base(options)
        { }
        public DbSet<Customer> Customers { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Customer>().HasKey(m => m.Id);
        }
    }
}
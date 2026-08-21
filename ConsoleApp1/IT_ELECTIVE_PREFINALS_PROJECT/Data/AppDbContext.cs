using IT_ELECTIVE_PREFINALS_PROJECT.Models;
using Microsoft.EntityFrameworkCore;

namespace IT_ELECTIVE_PREFINALS_PROJECT.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Priority> Priorities { get; set; }
        public DbSet<Status> Statuses { get; set; }

        public DbSet<AuditLog> AuditLogs { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<TicketHistory> TicketHistories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Customer>().ToTable("Customers");
            modelBuilder.Entity<Ticket>().ToTable("Tickets");
            modelBuilder.Entity<Category>().ToTable("Categories");
            modelBuilder.Entity<Priority>().ToTable("Priorities");
            modelBuilder.Entity<Status>().ToTable("Statuses");
            modelBuilder.Entity<Department>().ToTable("Departments");
            modelBuilder.Entity<Employee>().ToTable("Employees");
            modelBuilder.Entity<Item>().ToTable("Items");
            modelBuilder.Entity<TicketHistory>().ToTable("TicketHistories");
        }
    }
}
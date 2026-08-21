using Microsoft.EntityFrameworkCore;
using IT_ELECTIVE_PREFINALS_PROJECT.Models;

namespace IT_ELECTIVE_PREFINALS_PROJECT.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Item> Items { get; set; } // <-- Added this line

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Employee>()
                .HasOne(e => e.Department)
                .WithMany(d => d.Employees)
                .HasForeignKey(e => e.DepartmentId);

            modelBuilder.Entity<Ticket>()
                .HasOne(t => t.Customer)
                .WithMany(c => c.Tickets)
                .HasForeignKey(t => t.CustomerId);

            modelBuilder.Entity<Ticket>()
                .HasOne(t => t.AssignedEmployee)
                .WithMany(e => e.AssignedTickets)
                .HasForeignKey(t => t.AssignedEmployeeId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
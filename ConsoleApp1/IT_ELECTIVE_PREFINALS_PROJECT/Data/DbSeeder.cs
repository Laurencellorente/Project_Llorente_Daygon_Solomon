nameusing IT_ELECTIVE_PREFINALS_PROJECT.Models;

namespace IT_ELECTIVE_PREFINALS_PROJECT.Data
{
    public static class DbSeeder
    {
        public static void Seed(AppDbContext context)
        {
            context.Database.EnsureCreated();

            if (!context.Departments.Any())
            {
                context.Departments.AddRange(
                    new Department { Name = "IT Support", Description = "Technical Support" },
                    new Department { Name = "Customer Service", Description = "Customer Assistance" }
                );
                context.SaveChanges();
            }

            if (!context.Employees.Any())
            {
                var itDept = context.Departments.First(d => d.Name == "IT Support");
                context.Employees.Add(
                    new Employee { FirstName = "Laurence", LastName = "Llorente", Email = "laurence@lycevm.edu", DepartmentId = itDept.Id }
                );
                context.SaveChanges();
            }
        }
    }
}
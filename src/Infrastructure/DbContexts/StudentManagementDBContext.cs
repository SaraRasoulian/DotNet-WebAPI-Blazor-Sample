using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Domain.Entities;

namespace Infrastructure.DbContexts
{
    public class StudentManagementDBContext : DbContext
    {
        public StudentManagementDBContext(DbContextOptions<StudentManagementDBContext> options) : base(options) { }

        public DbSet<Student> Students => Set<Student>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
using AspNetCore.GraphQL.Api.Dal.Configurations;
using AspNetCore.GraphQL.Api.Dal.Entity;
using Microsoft.EntityFrameworkCore;

namespace AspNetCore.GraphQL.Api.Dal.Context
{
    public class GraphQlContext : DbContext
    {
        public GraphQlContext(DbContextOptions<GraphQlContext> options)
            : base(options)
        { }

        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new DepartmentConfiguration());
            modelBuilder.ApplyConfiguration(new EmployeeConfiguration());
        }
    }
}
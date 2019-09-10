using AspNetCore.GraphQL.Api.Dal.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace AspNetCore.GraphQL.Api.Dal.Configurations
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.ToTable("Employee", "dbo");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.FirstName)
                .HasMaxLength(50)
                .IsRequired();
            builder.Property(x => x.LastName)
                .HasMaxLength(50)
                .IsRequired();
            builder.Property(x => x.JobTitle)
                .HasMaxLength(50)
                .IsRequired();
            builder.Property(x => x.HireDate)
                .IsRequired();

            builder.HasOne(x => x.Department)
                .WithMany(x => x.Employees)
                .HasForeignKey(x => x.DepartmentId);

            builder.HasData(
                new Employee
                {
                    Id = 1,
                    FirstName = "Jan",
                    LastName = "Sauer",
                    HireDate = DateTime.Now,
                    DepartmentId = 1,
                    JobTitle = "Prof."
                },
                new Employee
                {
                    Id = 2,
                    FirstName = "Jack",
                    LastName = "Ford",
                    HireDate = DateTime.Now,
                    DepartmentId = 2,
                    JobTitle = "Prof."
                },
                new Employee
                {
                    Id = 3,
                    FirstName = "Henry",
                    LastName = "Duncan",
                    HireDate = DateTime.Now,
                    DepartmentId = 1,
                    JobTitle = "Ass."
                }
            );
        }
    }
}
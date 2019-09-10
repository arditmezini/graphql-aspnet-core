using AspNetCore.GraphQL.Api.Dal.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AspNetCore.GraphQL.Api.Dal.Configurations
{
    public class DepartmentConfiguration : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.ToTable("Department", "dbo");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Number)
                .IsRequired();

            builder.Property(x => x.Location)
                .HasMaxLength(100)
                .IsRequired();

            builder.HasData(
                new Department
                {
                    Id = 1,
                    Number = 101,
                    Location = "Building 1, First Floor, Door 10"
                },
                new Department
                {
                    Id = 2,
                    Number = 102,
                    Location = "Building 1, First Floor, Door 11"
                },
                new Department
                {
                    Id = 3,
                    Number = 103,
                    Location = "Building 1, First Floor, Door 12"
                }
            );
        }
    }
}
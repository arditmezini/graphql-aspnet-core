using AspNetCore.GraphQL.Api.Dal.Entity;
using AspNetCore.GraphQL.Api.Dal.Repository;
using GraphQL.Types;

namespace AspNetCore.GraphQL.Api.GraphQL.Types
{
    public class EmployeeType : ObjectGraphType<Employee>
    {
        public EmployeeType(IDepartmentRepository departmentRepository)
        {
            Field(x => x.Id);
            Field(x => x.FirstName);
            Field(x => x.LastName);
            Field(x => x.JobTitle);
            Field(x => x.HireDate);
            Field(x => x.DepartmentId);

            FieldAsync<DepartmentType>("department", resolve: async context =>
            {
                return await departmentRepository.GetById(context.Source.DepartmentId);
            });
        }
    }
}
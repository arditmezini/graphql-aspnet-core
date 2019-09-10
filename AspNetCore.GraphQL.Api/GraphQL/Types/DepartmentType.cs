using AspNetCore.GraphQL.Api.Dal.Entity;
using AspNetCore.GraphQL.Api.Dal.Repository;
using GraphQL.Types;

namespace AspNetCore.GraphQL.Api.GraphQL.Types
{
    public class DepartmentType : ObjectGraphType<Department>
    {
        public DepartmentType(IEmployeeRepository employeeRepository)
        {
            Field(x => x.Id);
            Field(x => x.Number);
            Field(x => x.Location);

            FieldAsync<ListGraphType<EmployeeType>>("employees", resolve: async context =>
            {
                return await employeeRepository.GetByDepartmentId(context.Source.Id);
            });
        }
    }
}
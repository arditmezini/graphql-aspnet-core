using AspNetCore.GraphQL.Api.Dal.Repository;
using AspNetCore.GraphQL.Api.GraphQL.Types;
using GraphQL.Types;

namespace AspNetCore.GraphQL.Api.GraphQL.Query
{
    public class ApiQuery : ObjectGraphType
    {
        public ApiQuery(IDepartmentRepository departmentRepository, IEmployeeRepository employeeRepository)
        {
            DepartmentQuery(departmentRepository);
            EmployeeQuery(employeeRepository);
        }

        private void DepartmentQuery(IDepartmentRepository departmentRepository)
        {
            Field<ListGraphType<DepartmentType>>(name: "departments",
                resolve: context =>
                {
                    return departmentRepository.GetDepartments().Result;
                }
            );

            Field<DepartmentType>(name: "department",
                arguments: new QueryArguments(new QueryArgument<IntGraphType> { Name = "id" }),
                resolve: context =>
                {
                    var id = context.GetArgument<int>("id");
                    return departmentRepository.GetById(id).Result;
                }
            );
        }

        private void EmployeeQuery(IEmployeeRepository employeeRepository)
        {
            Field<ListGraphType<EmployeeType>>(name: "employees",
                resolve: context =>
                {
                    return employeeRepository.GetEmployees().Result;
                }
            );

            Field<EmployeeType>(name: "employee",
                arguments: new QueryArguments(new QueryArgument<IntGraphType> { Name = "id" }),
                resolve: context =>
                {
                    var id = context.GetArgument<int>("id");
                    return employeeRepository.GetById(id).Result;
                }
            );
        }
    }
}
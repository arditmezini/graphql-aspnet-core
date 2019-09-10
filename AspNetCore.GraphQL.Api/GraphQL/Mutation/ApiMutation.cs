using AspNetCore.GraphQL.Api.Dal.Entity;
using AspNetCore.GraphQL.Api.Dal.Repository;
using AspNetCore.GraphQL.Api.GraphQL.Types;
using GraphQL.Types;

namespace AspNetCore.GraphQL.Api.GraphQL.Mutation
{
    public class ApiMutation : ObjectGraphType
    {
        public ApiMutation(IDepartmentRepository departmentRepository, IEmployeeRepository employeeRepository)
        {
            DepartmentMutation(departmentRepository);
            EmployeeMutation(employeeRepository);
        }

        private void EmployeeMutation(IEmployeeRepository employeeRepository)
        {
            FieldAsync<EmployeeType>("createEmployee",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<EmployeeInputType>> { Name = "employee" }),
                resolve: async context =>
                {
                    var employee = context.GetArgument<Employee>("employee");
                    return await employeeRepository.Add(employee);
                }
            );

            FieldAsync<EmployeeType>("updateEmployee",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<EmployeeInputType>> { Name = "employee" },
                    new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "id" }
                ),
                resolve: async context =>
                {
                    var employee = context.GetArgument<Employee>("employee");
                    var id = context.GetArgument<int>("id");

                    return await employeeRepository.Update(id, employee);
                }
            );

            FieldAsync<EmployeeType>(name: "deleteEmployee",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "id" }),
                resolve: async context =>
                {
                    var id = context.GetArgument<int>("id");
                    await employeeRepository.Delete(id);
                    return $"Employee with {id} has been successfully deleted.";
                }
            );
        }

        private void DepartmentMutation(IDepartmentRepository departmentRepository)
        {
            FieldAsync<DepartmentType>("createDepartment",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<DepartmentInputType>> { Name = "department" }),
                resolve: async context =>
                {
                    var departament = context.GetArgument<Department>("department");
                    return await departmentRepository.Add(departament);
                }
            );

            FieldAsync<DepartmentType>("updateDepartment",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<DepartmentInputType>> { Name = "department" },
                    new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "id" }
                ),
                resolve: async context =>
                {
                    var department = context.GetArgument<Department>("department");
                    var id = context.GetArgument<int>("id");

                    return await departmentRepository.Update(id, department);
                }
            );

            FieldAsync<StringGraphType>("deleteDepartment",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "id" }),
                resolve: async context =>
                {
                    var id = context.GetArgument<int>("id");
                    await departmentRepository.Delete(id);
                    return $"Department with {id} has been successfully deleted.";
                }
            );
        }
    }
}
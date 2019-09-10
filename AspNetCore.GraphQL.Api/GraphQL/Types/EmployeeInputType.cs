using GraphQL.Types;

namespace AspNetCore.GraphQL.Api.GraphQL.Types
{
    public class EmployeeInputType : InputObjectGraphType
    {
        public EmployeeInputType()
        {
            Name = "employeeInput";

            Field<NonNullGraphType<StringGraphType>>("firstName");
            Field<NonNullGraphType<StringGraphType>>("lastName");
            Field<NonNullGraphType<StringGraphType>>("jobTitle");
            Field<NonNullGraphType<DateTimeGraphType>>("hireDate");
            Field<NonNullGraphType<IntGraphType>>("departmentId");
        }
    }
}
using GraphQL.Types;

namespace AspNetCore.GraphQL.Api.GraphQL.Types
{
    public class DepartmentInputType : InputObjectGraphType
    {
        public DepartmentInputType()
        {
            Name = "departmentInput";

            Field<NonNullGraphType<IntGraphType>>("number");
            Field<NonNullGraphType<StringGraphType>>("location");
        }
    }
}

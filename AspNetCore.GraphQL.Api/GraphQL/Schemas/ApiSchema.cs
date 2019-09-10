using AspNetCore.GraphQL.Api.GraphQL.Mutation;
using AspNetCore.GraphQL.Api.GraphQL.Query;
using GraphQL;
using GraphQL.Types;

namespace AspNetCore.GraphQL.Api.GraphQL.Schemas
{
    public class ApiSchema : Schema
    {
        public ApiSchema(IDependencyResolver resolver)
            : base(resolver)
        {
            Query = resolver.Resolve<ApiQuery>();
            Mutation = resolver.Resolve<ApiMutation>();
        }
    }
}
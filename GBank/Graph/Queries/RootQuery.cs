using GraphQL.Types;

namespace GBank.Graph
{
    public class RootQuery : ObjectGraphType
    {

        public RootQuery()
        {
            Name = "RootQuery";
            Field<CustomerQuery>("customers", resolve: context => new { });
            Field<AccountQuery>("accounts", resolve: context => new { });
        }
    }
}
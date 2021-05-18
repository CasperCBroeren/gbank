using GraphQL.Types;

namespace GBank.Graph.Queries
{
    public class BankQuery : ObjectGraphType
    { 
        public BankQuery()
        { 
            Field<CustomerQuery>("customers", resolve: context => new { });
            Field<AccountQuery>("accounts", resolve: context => new { });
        }
    }
}
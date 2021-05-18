using GBank.Models;
using GraphQL.Types;

namespace GBank.Graph.Types
{
    public class TransactionType : ObjectGraphType<Transaction>
    {
        public TransactionType()
        {
            Field(x => x.Id, type: typeof(IdGraphType));
            Field(x => x.Amount);
            Field(x => x.Created);
            Field(x => x.Settled, nullable: true);
            Field(x => x.Source, nullable: true, type: typeof(AccountType));
            Field(x => x.Target, nullable: true, type: typeof(AccountType));
        }
    }
}

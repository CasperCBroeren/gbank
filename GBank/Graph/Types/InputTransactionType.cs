using GBank.Models;
using GraphQL.Types;

namespace GBank.Graph.Types
{
    public class TransactionMutation
    {
        public int Amount { get; set; }

        public string Source { get; set; }

        public string Target { get; set; }
    }
    public class InputTransactionType : InputObjectGraphType<TransactionMutation>
    {
        public InputTransactionType()
        { 
            Field(x => x.Amount);
            Field(x => x.Source);
            Field(x => x.Target);
        }
    }
}

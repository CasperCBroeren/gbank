using GBank.Models;
using GraphQL.Types;

namespace GBank.Graph
{
    public class AccountType : ObjectGraphType<Account>
    {
        public AccountType()
        {
            Field(x => x.Id, type: typeof(IdGraphType));
            Field(x => x.Currency);
            Field(x => x.Iban);
            Field(x => x.Usage, type: typeof(AccountUsageType));
        }
    }
}

using GBank.Graph.Queries;
using GBank.Models;
using GBank.Repositories;
using GraphQL.Types;

namespace GBank.Graph.Types
{
    public class AccountType : ObjectGraphType<Account>
    {
        public AccountType(ITransactionRepo transactionRepo)
        {
            Field(x => x.Id, type: typeof(IdGraphType));
            Field(x => x.Currency);
            Field(x => x.Iban);
            Field(x => x.Usage, type: typeof(AccountUsageType));
            Field<PaginationListType<TransactionType, Transaction>>(
               name: "transactions",
               arguments: PaginationListQuery.DefaultQueryArguments,
               resolve: context =>
               {
                   var total = transactionRepo.AllTransactions(context.Source.Id);
                   return PaginationList<Transaction>.FromTotal(total, context, x => x.Created);
               }
           );
        }
    }
}

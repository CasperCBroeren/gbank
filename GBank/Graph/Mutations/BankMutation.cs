using GBank.Graph.Types;
using GBank.Models;
using GBank.Repositories;
using GraphQL;
using GraphQL.Types;
using System;

namespace GBank.Graph.BankMutations
{
    public class BankMutation : ObjectGraphType
    {

        public BankMutation(ITransactionRepo transactionRepo)
        {
            Field<TransactionType>("addTransaction",
                arguments: new QueryArguments(
                    new QueryArgument<StringGraphType> { Name = "accountId", Description = "The transaction" },
                 new QueryArgument<InputTransactionType> { Name = "transaction", Description = "The transaction" }), 
                resolve: context =>
                {
                    var accountId = context.GetArgument<Guid>("accountId");
                    var inputTransaction = context.GetArgument<TransactionMutation>("transaction");
                    var transaction = new Transaction()
                    {
                        Id = Guid.NewGuid(),
                        Amount = inputTransaction.Amount
                    };
                    transaction.Created = DateTime.Now;
                    transactionRepo.AddTransactionForAccount(accountId, transaction);
                    return transaction;
                });
        }
    }
}

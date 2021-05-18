using GBank.Models;
using GBank.Repositories;
using GraphQL.Types;
using System;

namespace GBank.Graph
{
    public class AccountQuery : ObjectGraphType
    {
        public AccountQuery(IAccountRepo accountRepo)
        {
            Field<ListGraphType<AccountType>>("accounts", "Returns all accounts of a Customer by Id",
                new QueryArguments(
                    new QueryArgument<IntGraphType>() { Name = "id", Description = "Customer Id", ResolvedType = new GuidGraphType() }
                    ),
                  resolve: context =>
                  {
                      if (context.Arguments.TryGetValue("id", out var guid)
                        && guid.Value != null)
                      {
                          return accountRepo.GetAccounts((Guid)guid.Value);
                      }

                      return Array.Empty<Account>();
                  });

        }
    }
}
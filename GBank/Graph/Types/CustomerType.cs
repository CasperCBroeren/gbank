using GBank.Graph.Queries;
using GBank.Models;
using GBank.Repositories;
using GraphQL;
using GraphQL.Types;

namespace GBank.Graph.Types
{
    public class CustomerType : ObjectGraphType<Customer>
    {
        public CustomerType(IAccountRepo accountRepo)
        {
            Field(x => x.Id, type: typeof(IdGraphType));
            Field(x => x.FirstName);
            Field(x => x.LastName);
            Field(x => x.BirthDay).AuthorizeWith("AdminPolicy"); 
             
            Field<PaginationListType<AccountType, Account>>(
                name: "accounts",
                arguments: PaginationListQuery.DefaultQueryArguments,
                resolve: context =>
                { 
                    var total = accountRepo.GetAccounts(context.Source.Id);
                    return PaginationList<Account>.FromTotal(total, context, x=> x.Iban);                    
                }
            );
        }
    }
}

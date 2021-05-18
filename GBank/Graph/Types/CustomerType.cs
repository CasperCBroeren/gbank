using GBank.Graph.Types;
using GBank.Models;
using GBank.Repositories;
using GraphQL;
using GraphQL.Types;

namespace GBank.Graph
{
    public class CustomerType : ObjectGraphType<Customer>
    {
        public CustomerType()
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
                    var total = FakeAccountRepo.GetAccounts(context.Source.Id);
                    return PaginationList<Account>.FromTotal(total, context, x=> x.Iban);                    
                }
            );
        }
    }
}

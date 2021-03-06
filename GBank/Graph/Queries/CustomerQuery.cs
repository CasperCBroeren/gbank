using GBank.Graph.Types;
using GBank.Repositories;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GBank.Graph.Queries
{
    public class CustomerQuery : ObjectGraphType
    {

        public CustomerQuery(ICustomerRepo customerRepo)
        {  
            Field<ListGraphType<CustomerType>>("customers", "Returns a list of Customer", resolve: context => customerRepo.GetCustomers());
            Field<CustomerType>("customer", "Returns a Single Customer by Id",
                new QueryArguments(
                    new List<QueryArgument>() {
                    new QueryArgument<IntGraphType>() { Name = "id", Description = "Customer Id", ResolvedType = new GuidGraphType() },
                    new QueryArgument<StringGraphType>() { Name = "name", Description = "Customer Id", ResolvedType = new StringGraphType() }
                    }),
                  resolve: context =>
                  {
                      if (context.Arguments.TryGetValue("id", out var guid)
                        && guid.Value != null)
                      {
                          return customerRepo.GetCustomers().FirstOrDefault(x => x.Id == (Guid)guid.Value);
                      }
                      if (context.Arguments.TryGetValue("name", out var name)
                      && name.Value != null)
                      {
                          return customerRepo.GetCustomers().FirstOrDefault(
                              x => x.FirstName.Contains(name.Value as string, StringComparison.InvariantCultureIgnoreCase) ||
                                    x.LastName.Contains(name.Value as string, StringComparison.InvariantCultureIgnoreCase));
                      }
                      return null;
                  });

        }
    }
}
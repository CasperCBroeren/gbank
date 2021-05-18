using GBank.Graph.Queries;
using GraphQL.Types;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace GBank.Graph
{
    public class GBankSchema : Schema
    {
        public GBankSchema(IServiceProvider provider) : base(provider)
        {
            Query = provider.GetRequiredService<BankQuery>();
        }
    }
}

using GraphQL.Types;
using System;

namespace GBank.Graph
{
    public class GBankSchema : Schema
    {
        public GBankSchema(IServiceProvider provider) : base(provider)
        {
            Query = new RootQuery(); 
        }
    }
}

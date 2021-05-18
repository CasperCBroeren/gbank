using GraphQL;
using GraphQL.Types;
using System.Collections.Generic;

namespace GBank.Graph
{
    internal class PaginationListQuery
    {
        public int Size { get; set; }
        public int Page { get; set; }
        public IEnumerable<string> Order { get; internal set; }

        public static QueryArguments DefaultQueryArguments = new QueryArguments(
            new QueryArgument<IntGraphType> { Name = "size", Description = "Size of your result starting from 1" },
            new QueryArgument<IntGraphType> { Name = "page", Description = "Page index starting from 0" },
            new QueryArgument<ListGraphType<StringGraphType>> { Name = "order", Description = "asc or desc" }
        );


        internal static PaginationListQuery FromContext(IResolveFieldContext context)
        {
            return new PaginationListQuery
            {
                Size = context.GetArgument("size", 20),
                Page = context.GetArgument("page", 20),
                Order = context.GetArgument<IEnumerable<string>>("order")
            };
        }
    }

}
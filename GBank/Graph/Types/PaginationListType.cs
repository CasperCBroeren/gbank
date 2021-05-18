using GBank.Models;
using GraphQL.Types;

namespace GBank.Graph.Types
{
    public class PaginationListType<GraphType, Model> : ObjectGraphType<PaginationList<Model>> where GraphType : IGraphType
    {
        public PaginationListType()
        {
            Name = $"PaginationList{typeof(Model).Name}";

            Field(x => x.TotalCount).Description("Total count of items"); 
            Field<ListGraphType<GraphType>>(
                name: "Data",
                description: "Data",
                resolve: context => context.Source.Data
            );
        }
    }
}

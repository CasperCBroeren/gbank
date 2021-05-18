using GBank.Graph;
using GraphQL;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GBank.Models
{
    public class PaginationList<T>
    {
        public int TotalCount { get; set; }

        public IEnumerable<T> Data { get; set; } = new List<T>();

        internal static PaginationList<T> FromTotal<Cursor>(List<T> total, IResolveFieldContext<Customer> context, Func<T,Cursor> sorter)
        {
            var query = PaginationListQuery.FromContext(context);
            return new PaginationList<T>
            {
                TotalCount = total.Count,
                Data = (query.Order.Contains("desc")
                                    ? total.OrderByDescending(sorter)
                                : total.OrderBy(sorter))
                                .Skip(query.Page * query.Size).Take(query.Size)
            };
        } 
    }

}

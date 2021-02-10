using System.Collections.Generic;

namespace ContosoUniversity.SharedKernel.Domain
{
    public interface IPagedList<T> : IList<T>
    {
        int TotalItemCount { get;}
        int PageNumber { get;}
        int PageSize { get;}
        bool HasPreviousPage { get;}
        bool HasNextPage { get;}
        int? NextPageNumber { get; }
        int? PreviousPageNumber { get; }

    }
}

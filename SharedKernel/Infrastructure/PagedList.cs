using ContosoUniversity.SharedKernel.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContosoUniversity.SharedKernel.Infrastructure
{
    public class PagedList<T> : List<T>, IPagedList<T>
    {
        public int TotalItemCount { get;}
        public int PageNumber { get;}
        public int PageSize { get;}
        public bool HasPreviousPage { get;}
        public bool HasNextPage { get;}
        public int? NextPageNumber { get; }
        public int? PreviousPageNumber { get; }

        public PagedList(IEnumerable<T> source, int pageNumber, int pageSize)
        {
            TotalItemCount = source.Count();
            PageSize = pageSize;
            PageNumber = pageNumber;
            HasNextPage = (pageNumber * pageSize) < TotalItemCount;
            HasPreviousPage = PageNumber > 1;
            NextPageNumber = HasNextPage ? PageNumber + 1 : (int?)null;
            PreviousPageNumber = HasPreviousPage ? PageNumber - 1 : (int?)null;
        }             
        public static async Task<IPagedList<T>> CreateAsync(IQueryable<T> source, int pageNumber, int pageSize)
        {        
            var pagedList = new PagedList<T>(source,pageNumber, pageSize);
            pagedList.AddRange(await source.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync());
            return pagedList;
        }
      
    }
    public static class Pagination
    {
        public static IPagedList<T> ToPagedList<T>(this IQueryable<T> source, int pageNumber, int pageSize)
        {
            var pagedList = new PagedList<T>(source, pageNumber, pageSize);
            pagedList.AddRange(source.Skip((pageNumber -1) * pageSize).Take(pageSize).ToList());
            return pagedList;
        }       
        public static async Task<IPagedList<T>> ToPagedListAsync<T>(this IQueryable<T> source, int pageNumber, int pageSize)
        {
            return await PagedList<T>.CreateAsync(source, pageNumber, pageSize);
        }

    }
}

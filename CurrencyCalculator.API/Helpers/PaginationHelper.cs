using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CurrencyCalculator.API.Models;
using CurrencyCalculator.API.Services;

namespace CurrencyCalculator.API.Helpers
{
    public class PaginationHelper
    {
        public static PagedResponse<IEnumerable<T>> CreatePagedReponse<T>(IEnumerable<T> pagedData, PaginationFilter validFilter, int totalRecords, IUriService uriService, string route)
        {
            var response = new PagedResponse<IEnumerable<T>>(pagedData, validFilter.PageNumber, validFilter.PageSize);
            var totalPages = ((double)totalRecords / (double)validFilter.PageSize);
            int roundedTotalPages = Convert.ToInt32(Math.Ceiling(totalPages));

            response.NextPage =
                validFilter.PageNumber >= 1 && validFilter.PageNumber < roundedTotalPages
                ? uriService.GetPageUri(new PaginationFilter(validFilter.PageNumber + 1, validFilter.PageSize), route)
                : null;
            response.PreviousPage =
                validFilter.PageNumber - 1 >= 1 && validFilter.PageNumber <= roundedTotalPages
                ? uriService.GetPageUri(new PaginationFilter(validFilter.PageNumber - 1, validFilter.PageSize), route)
                : null;
            response.FirstPage = uriService.GetPageUri(new PaginationFilter(1, validFilter.PageSize), route);
            response.LastPage = uriService.GetPageUri(new PaginationFilter(roundedTotalPages, validFilter.PageSize), route);
            response.TotalPages = roundedTotalPages;
            response.TotalRecords = totalRecords;

            return response;
        }
    }
}

using LaugamaCorp.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LaugamaCorp.Server.Helpers
{
    public static class QueryableExtensions
    {
        public static IQueryable<T> Paginar<T>(this IQueryable<T> queryable,
            PaginationModel pagination)
        {
            return queryable
                .Skip((pagination.Pagina - 1) * pagination.CantidadAMostrar)
                .Take(pagination.CantidadAMostrar);
        }

    }
}

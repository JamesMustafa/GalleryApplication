using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using AutoMapper.QueryableExtensions;
using AutoMapper;

namespace GalleryApplication.Services.Mapping
{
    public static class QueryableMappingExtensions
    {
        public static IQueryable<TDestination> To<TDestination>(
            this IQueryable source,
            params Expression<Func<TDestination, object>>[] membersToExpand)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            return source.ProjectTo(membersToExpand);
        }

        public static IQueryable<TDestination> To<TDestination>(
            this IQueryable source,
            object parameters)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            return source.ProjectTo<TDestination>(parameters);
        }

        public static IEnumerable<TDestination> To<TDestination>(
            this IEnumerable source,
            params Expression<Func<TDestination, object>>[] membersToExpand)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            return source.AsQueryable().ProjectTo(membersToExpand);
        }

        public static IEnumerable<TDestination> To<TDestination>(
            this IEnumerable source,
            object parameters)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            return source.AsQueryable().ProjectTo<TDestination>(parameters);
        }

    }
}

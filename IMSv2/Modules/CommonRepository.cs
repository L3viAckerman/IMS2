using IMSv2.IMSCommon;
using IMSv2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace IMSv2.Modules
{
    public abstract class CommonRepository<T> where T : Base
    {
        protected readonly IMSV2Context context;
        public CommonRepository(IMSV2Context context)
        {
            this.context = context;
        }

        protected IQueryable<T> SkipAndTake(IQueryable<T> source, FilterEntity FilterEntity)
        {
            string command = FilterEntity.SortType == SortType.ASC ? "OrderBy" : "OrderByDescending";
            var type = typeof(T);
            var property = type.GetProperty(FilterEntity.SortBy);
            var parameter = Expression.Parameter(type, "p");
            var propertyAccess = Expression.MakeMemberAccess(parameter, property);
            var orderByExpression = Expression.Lambda(propertyAccess, parameter);
            var resultExpression = Expression.Call(typeof(Queryable), command, new Type[] { type, property.PropertyType },
                                          source.Expression, Expression.Quote(orderByExpression));
            source = source.Provider.CreateQuery<T>(resultExpression);
            source = source.Skip(FilterEntity.Skip).Take(FilterEntity.Take);
            return source;
        }
    }
}

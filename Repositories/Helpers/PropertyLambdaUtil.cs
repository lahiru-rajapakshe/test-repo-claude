using System.Linq.Expressions;
using System.Reflection;

namespace Common.Infrastructure.Repositories.Helpers
{
    public static class PropertyLambdaUtil
    {
        public static Expression<Func<T, object>> CreatePropertyLambda<T>(PropertyInfo property)
        {
            var parameter = Expression.Parameter(typeof(T), "e");
            var propertyAccess = Expression.Property(parameter, property);
            var convert = Expression.Convert(propertyAccess, typeof(object));
            return Expression.Lambda<Func<T, object>>(convert, parameter);
        }
    }
}

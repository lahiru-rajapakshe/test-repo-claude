using MongoDB.Driver;
using System.Linq.Expressions;

namespace Common.Infrastructure.Repositories.Helpers
{
    public class PatchEntityHelper
    {
        public static UpdateDefinition<T> CreateUpdateDefinition<T>(T entity, params Expression<Func<T, object>>[] excludedProperties)
        {
            var updates = Builders<T>.Update;
            UpdateDefinition<T>? updateDefinition = null;

            var entityType = typeof(T);
            var excludedPropertyNames = excludedProperties
                .Select(expression => ((MemberExpression)(expression.Body is UnaryExpression unary ? unary.Operand : expression.Body)).Member.Name)
                .ToHashSet();

            foreach (var property in entityType.GetProperties())
            {
                var value = property.GetValue(entity);
                if (value != null && !excludedPropertyNames.Contains(property.Name))
                {
                    var lambda = PropertyLambdaUtil.CreatePropertyLambda<T>(property);
                    updateDefinition = updateDefinition == null
                        ? updates.Set(lambda, value)
                        : updateDefinition.Set(lambda, value);
                }
            }

            return updateDefinition ?? updates.Combine();
        }
    }
}

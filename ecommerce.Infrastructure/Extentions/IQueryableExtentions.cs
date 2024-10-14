using System.Linq.Expressions;

namespace Ecommerce.Infrastructure.Extentions
{
    public static class IQueryableExtentions
    {
        public enum OrderType
        {
            ASC, DESC
        }

        public static IQueryable<T> CustomPagination<T>(this IQueryable<T> query, int pageNumber = 1,int PageSize = 10) where T : class
        {
            ArgumentNullException.ThrowIfNull(query);

            query = query.Skip((pageNumber - 1) * PageSize).Take(PageSize); 

            return query; 
        }

        public static IQueryable<T> CustomFiltring<T>(this IQueryable<T> query,Dictionary<string,string> propertyPerValue)
            where T : class
        {
            ArgumentNullException.ThrowIfNull(query);

            if (propertyPerValue == null || propertyPerValue.Count==0)
                return query;


            // Create a parameter for the lambda expression: (T p)
            ParameterExpression parameter = Expression.Parameter(typeof(T), "Object Type");

            // Initialize the base expression with `true` to start combining
            Expression combinedExpression = Expression.Constant(true);

            foreach (var property in propertyPerValue)
            {
                //Ex: (Product p) => p.name == 'laptop' && p.categoery == 'categoery'
                Expression filterExpression =  BuildEqualityFilterExpression<T>(parameter, property.Key, property.Value);

                combinedExpression = Expression.AndAlso(combinedExpression, filterExpression);
            }

            // Build the full lambda expression: (T p) => combinedExpression
            var finalExpression = Expression.Lambda<Func<T, bool>>(combinedExpression, parameter);

            // Apply the final expression in a single Where clause
            return query.Where(finalExpression);
        }

        public static IQueryable<T> CustomOrdring<T>(this IQueryable<T> query, Dictionary<string, string> propertyPerValue)
        {
            if (query == null)
                throw new ArgumentNullException("source");

            if (propertyPerValue == null || propertyPerValue.Count == 0)
                return query;
            IOrderedQueryable<T> orderedQueryable = null;

            foreach (var property in propertyPerValue)
            {
                var propertyName = property.Key;

                // Try parsing the order type (ASC or DESC)
                if (!Enum.TryParse(property.Value, true, out OrderType orderType))
                    throw new Exception($"Invalid order type '{property.Value}' for property '{propertyName}', it should be either 'ASC' or 'DESC'.");

                // Build the expression for the property
                var func = BuildOrderExpression<T>(propertyName);

                // Apply ordering (OrderBy or ThenBy)
                if (orderedQueryable == null)
                {
                    // First ordering
                    orderedQueryable = orderType == OrderType.ASC
                        ? query.OrderBy(func)
                        : query.OrderByDescending(func);
                }
                else
                {
                    // Additional orderings (ThenBy or ThenByDescending)
                    orderedQueryable = orderType == OrderType.ASC
                        ? orderedQueryable.ThenBy(func)
                        : orderedQueryable.ThenByDescending(func);
                }
            }

            return orderedQueryable ?? query; // Ensure the query is returned even if no ordering was applied
        }

        public static Expression<Func<T, object>> BuildOrderExpression<T>(string propertyName)
        {
            ParameterExpression parameter = Expression.Parameter(typeof(T), "obj");
            MemberExpression propertyAccess = Expression.Property(parameter, propertyName);
            UnaryExpression convertProperty = Expression.Convert(propertyAccess, typeof(object));

            return Expression.Lambda<Func<T, object>>(convertProperty, parameter);
        }

        public static Expression BuildEqualityFilterExpression<T>(ParameterExpression parameter, string FilterBy, string FilterValue)
        {

            //Extract PropertyName from the object T 
            MemberExpression propertAccsessFilterBy = Expression.Property(parameter, FilterBy);

            if (propertAccsessFilterBy == null)
                throw new ArgumentException($"Property '{FilterBy}' does not exist on type '{typeof(T)}'.");

            // convert the Filter value to propper value type from PropertyName 
            object Filter_Value = Convert.ChangeType(FilterValue, propertAccsessFilterBy.Type);

            // 'laptop'
            Expression FilterByValue = Expression.Constant(Filter_Value);

            // p.name == 'laptop'
            return Expression.Equal(propertAccsessFilterBy, FilterByValue);
        }
    }
}

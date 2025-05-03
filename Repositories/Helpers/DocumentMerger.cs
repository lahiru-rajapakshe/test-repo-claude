namespace Common.Infrastructure.Repositories.Helpers
{
    public class DocumentMerger
    {
        public static TEntity MergeDocuments<TEntity>(TEntity current, TEntity modified)
        {
            if (current == null)
                throw new ArgumentNullException(nameof(current));

            if (modified == null)
                throw new ArgumentNullException(nameof(modified));

            var entityType = typeof(TEntity);

            foreach (var property in entityType.GetProperties())
            {
                var modifiedValue = property.GetValue(modified);

                if (modifiedValue != null)
                {
                    if (property.PropertyType == typeof(string))
                    {
                        if (!string.IsNullOrWhiteSpace((string)modifiedValue))
                        {
                            property.SetValue(current, modifiedValue);
                        }
                    }
                    else if (typeof(IEnumerable<object>).IsAssignableFrom(property.PropertyType))
                    {
                        if ((modifiedValue as IEnumerable<object>)?.Any() == true)
                        {
                            property.SetValue(current, modifiedValue);
                        }
                    }
                    else
                    {
                        property.SetValue(current, modifiedValue);
                    }
                }
            }

            return current;
        }
    }
}

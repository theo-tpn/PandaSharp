using System.Linq.Expressions;
using System.Reflection;
using System.Text.Json.Serialization;

namespace PandaSharp.Utils
{
    public class PandaQuery
    {
        private readonly Dictionary<string, string> _params;

        public PandaQuery()
        {
            _params = new Dictionary<string, string>();
        }

        public PandaQuery AddFilter<T>(Expression<Func<T, object>> expression, string[] values)
        {
            var attrValue = RetrieveJsonPropertyNameValue<T>(expression);

            if (_params.ContainsKey("filter"))
                throw new InvalidOperationException("Filter already added to query");

            _params.Add("filter", $"filter[{attrValue}]={string.Join(',', values)}");
            return this;
        }

        public PandaQuery AddSearch<T>(Expression<Func<T, object>> expression, string value)
        {
            var attrValue = RetrieveJsonPropertyNameValue<T>(expression);

            if (_params.ContainsKey("search"))
                throw new InvalidOperationException("Search already added to query");

            _params.Add("search", $"search[{attrValue}]={value}");
            return this;
        }

        public PandaQuery AddRange<T>(Expression<Func<T, object>> expression, int min, int max)
        {
            var attrValue = RetrieveJsonPropertyNameValue<T>(expression);

            if (_params.ContainsKey("range"))
                throw new InvalidOperationException("Range already added to query");

            _params.Add("range", $"range[{attrValue}]={min},{max}");
            return this;
        }

        public PandaQuery AddSort<T>(Dictionary<Expression<Func<T, object>>, PandaScoreSortOption> sorters)
        {
            if (_params.ContainsKey("sort"))
                throw new InvalidOperationException("Sort already added to query");

            var querySort = new string[sorters.Count];

            for (var i = 0; i < sorters.Count; i++)
            {
                var currentItem = sorters.ElementAt(i);
                var attrValue = RetrieveJsonPropertyNameValue<T>(currentItem.Key);

                querySort[i] = $"{attrValue}{(currentItem.Value == PandaScoreSortOption.Descending ? ("-") : (""))}";
            }

            _params.Add("sort", $"sort={string.Join(',', querySort)}");
            return this;
        }

        public override string ToString()
        {
            return string.Join('&', _params.Values);
        }

        private string RetrieveJsonPropertyNameValue<T>(Expression<Func<T, object>> expression)
        {
            var memberExpression = expression.Body as MemberExpression;
            if (memberExpression == null)
                throw new InvalidOperationException("Cannot evaluate expression.");

            var prop = memberExpression?.Member as PropertyInfo;
            if (prop == null)
                throw new InvalidOperationException("Cannot evaluate expression.");

            var attrData = prop.GetCustomAttributesData();
            return (string)attrData.Single(x => x.AttributeType == typeof(JsonPropertyNameAttribute)).ConstructorArguments[0].Value!;
        }
    }
}

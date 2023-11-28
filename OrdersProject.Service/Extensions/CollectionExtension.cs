

using OrdersProject.Domain.Configurations;

namespace OrdersProject.Service.Extensions
{
    public static class CollectionExtension
    {
        public static IEnumerable<T> ToPagedList<T>(this IEnumerable<T> source, PaginationParams @params)
        {
            if (@params == null)
                return source;

            return @params.PageIndex > 0 && @params.PageSize >= 0
                ? source.Skip((@params.PageIndex - 1) * @params.PageSize).Take(@params.PageSize)
                : source;
        }
    }
}

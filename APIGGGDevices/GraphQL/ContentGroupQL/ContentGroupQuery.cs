using APIGGGDevices.Models;

namespace APIGGGDevices.GraphQL.ContentGroupQL
{
    [ExtendObjectType("Query")]
    public class ContentGroupQuery
    {
        [UsePaging(IncludeTotalCount = true, MaxPageSize = 100)]
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<ContentGroup> GetContentGroup([Service] GGGDevicesContext context)
        {
            return context.ContentGroups;
        }
    }
}

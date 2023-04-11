using APIGGGDevices.Models;

namespace APIGGGDevices.GraphQL.AudioGroupQL
{
    [ExtendObjectType("Query")]
    public class AudioGroupQuery
    {
        [UsePaging(IncludeTotalCount = true, MaxPageSize = 100)]
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<AudioGroup> GetAudioGroup([Service] GGGDevicesContext context)
        {
            return context.AudioGroups;
        }
    }
}

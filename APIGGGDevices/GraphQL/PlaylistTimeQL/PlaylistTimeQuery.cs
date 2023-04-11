
using APIGGGDevices.Models;
using Microsoft.EntityFrameworkCore;

namespace APIGGGDevices.GraphQL.PlaylistTimeQL
{
    [ExtendObjectType("Query")]
    public class PlaylistTimeQuery
    {
        [UsePaging(IncludeTotalCount = true, MaxPageSize = 100)]
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<PlaylistTime> GetPlaylists([Service] GGGDevicesContext context)
        {
            return context.PlaylistTimes;
        }
    }
}

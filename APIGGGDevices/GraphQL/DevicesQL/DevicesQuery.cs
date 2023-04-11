using APIGGGDevices.Models;

namespace APIGGGDevices.GraphQL.DevicesQL
{
    [ExtendObjectType("Query")]
    public class DevicesQuery
    {
        [UsePaging(IncludeTotalCount = true, MaxPageSize = 100)]
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Device> GetDevices([Service] GGGDevicesContext context)
        {
            return context.Devices;
        }
    }
}

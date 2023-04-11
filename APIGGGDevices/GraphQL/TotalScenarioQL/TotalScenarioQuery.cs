using APIGGGDevices.Models;

namespace APIGGGDevices.GraphQL.TotalScenarioQL
{
    [ExtendObjectType("Query")]
    public class TotalScenarioQuery
    {
        [UsePaging(IncludeTotalCount = true,MaxPageSize = 100) ]
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        
        public IQueryable<TotalScenario> GetTotalScenarios([Service] GGGDevicesContext context)
        {
            return context.TotalScenarios;
        }
    }
}

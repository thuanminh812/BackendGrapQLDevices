using APIGGGDevices.Models;
#nullable disable
namespace APIGGGDevices.GraphQL.TotalScenarioQL
{
    [ExtendObjectType("Mutation")]
    public class TotalScenarioMutation
    {
        public async Task<TotalScenario> AddTotal([Service] GGGDevicesContext context, TotalScenario totalScenario)
        {
            var add = new TotalScenario
            {
                Name = totalScenario.Name,
                Creator = totalScenario.Creator,
                CreatedAt = DateTime.Now,
                TypeLcd = totalScenario.TypeLcd,
                Media = totalScenario.Media,
                UserId = totalScenario.UserId,
                DataNumber = totalScenario.DataNumber,
                FileNumber = totalScenario.FileNumber,
                UpdatedAt = DateTime.Now,
            };
            context.TotalScenarios.Add(add);
            await context.SaveChangesAsync();
            return add;
        }
        public async Task<TotalScenario> UpdateTotal([Service] GGGDevicesContext context, TotalScenario totalScenarioupdate)
        {
            if (totalScenarioupdate.Id > 0)
            {
                var total = context.TotalScenarios.Where(x => x.Id == totalScenarioupdate.Id).FirstOrDefault();
                total.Name = totalScenarioupdate.Name;
                total.FileNumber = totalScenarioupdate.FileNumber;
                total.DataNumber = totalScenarioupdate.DataNumber;
                total.Creator = totalScenarioupdate.Creator;
                total.Media = totalScenarioupdate.Media;
                total.CreatedAt = DateTime.UtcNow;
                total.TypeLcd = totalScenarioupdate.TypeLcd;
                total.UserId = totalScenarioupdate.UserId;
                total.UpdatedAt = DateTime.UtcNow;
                context.Update(total);
                await context.SaveChangesAsync();
                return total;
            }
            else
            {
                return totalScenarioupdate;
            }
        }
        public async Task<TotalScenario> DeleteTotal([Service] GGGDevicesContext context, int idtotal)
        {
            var id = context.TotalScenarios.Find(idtotal);
            context.TotalScenarios.Remove(id);
            await context.SaveChangesAsync();
            return id;
        }
    }
}

using APIGGGDevices.Models;
#nullable disable
namespace APIGGGDevices.GraphQL.DevicesQL
{
    [ExtendObjectType("Mutation")]
    public class DevicesMutation
    {
        public async Task<Device> AddDevice([Service] GGGDevicesContext context, Device device)
        {
            var add = new Device
            {
                TypeId = device.TypeId,
                Name = device.Name,
                Imei = device.Imei,
                Status = device.Status,
                CreatedAt = DateTime.Now,
            };
            context.Devices.Add(add);
            await context.SaveChangesAsync();
            return add;
        }
        public async Task<Device> UpdateDevice([Service] GGGDevicesContext context, Device deviceupdate)
        {
            if(deviceupdate.Id > 0)
            {
                var device = context.Devices.Where(x => x.Id == deviceupdate.Id).FirstOrDefault();
                device.TypeId = deviceupdate.TypeId;
                device.Name = deviceupdate.Name;
                device.Imei = deviceupdate.Imei;
                device.Status = deviceupdate.Status;
                device.CreatedAt = DateTime.Now;
                context.Devices.Update(deviceupdate);
                await context.SaveChangesAsync();
                return device;

            }
            else
            {
                return deviceupdate;
            }
        }
        public async Task<Device> DeleteDevice([Service] GGGDevicesContext context, int iddevice)
        {
            var device = context.Devices.Find(iddevice);
            context.Devices.Remove(device);
            await context.SaveChangesAsync();
            return device;

        }
    }
}

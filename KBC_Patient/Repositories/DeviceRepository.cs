using System.Threading.Tasks;
using KBC_Patient.Data.Interfaces;
using KBC_Patient.Entities;
using KBC_Patient.Repositories.Interfaces;
using MongoDB.Driver;

namespace KBC_Patient.Repositories
{
    public class DeviceRepository:IDeviceRepository
    {
        private readonly IDeviceDataContext _deviceDataContext;

        public DeviceRepository(IDeviceDataContext deviceDataContext)
        {
            _deviceDataContext = deviceDataContext;
        }

        public async Task<Device> GetDeviceAsync(string id)
        {
            var device =await _deviceDataContext.Devices.Find(eachDevice => eachDevice.Id == id).FirstOrDefaultAsync();
            return device;
        }

        public async Task<bool> UpdateAsync(Device device)
        {
            var updateResult =
                await _deviceDataContext.Devices.ReplaceOneAsync(eachDevice => eachDevice.Id == device.Id,
                    device);

            return updateResult.IsAcknowledged && updateResult.ModifiedCount > 0;
        }
    }
}
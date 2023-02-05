using KBC_Patient.Data.Interfaces;
using KBC_Patient.Entities;
using KBC_Patient.Settings.Interfaces;
using MongoDB.Driver;

namespace KBC_Patient.Data
{
    public class DeviceDataContext:IDeviceDataContext
    {
        public IMongoCollection<Device> Devices { get; }
        
        public DeviceDataContext(IDeviceDatabaseSettings deviceDatabaseSettings)
        {

            var client = new MongoClient(deviceDatabaseSettings.ConnectionString);
            var database = client.GetDatabase(deviceDatabaseSettings.DatabaseName);
            Devices = database.GetCollection<Device>(deviceDatabaseSettings.CollectionName);
            DeviceDataContextSeed.SeedData(Devices);
        }
    }
}
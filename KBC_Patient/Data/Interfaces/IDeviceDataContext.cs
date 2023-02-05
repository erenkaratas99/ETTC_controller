using KBC_Patient.Entities;
using MongoDB.Driver;

namespace KBC_Patient.Data.Interfaces
{
    public interface IDeviceDataContext
    {
        IMongoCollection<Device> Devices { get; }
    }
}
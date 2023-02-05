using System.Collections.Generic;
using KBC_Patient.Entities;
using MongoDB.Driver;

namespace KBC_Patient.Data
{
    public class DeviceDataContextSeed
    {
        public static void SeedData(IMongoCollection<Device> deviceCollection)
        {
            if (!deviceCollection.Find(patient => true).Any())
            {
                deviceCollection.InsertManyAsync(GetFirstData());
            }
        }


        private static IEnumerable<Device> GetFirstData()
        {
            return new List<Device>
            {
                new Device()
                {
                    Id = "6174419517f0616f758a9815",
                    IsDecreasing = false,
                    IsIncreasing = false,
                    IsWorking = false
                }
            };
        }
    }
}
using System.Threading.Tasks;
using KBC_Patient.Entities;

namespace KBC_Patient.Repositories.Interfaces
{
    public interface IDeviceRepository
    {
        Task<Device> GetDeviceAsync(string id);
        Task<bool> UpdateAsync(Device patient);
    }
}
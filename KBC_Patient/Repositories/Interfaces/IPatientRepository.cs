using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using KBC_Patient.Entities;

namespace KBC_Patient.Repositories.Interfaces
{
    public interface IPatientRepository
    {
        Task<Patient> GetPatientsAsync();
        Task<Patient> GetPatientAsync(string id);
        Task<IEnumerable<Patient>> GetPatientsAllAsync();
        Task<Patient> AddPatientAsync(Patient patient);
        Task<bool> UpdateAsync(Patient patient);
        Task<bool> DeleteAsync(string id);
        
    }
}
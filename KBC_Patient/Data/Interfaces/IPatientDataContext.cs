using KBC_Patient.Entities;
using MongoDB.Driver;

namespace KBC_Patient.Data.Interfaces
{
    public interface IPatientDataContext
    {
        IMongoCollection<Patient> Patients { get; }
    }
}
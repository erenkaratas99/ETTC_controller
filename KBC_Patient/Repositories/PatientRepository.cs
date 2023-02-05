using System.Collections.Generic;
using System.Threading.Tasks;
using KBC_Patient.Data.Interfaces;
using KBC_Patient.Entities;
using KBC_Patient.Repositories.Interfaces;
using MongoDB.Driver;

namespace KBC_Patient.Repositories
{
    public class PatientRepository:IPatientRepository
    {

        private readonly IPatientDataContext _patientDataContext;

        public PatientRepository(IPatientDataContext patientDataContext)
        {
            _patientDataContext = patientDataContext;
        }

        public async Task<Patient> GetPatientsAsync()
        {
            return await _patientDataContext.Patients.Find(patient => true).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Patient>> GetPatientsAllAsync()
        {
            return await _patientDataContext.Patients.Find(patient => true).ToListAsync();
        }

        public async Task<Patient> GetPatientAsync(string id)
        {
            var patient =await _patientDataContext.Patients.Find(eachPatient => eachPatient.Id == id).FirstOrDefaultAsync();
            return patient;
        }

        public async Task<Patient> AddPatientAsync(Patient patient)
        {
            await _patientDataContext.Patients.InsertOneAsync(patient);
            return patient;
        }

        public async Task<bool> UpdateAsync(Patient patient)
        {
            var updateResult =
                await _patientDataContext.Patients.ReplaceOneAsync(eachPatient => eachPatient.Id == patient.Id,
                    patient);

            return updateResult.IsAcknowledged && updateResult.ModifiedCount > 0;
        }

        public async Task<bool> DeleteAsync(string id)
        {
            var deleteResult = await _patientDataContext.Patients.DeleteOneAsync(eachPatient => eachPatient.Id == id);

            return deleteResult.IsAcknowledged && deleteResult.DeletedCount > 0;
        }
    }
}
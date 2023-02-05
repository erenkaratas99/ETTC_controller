using KBC_Patient.Data.Interfaces;
using KBC_Patient.Entities;
using KBC_Patient.Settings.Interfaces;
using MongoDB.Driver;

namespace KBC_Patient.Data
{
    public class PatientDataContext:IPatientDataContext
    {
        public IMongoCollection<Patient> Patients { get; }

        public PatientDataContext(IPatientsDatabaseSettings patientsDatabaseSettings)
        {

            var client = new MongoClient(patientsDatabaseSettings.ConnectionString);
            var database = client.GetDatabase(patientsDatabaseSettings.DatabaseName);
            Patients = database.GetCollection<Patient>(patientsDatabaseSettings.CollectionName);
            //PatientDataContextSeed.SeedData(Patients);
        }
    }
}
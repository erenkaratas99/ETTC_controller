using System.Collections.Generic;
using KBC_Patient.Entities;
using MongoDB.Driver;

namespace KBC_Patient.Data
{
    public static class PatientDataContextSeed
    {

        public static void SeedData(IMongoCollection<Patient> patientCollection)
        {
            if (!patientCollection.Find(patient => true).Any())
            {
                patientCollection.InsertManyAsync(GetFirstData());
            }
        }


        private static IEnumerable<Patient> GetFirstData()
        {
            return new List<Patient>
            {
                new Patient
                {
                    Id = "61744f9517f0616f758a9815",
                    Pressure = 1999.9
                }
               
            };

        }
    }
}
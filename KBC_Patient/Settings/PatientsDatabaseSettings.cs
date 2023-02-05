using KBC_Patient.Settings.Interfaces;

namespace KBC_Patient.Settings
{
    public class PatientsDatabaseSettings:IPatientsDatabaseSettings
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
        public string CollectionName { get; set; }
    }
}
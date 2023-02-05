namespace KBC_Patient.Settings.Interfaces
{
    public interface IPatientsDatabaseSettings
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
        public string CollectionName { get; set; }
    }
}
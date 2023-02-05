namespace KBC_Patient.Settings.Interfaces
{
    public interface IDeviceDatabaseSettings
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
        public string CollectionName { get; set; }
    }
}
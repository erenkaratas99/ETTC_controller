namespace KBC_Patient.Entities
{
    public class PatientForUpdate
    {
        public float Pressure { get; set; }
        public float BottomLimit { get; set; }
        public float UpperLimit { get; set; }
        public string Name { get; set; }
        public string Surname{ get; set; }
    }
}
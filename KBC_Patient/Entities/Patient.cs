using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace KBC_Patient.Entities
{
    public class Patient
    {
        
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public double Pressure { get; set; }
        public double BottomLimit { get; set; }
        public double UpperLimit { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

    }
}
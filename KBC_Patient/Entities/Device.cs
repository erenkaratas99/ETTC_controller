using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace KBC_Patient.Entities
{
    public class Device
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public bool IsIncreasing { get; set; }
        public bool IsDecreasing { get; set; }
        public bool IsWorking { get; set; }
    }
}
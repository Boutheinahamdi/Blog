using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Blog1.Models
{
    [BsonIgnoreExtraElements]
    public class Project
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string ID { get; set; }
        public string title { get; set; }
        public string urlImage { get; set; }
        public string Description { get; set; }
        public string content { get; set; }
    }
}

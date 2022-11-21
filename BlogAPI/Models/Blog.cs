using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BlogAPI.Models
{
    public class Blog
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string ID { get; set; }
        public string title { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }
        public string date { get; set; }
        public string urlImage { get; set; }
    }
}

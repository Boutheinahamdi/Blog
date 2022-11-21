using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Owner.Models
{
    public class Owner1
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string ID { get; set; }
        public string name { get; set; }
        public string smalldesc { get; set; }
        public string description { get; set; }
        public string urlimage { get; set; }
        public int age { get; set; }
        public int phone { get; set; }
        public string email { get; set; }
        public string adress { get; set; }
    }
}

using MongoDB.Bson.Serialization.Attributes;

namespace MVC.Core.Entities
{
    public class Reactions
    {
        [BsonElement("email")]
        public string Email { get; set; }
    }
}

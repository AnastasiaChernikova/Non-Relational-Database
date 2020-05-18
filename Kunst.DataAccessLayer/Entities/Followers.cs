using MongoDB.Bson.Serialization.Attributes;

namespace MVC.Core.Entities
{
    public class Followers
    {
        [BsonElement("name")]
        public string Name { get; set; }

        [BsonElement("nickname")]
        public string Nickname { get; set; }

        [BsonElement("email")]
        public string Email { get; set; }

        [BsonElement("avatar")]
        public string Avatar { get; set; }
    }
}
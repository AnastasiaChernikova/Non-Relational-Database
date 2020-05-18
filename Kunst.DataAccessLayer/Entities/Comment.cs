using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace MVC.Core.Entities
{
    [BsonIgnoreExtraElements]
    public class Comment
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("authorEmail")]
        public string AuthorEmail { get; set; }

        [BsonElement("authorName")]
        public string AuthorName { get; set; }

        [BsonElement("authorNickname")]
        public string AuthorNickname { get; set; }

        [BsonElement("authorAvatar")]
        public string AuthorAvatar { get; set; }

        [BsonElement("time")]
        public DateTime Time { get; set; }

        [BsonElement("text")]
        public string Text { get; set; }
    }
}

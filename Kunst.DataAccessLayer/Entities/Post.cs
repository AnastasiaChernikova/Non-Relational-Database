using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;

namespace MVC.Core.Entities
{
    [BsonIgnoreExtraElements]
    public class Post
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

        [BsonElement("reactions")]
        public List<Reactions> Reactions { get; set; }
        
        [BsonElement("views")]
        public int Views { get; set; } = 0;

        [BsonElement("comments")]
        public List<Comment> Comments { get; set; }

    }
}

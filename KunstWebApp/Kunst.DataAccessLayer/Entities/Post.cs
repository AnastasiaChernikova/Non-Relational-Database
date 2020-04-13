using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kunst.DataAccessLayer.Entities
{
    class Post
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("authornickname")]
        public string AuthorNickname { get; set; }

        [BsonElement("time")]
        public DateTime Time { get; set; }

        [BsonElement("artmovement")]
        public string ArtMovement { get; set; }

        [BsonElement("message")]
        public string Message { get; set; }

        [BsonElement("reactions")]
        public List<Reaction> Reactions { get; set; }

        [BsonElement("comments")]
        public List<Comment> Comments { get; set; }
    }
}

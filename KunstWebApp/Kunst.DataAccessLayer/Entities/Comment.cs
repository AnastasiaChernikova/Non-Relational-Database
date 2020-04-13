using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kunst.DataAccessLayer.Entities
{
    public class Comment
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("authornickname")]
        public string AuthorNickname { get; set; }

        [BsonElement("time")]
        public DateTime Time { get; set; }

        [BsonElement("message")]
        public string Message { get; set; }
    }
}

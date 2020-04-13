using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kunst.DataAccessLayer.Entities
{
    public class Artist
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("name")]
        public string Name { get; set; }

        [BsonElement("nickname")]
        public string Nickname { get; set; }

        [BsonElement("email")]
        public string Email { get; set; }

        [BsonElement("nationality")]
        public string Nationality { get; set; }

        [BsonElement("birthdate")]
        public DateTime Birthdate { get; set; }

        [BsonElement("artmovement")]
        public string ArtMovement { get; set; }

        [BsonElement("website")]
        public string Website { get; set; }

        [BsonElement("hashPassword")]
        public string HashPassword { get; set; }

        [BsonElement("followers")]
        public List<Follower> Followers { get; set; }

    }
}

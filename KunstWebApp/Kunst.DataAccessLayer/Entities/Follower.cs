using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kunst.DataAccessLayer.Entities
{
    public class Follower
    {
        [BsonElement("name")]
        public string Name { get; set; }

        [BsonElement("nickname")]
        public string Nickname { get; set; }

        [BsonElement("email")]
        public string Email { get; set; }

        [BsonElement("artmovement")]
        public string ArtMovement { get; set; }

        [BsonElement("website")]
        public string Website { get; set; }
    }
}

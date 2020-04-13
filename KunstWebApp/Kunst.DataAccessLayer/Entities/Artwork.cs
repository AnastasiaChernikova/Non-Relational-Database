using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kunst.DataAccessLayer.Entities
{
    public class Artwork
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("name")]
        public string Name { get; set; }

        [BsonElement("authorname")]
        public string AuthorName { get; set; }

        [BsonElement("authornickname")]
        public string AuthorNickname { get; set; }

        [BsonElement("date")]
        public DateTime Date { get; set; }

        [BsonElement("style")]
        public string Style { get; set; }

        [BsonElement("genre")]
        public string Genre { get; set; }

        [BsonElement("website")]
        public string Website { get; set; }
    }
}

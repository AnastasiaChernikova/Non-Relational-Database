using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kunst.DataAccessLayer.Entities
{
    public class Reaction
    {
        [BsonElement("authornickname")]
        public string AuthorNickname { get; set; }
    }
}

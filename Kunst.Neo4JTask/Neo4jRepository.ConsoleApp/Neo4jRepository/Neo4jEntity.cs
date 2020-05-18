using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Neo4jRepository
{
    public class Neo4jEntity : IEntity
    {
        protected Neo4jEntity()
        {
            LastUpdated = DateTime.UtcNow;
        }

        // Gets or sets the label on a Neo4jEntity

        [JsonIgnore]
        [XmlIgnore]
        public string Label { get; protected set; }

        [JsonIgnore]
        [XmlIgnore]
        public DateTimeOffset LastUpdated { get; set; }
    }
}

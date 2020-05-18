using Newtonsoft.Json;

namespace Neo4jRepository
{
    public class Neo4jRelationship
    {
        [JsonIgnore]
        public string Name { get; set; }

        public Neo4jRelationship()
        {
        }
    }
}

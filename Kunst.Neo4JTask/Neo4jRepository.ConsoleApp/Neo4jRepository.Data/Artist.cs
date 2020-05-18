using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neo4jRepository.Data.Model
{
    public class Artist : Neo4jEntity
    {
        public string Name { get; set; }
        public string Nickname { get; set; }
        public string Email { get; set; }
        public DateTimeOffset Created { get; set; }

        public Artist()
        {
            Label = "Artist";
            Created = DateTimeOffset.UtcNow;
        }
    }
}

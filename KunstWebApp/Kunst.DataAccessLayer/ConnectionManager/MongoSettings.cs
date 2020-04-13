using System;
using System.Collections.Generic;
using System.Text;

namespace Kunst.DataAccessLayer.ConnectionManager
{
    public class MongoSettings : IMongoSettings
    {
        public string nameOfDatabase { get; set; }
        public string connString { get; set; }
    }
}

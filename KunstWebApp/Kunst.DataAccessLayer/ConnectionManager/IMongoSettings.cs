using System;
using System.Collections.Generic;
using System.Text;

namespace Kunst.DataAccessLayer.ConnectionManager
{
    public interface IMongoSettings
    {
        string nameOfDatabase { get; set; }
        string connString { get; set; }
    }
}

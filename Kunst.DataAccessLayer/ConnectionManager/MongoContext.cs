using MongoDB.Driver;
using MVC.Core.Entities;

namespace MVC.Core.Database.Config
{
    public class MongoContext : IMongoContext
    {
        private IMongoCollection<Post> _posts;
        private IMongoCollection<Artist> _users;
        private IMongoDatabase _database;

        public MongoContext(IMongoConfig mongoConfig)
        {
            var client = new MongoClient(mongoConfig.connectionString);
            _database = client.GetDatabase(mongoConfig.databaseName);
        }

        public IMongoCollection<Post> Posts
        {
            get
            {
                if (_posts == null)
                {
                    _posts = _database.GetCollection<Post>("posts");
                }
                return _posts;
            }
        }

        public IMongoCollection<Artist> Artists
        {
            get
            {
                if (_users == null)
                {
                    _users = _database.GetCollection<Artist>("users");
                }
                return _users;
            }
        }
    }
}

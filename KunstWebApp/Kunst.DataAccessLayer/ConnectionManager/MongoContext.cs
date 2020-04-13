using Kunst.DataAccessLayer.Entities;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kunst.DataAccessLayer.ConnectionManager
{
    public class MongoContext : IMongoContext
    {
        private IMongoCollection<Post> _postsContext;
        private IMongoCollection<Artist> _artistsContext;
        private IMongoCollection<Artwork> _artworksContext;

        private IMongoDatabase _database;

        public MongoContext(IMongoSettings mongoConfig)
        {
            var client = new MongoClient(mongoConfig.connString);
            _database = client.GetDatabase(mongoConfig.nameOfDatabase);
        }

        public IMongoCollection<Post> Posts
        {
            get
            {
                if (_postsContext == null)
                {
                    _postsContext = _database.GetCollection<Post>("posts");
                }
                return _postsContext;
            }
        }

        public IMongoCollection<Artist> Artists
        {
            get
            {
                if (_artistsContext == null)
                {
                    _artistsContext = _database.GetCollection<Artist>("artists");
                }
                return _artistsContext;
            }
        }

        public IMongoCollection<Artwork> Artworks
        {
            get
            {
                if (_artworksContext == null)
                {
                    _artworksContext = _database.GetCollection<Artwork>("artworks");
                }
                return _artworksContext;
            }
        }
    }
}

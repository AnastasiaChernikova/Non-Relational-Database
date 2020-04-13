using Kunst.DataAccessLayer.Entities;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kunst.DataAccessLayer.ConnectionManager
{
    public interface IMongoContext
    {
        IMongoCollection<Post> Posts { get; }
        IMongoCollection<Artist> Artists { get; }
        IMongoCollection<Artwork> Artworks { get; }
    }
}

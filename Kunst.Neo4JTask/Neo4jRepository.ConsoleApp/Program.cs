using Neo4jRepository.Data.Model;
using Neo4jRepository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neo4jRepository.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            AsyncMain().Wait();
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        static async Task AsyncMain()
        {
            ArtistRepository _repo = new ArtistRepository();
            Artist post1 = new Artist()
            {
                Name = "John Smith",
                Nickname = "Hello Blog!",
                Email = "Test blog Email"
            };
            Artist post2 = new Artist()
            {
                Name = "Jane Smith",
                Nickname = "Hello Blog!",
                Email = "Test blog Email"
            };

            _repo.AddOrUpdate(post1);
            _repo.AddOrUpdate(post2);
            IEnumerable<Artist> Artists = await _repo.All();
            IEnumerable<Artist> janesPosts = await _repo.Where(b => b.Name == "Jane Smith");
            foreach(var Artist in Artists)
            {
                Console.WriteLine(Artist.Name);
            }

            foreach(var Artist in janesPosts)
            {
                Console.WriteLine(Artist.Name);
            }
        }
    }
}

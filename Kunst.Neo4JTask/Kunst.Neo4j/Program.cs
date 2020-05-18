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
                Name = "Vincent van Gogh",
                Nickname = "Gogh_V",
                Email = "gogh_v@gmail.com"
            };
            Artist post2 = new Artist()
            {
                Name = "Gustav Klimt",
                Nickname = "Gustav_K",
                Email = "gustav_k@gmail.com"
            };

            _repo.AddOrUpdate(post1);
            _repo.AddOrUpdate(post2);
            IEnumerable<Artist> Artists = await _repo.All();
            IEnumerable<Artist> goghArtist = await _repo.Where(b => b.Name == "Vincent van Gogh");
            foreach(var Artist in Artists)
            {
                Console.WriteLine(Artist.Name);
            }

            foreach(var Artist in goghArtist)
            {
                Console.WriteLine(Artist.Name);
            }
        }
    }
}

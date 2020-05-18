using Neo4jRepository.Data.Model;
using System.Threading.Tasks;

namespace Neo4jRepository.Repository
{
    public class ArtistRepository : Neo4jRepository<Artist>
    {
        // any custom methods or overridden methods here

        /// <summary>
        /// Adds the or update.
        /// </summary>
        /// <param name="post">The post.</param>
        /// <returns></returns>
        public async Task AddOrUpdate(Artist post)
        {
            var found = await this.Single(p => p.Name == post.Name && p.Email == post.Email && p.Nickname == post.Nickname);
            if(found == null)
            {
                Add(post);
            }
            else
            {
                Update(p => p.Name == post.Name && p.Email == post.Email && p.Nickname == post.Nickname, post);
            }
        }
    }
}

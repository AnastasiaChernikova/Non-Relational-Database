using AutoMapper;
using MongoDB.Bson;
using MongoDB.Driver;
using MVC.Core.Database.Config;
using MVC.Core.Entities;
using MVC.Interfaces;
using MVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC.Services
{
    public class ArtistService : IArtistService
    {
        private static readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();

        private readonly IMongoContext _context;
        private readonly IMapper _mapper;

        public ArtistService(IMongoContext context, IMapper mapper)
        {
            this._context = context;
            this._mapper = mapper;
        }
        public async Task<IEnumerable<ArtistViewModel>> GetAllAsync()
        {
            var result = await _context.Artists.AsQueryable().ToListAsync();
            return result.Select(p => _mapper.Map<ArtistViewModel>(p));
        }
        public async Task<ArtistViewModel> GetByEmailAsync(string email)
        {
            var result = await _context
                .Artists
                .AsQueryable()
                .ToListAsync();

            var user = _mapper.Map<ArtistViewModel>(result.SingleOrDefault(u => u.Email == email));
            return user;
        }
        public async Task<ArtistViewModel> GetByIdAsync(string id)
        {
            var result = await _context
                .Artists
                .AsQueryable()
                .ToListAsync();

            var user = _mapper.Map<ArtistViewModel>(result.SingleOrDefault(u => u.Id == id));
            return user;
        }
        public async void InsertUserAsync(ArtistViewModel userModel)
        {
            var user = _mapper.Map<Artist>(userModel);
            user.Id = Convert.ToString(ObjectId.GenerateNewId());
            await _context.Artists.InsertOneAsync(user);
        }
        public async Task<bool> IsUserExistsAsync(string email)
        {
            var result = await _context.Artists.AsQueryable().ToListAsync();
            var user = result.SingleOrDefault(u => u.Email == email);
            if (user == null)
            {
                return false;
            }
            return true;
        }

        public async Task<bool> CheckPasswordByEmailAsync(string email, string password)
        {
            var builder = Builders<Artist>.Filter;
            var filter = builder.Eq(el => el.Email, email);

            var user = await _context.Artists.Find(filter).SingleAsync();
            if (user.Password == password)
            {
                return true;
            }
            return false;
        }
        public async Task<PortfolioViewModel> UpdateUserAsync(PortfolioViewModel userModel)
        {
            var oldUser = await GetByEmailAsync(userModel.Email);

            var user = _mapper.Map<Artist>(userModel);
            user.Id = oldUser.Id;

            user.Followers = oldUser.Followers;

            if (userModel.Password == null)
            {
                user.Password = oldUser.Password;
            }
            if (userModel.Avatar == null)
            {
                user.Avatar = oldUser.Avatar;
            }

            var builder = Builders<Artist>.Filter;
            var filter = builder.Eq(el => el.Email, userModel.Email);
            var options = new FindOneAndUpdateOptions<Post>();
            options.ReturnDocument = ReturnDocument.After;

            await _context.Artists.ReplaceOneAsync(filter, user);

            UpdateFriendsUserInfo(user);
            UpdatePostsUserInfo(user);
            UpdateCommentsUserInfo(user);

            return userModel;
        }

        public async Task<PortfolioViewModel> GetProfileModel(ArtistViewModel userModel)
        {
            var user = await GetByEmailAsync(userModel.Email);
            var updateModel = _mapper.Map<PortfolioViewModel>(userModel);
            return updateModel;
        }

        public void Follow(string requesterEmail, string userEmail)
        {
            FollowdByEmailAsync(requesterEmail, userEmail);
            FollowdByEmailAsync(userEmail, requesterEmail);
        }
        public void RemoveFriend(string requesterEmail, string userEmail)
        {
            RemoveFriendByEmailAsync(requesterEmail, userEmail);
            RemoveFriendByEmailAsync(userEmail, requesterEmail);
        }

        private async void FollowdByEmailAsync(string requesterEmail, string userEmail)
        {
            var friend = _mapper.Map<Followers>(await GetByEmailAsync(userEmail));


            var filter = Builders<Artist>.Filter.Eq(el => el.Email, requesterEmail);
            var update = Builders<Artist>.Update
                    .Push<Followers>(el => el.Followers, friend);

            await _context.Artists.FindOneAndUpdateAsync(filter, update);
        }
        private async void RemoveFriendByEmailAsync(string requesterEmail, string userEmail)
        {
            var friend = _mapper.Map<Followers>(await GetByEmailAsync(userEmail));

            var filter = Builders<Artist>.Filter.Eq(el => el.Email, requesterEmail);
            var update = Builders<Artist>.Update
                    .Pull<Followers>(el => el.Followers, friend);

            await _context.Artists.FindOneAndUpdateAsync(filter, update);

        }
        private async void UpdateFriendsUserInfo(Artist user)
        {
            var update = Builders<Artist>.Update
                .Set(el => el.Followers[-1].Name, user.Name)
                .Set(el => el.Followers[-1].Nickname, user.Nickname)
                .Set(el => el.Followers[-1].Avatar, user.Avatar);

            await _context.Artists.UpdateManyAsync<Artist>(
                el => el.Followers.Any(el => el.Email == user.Email), update
                );
        }

        private async void UpdatePostsUserInfo(Artist user)
        {
            var update = Builders<Post>.Update
                .Set(el => el.AuthorName, user.Name)
                .Set(el => el.AuthorNickname, user.Nickname)
                .Set(el => el.AuthorAvatar, user.Avatar);

            await _context.Posts.UpdateManyAsync<Post>(
                el => el.AuthorEmail == user.Email, update
                );
        }
        private async void UpdateCommentsUserInfo(Artist user)
        {
            //                el => el.Comments.Where(el => el.AuthorEmail == user.Email)
            var update = Builders<Post>.Update
               .Set("comments.$[g].authorName", user.Name)
               .Set("comments.$[g].authorNickname", user.Nickname)
               .Set("comments.$[g].authorAvatar", user.Avatar);

            var filter = Builders<Post>.Filter
                .Where(x => x.Comments.Any(c => c.AuthorEmail == user.Email));

            var updateOprions = new UpdateOptions
            {
                ArrayFilters = new List<ArrayFilterDefinition>
                 {
                    new BsonDocumentArrayFilterDefinition<BsonDocument>(new BsonDocument("g.authorEmail", user.Email)),
                 }
            };

            await _context.Posts.UpdateManyAsync(filter, update, updateOprions);
        }

    }
}
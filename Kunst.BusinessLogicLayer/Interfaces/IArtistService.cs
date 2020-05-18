using MVC.Core.Entities;
using MVC.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MVC.Interfaces
{
    public interface IArtistService
    {
        Task<IEnumerable<ArtistViewModel>> GetAllAsync();
        Task<ArtistViewModel> GetByEmailAsync(string email);
        Task<ArtistViewModel> GetByIdAsync(string id);
        Task<bool> IsUserExistsAsync(string email);
        Task<bool> CheckPasswordByEmailAsync(string email, string password);
        void InsertUserAsync(ArtistViewModel userModel);
        void Follow(string requesterEmail, string userEmail);
        void RemoveFriend(string requesterEmail, string userEmail);
        Task<PortfolioViewModel> GetProfileModel(ArtistViewModel model);
        Task<PortfolioViewModel> UpdateUserAsync(PortfolioViewModel userModel);
    }
}

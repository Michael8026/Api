using api.Models;

namespace api.Interfaces
{
    public interface IUserProfileRepository
    {
        Task<List<UserProfile>> GetAllAsync();
        Task<UserProfile> CreateAsync(UserProfile userProfile);

    }
}

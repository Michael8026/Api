using api.Data;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{

    public class UserProfileRepository : IUserProfileRepository
    {

        private readonly ApplicationDbContext _context;
        public UserProfileRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<UserProfile> CreateAsync(UserProfile userProfile)
        {
            await _context.UserProfiles.AddAsync(userProfile);
            await _context.SaveChangesAsync();
            return userProfile;

        }


        public async Task<List<UserProfile>> GetAllAsync()
        {
            return await _context.UserProfiles.ToListAsync();
        }


    }
}

using AssignmentAPI.Data;
using AssignmentAPI.Models.Domain;
using AssignmentAPI.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace AssignmentAPI.Repositories.Implementation
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDBContext dbContext;

        public UserRepository(ApplicationDBContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<User> CreateAsync(User user)
        {
            await dbContext.Users.AddAsync(user);
            await dbContext.SaveChangesAsync();

            return user;
        }

        public async Task<User?> DeleteAsync(string id)
        {
            var existingUser = await dbContext.Users.FirstOrDefaultAsync(c => c.id == id);
            if (existingUser is null)
            {
                return null;
            }

            dbContext.Users.Remove(existingUser);
            await dbContext.SaveChangesAsync();
            return existingUser;
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await dbContext.Users.ToListAsync();
        }

        public async Task<User?> GetById(string id)
        {
            return await dbContext.Users.FirstOrDefaultAsync(c => c.id == id);
        }

        public async  Task<User?> UpdateAsync(User user)
        {
            var existingUser = await dbContext.Users.FirstOrDefaultAsync(c => c.id == user.id);
            if (existingUser != null)
            {
                dbContext.Entry(existingUser).CurrentValues.SetValues(user);
                await dbContext.SaveChangesAsync();
                return user;
            }

            return null;
        }
    }
}

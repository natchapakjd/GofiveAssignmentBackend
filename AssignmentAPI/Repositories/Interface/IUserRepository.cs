using AssignmentAPI.Models.Domain;

namespace AssignmentAPI.Repositories.Interface
{
    public interface IUserRepository
    {
        Task<User> CreateAsync(User user);
        Task<IEnumerable<User>> GetAllAsync();

        Task<User?> GetById(string id);

        Task<User?> UpdateAsync(User user);
        Task<User?> DeleteAsync(string id);
    }
}

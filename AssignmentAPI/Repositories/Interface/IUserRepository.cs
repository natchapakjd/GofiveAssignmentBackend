using AssignmentAPI.Models.Domain;

namespace AssignmentAPI.Repositories.Interface
{
    public interface IUserRepository
    {
        Task<User> CreateAsync(User user);
        Task<IEnumerable<User>> GetDataTable(string? query = null ,string? sortBy = null, string? sortDirection = null,int? pageNumber =  1 ,int? pageSize = 100);

        Task<User?> GetById(string id);
        Task<IEnumerable<User>> GetAllAsync();

        Task<User?> UpdateAsync(User user);
        Task<User?> DeleteAsync(string id);
    }
}

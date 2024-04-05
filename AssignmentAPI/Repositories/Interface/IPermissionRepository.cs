using AssignmentAPI.Models.Domain;

namespace AssignmentAPI.Repositories.Interface
{
    public interface IPermissionRepository
    {
        Task<IEnumerable<Permission>> GetAllAsync();

        Task<Permission> CreateAsync(Permission permission);

        Task<Permission?> GetById(string permissionId);


    }
}

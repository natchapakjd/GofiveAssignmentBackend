using AssignmentAPI.Data;
using AssignmentAPI.Models.Domain;
using AssignmentAPI.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace AssignmentAPI.Repositories.Implementation
{
    public class PermissionRepository : IPermissionRepository
    {
        private readonly ApplicationDBContext dbContext;
        public PermissionRepository( ApplicationDBContext dbContext) { 
        
            this.dbContext = dbContext;
        }

        public async Task<Permission> CreateAsync(Permission permission)
        {
            await dbContext.Permissions.AddAsync(permission);
            await dbContext.SaveChangesAsync();

            return permission;
        }

        public async Task<IEnumerable<Permission>> GetAllAsync()
        {
            return await dbContext.Permissions.ToListAsync();
        }

        public async Task<Permission?> GetById(string permissionId)
        {
            return await dbContext.Permissions.FirstOrDefaultAsync(c => c.permissionId == permissionId);

        }
    }
}

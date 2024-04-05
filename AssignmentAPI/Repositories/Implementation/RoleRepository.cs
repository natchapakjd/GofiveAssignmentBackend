using AssignmentAPI.Data;
using AssignmentAPI.Models.Domain;
using AssignmentAPI.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace AssignmentAPI.Repositories.Implementation
{
    public class RoleRepository : IRoleRepository
    {
        private readonly ApplicationDBContext dbContext;
        public RoleRepository(ApplicationDBContext dbContext) { 
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<Role>> GetAllAsync()
        {
            return await dbContext.Roles.ToListAsync();
        }
    }
}

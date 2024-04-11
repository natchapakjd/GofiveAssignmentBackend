using AssignmentAPI.Models.DTO.Roles;
using AssignmentAPI.Repositories.Implementation;
using AssignmentAPI.Repositories.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AssignmentAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {

        private readonly IRoleRepository roleRepository;

        public RoleController(IRoleRepository roleRepository)
        {
            this.roleRepository = roleRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllRoles()
        {

            var roles = await roleRepository.GetAllAsync();

            var response = new List<RoleDto>();

            foreach (var role in roles)
            {
                response.Add(new RoleDto()
                {
                    roleId = role.roleId,
                    roleName = role.roleName,
                    
                });
            }

            return Ok(response);
        }
    }
}

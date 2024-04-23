using AssignmentAPI.Models.Domain;
using AssignmentAPI.Models.DTO;
using AssignmentAPI.Models.DTO.Permissions;
using AssignmentAPI.Repositories.Implementation;
using AssignmentAPI.Repositories.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AssignmentAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PermissionController : ControllerBase
    {
        private readonly IPermissionRepository permissionRepository;

        public PermissionController(IPermissionRepository permissionRepository)
        {
            this.permissionRepository = permissionRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPermissions()
        {

            var permissions = await permissionRepository.GetAllAsync();

            var response = new List<PermissionDto>();

            foreach (var permission in permissions)
            {
                response.Add(new PermissionDto()
                {
                    permissionId = permission.permissionId,
                    permissionName = permission.permissionName,
                    isDeletable = permission.isDeletable,
                    isReadable = permission.isReadable,
                    isWritable = permission.isWritable

                });
            }

            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategoryById([FromRoute] string id)
        {
            var existingPermission = await permissionRepository.GetById(id);

            if (existingPermission is null)
            {
                return NotFound();
            }

            var response = new ResponsePermission
            {
                permissionId = existingPermission.permissionId,
                permissionName = existingPermission.permissionName,
            };

            return Ok(response);
        }

    }
}

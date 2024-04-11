using AssignmentAPI.Data;
using AssignmentAPI.Models.Domain;
using AssignmentAPI.Models.DTO;
using AssignmentAPI.Models.DTO.Permissions;
using AssignmentAPI.Models.DTO.Users;
using AssignmentAPI.Repositories.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AssignmentAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository userRepository;
        private readonly IPermissionRepository permissionRepository;

        public UserController(IUserRepository userRepository, IPermissionRepository permissionRepository)
        {
            this.userRepository = userRepository;
            this.permissionRepository = permissionRepository;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUserTest(CreateUserDto request)
        {
            var user = new User
            {
                id = request.id,
                userName = request.userName,
                password = request.password,
                firstName = request.firstName,
                lastName = request.lastName,
                phone = request.phone,
                email = request.email,
                roleId = request.roleId,
                createdDate = DateTime.Now,
                Permissions = new List<Permission>()
            };
            foreach (var permissionString in request.permissions)
            {
                var existingPermission = await permissionRepository.GetById(permissionString.permissionId);
                if (existingPermission != null)
                {
                    user.Permissions.Add(existingPermission);
                }
            }

            user = await userRepository.CreateAsync(user);


            var response = new UserDto
            {
                id = user.id,
                userName = user.userName,
                password = user.password,
                firstName = user.firstName,
                lastName = user.lastName,
                phone = user.phone,
                email = user.email,
                roleId = user.roleId,
                createdDate = user.createdDate,
                Permissions = user.Permissions.Select(x => new ResponsePermissionAllDto
                {
                    permissionId = x.permissionId,
                    isReadable = x.isReadable,
                    isWritable = x.isWritable,
                    isDeletable = x.isDeletable
                }).ToList()
            };
            return Ok(response);
        }
        [HttpGet]

        public async Task<IActionResult> GetAllUsers()
        {
            var users = await userRepository.GetAllAsync();

            var response = new List<UserDto>();

            foreach (var user in users)
            {
                response.Add(new UserDto()
                {
                    id = user.id,
                    userName = user.userName,
                    password = user.password,
                    firstName = user.firstName,
                    lastName = user.lastName,
                    phone = user.phone,
                    email = user.email,
                    roleId = user.roleId,
                    createdDate = user.createdDate,

                    Permissions = user.Permissions.Select(x  => new ResponsePermissionAllDto
                    {
                        permissionId = x.permissionId,
                        isReadable = x.isReadable,
                        isWritable = x.isWritable,
                        isDeletable = x.isDeletable
                    }).ToList()

                });
            }

            return Ok(response);
        }

        [HttpPost("DataTable")]

        public async Task<IActionResult> GetDataTable(
            [FromQuery] string? search,
            [FromQuery] string? orderBy,
            [FromQuery] string? orderDirection,
            [FromQuery] int? pageNumber,
            [FromQuery] int? pageSize)
        {
            var users = await userRepository.GetDataTable(search, orderBy, orderDirection, pageNumber, pageSize);

            var response = new List<UserDto>();

            foreach (var user in users)
            {
                response.Add(new UserDto()
                {
                    id = user.id,
                    userName = user.userName,
                    password = user.password,
                    firstName = user.firstName,
                    lastName = user.lastName,
                    phone = user.phone,
                    email = user.email,
                    roleId = user.roleId,
                    createdDate = user.createdDate,


                });
            }

            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser([FromRoute] string id)
        {
            var user = await userRepository.DeleteAsync(id);
            if (user is null)
            {
                return NotFound();
            }

            var response = new DeleteUserDto
            {
                result = true,
               message = "Delete success"


            };
            return Ok(response);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById([FromRoute] string id)
        {
            var existingUser = await userRepository.GetById(id);

            if (existingUser is null)
            {
                return NotFound();
            }

            var response = new UserDto
            {
                id = existingUser.id,
                userName = existingUser.userName,
                password = existingUser.password,
                firstName = existingUser.firstName,
                lastName = existingUser.lastName,
                phone = existingUser.phone,
                email = existingUser.email,
                roleId = existingUser.roleId,
                Permissions = existingUser.Permissions.Select(x => new ResponsePermissionAllDto
                {
                    permissionId = x.permissionId,
                    isReadable = x.isReadable,
                    isWritable = x.isWritable,
                    isDeletable = x.isDeletable
                }).ToList()

            };

            return Ok(response);
        }
       
        [HttpPut("{id}")]
        public async Task<IActionResult> EditUserVersion2([FromRoute] string id, UpdateUserRequestDto request)
        {
            // Convert DTO to Domain Model

            var user = new User
            {
                id = id,
                userName = request.userName,
                password = request.password,
                firstName = request.firstName,
                lastName = request.lastName,
                phone = request.phone,
                email = request.email,
                roleId = request.roleId,
                Permissions = new List<Permission>()
            };

            foreach (var permissionString in request.permissions)
            {
                var existingPermission = await permissionRepository.GetById(permissionString.permissionId);
                if (existingPermission is not null)
                {
                    user.Permissions.Add(existingPermission);
                }
            }

            user = await userRepository.UpdateAsync(user);
            if (user == null)
            {
                return NotFound();
            }

            var response = new UserDto
            {
                id = user.id,
                userName = user.userName,
                password = user.password,
                firstName = user.firstName,
                lastName = user.lastName,
                phone = user.phone,
                email = user.email,
                roleId = user.roleId,
                Permissions = user.Permissions.Select(x => new PermissionDto
                {
                    permissionId = x.permissionId,
                    permissionName = x.permissionName,
                    isReadable = x.isReadable,
                    isWritable = x.isWritable,
                    isDeletable = x.isDeletable
                }).ToList()
            };
            return Ok(response);

        }

    }
}

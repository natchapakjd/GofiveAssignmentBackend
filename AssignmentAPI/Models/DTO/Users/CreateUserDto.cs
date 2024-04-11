using AssignmentAPI.Models.Domain;
using AssignmentAPI.Models.DTO.Permissions;
using System.ComponentModel.DataAnnotations;

namespace AssignmentAPI.Models.DTO.Users
{
    public class CreateUserDto
    {
        [Required]
        public string id { get; set; }
        [Required]

        public string userName { get; set; }
        [Required]

        public string firstName { get; set; }
        [Required]

        public string lastName { get; set; }
        [EmailAddress, Required]
        public string email { get; set; }
        public string password { get; set; }
        [Required]
        public AddPermission[] permissions { get; set; }
        [Required]

        public string roleId { get; set; }
        [Phone]
        public string? phone { get; set; }

    }

}
public class AddPermission
{
    [Required]
    public string permissionId { get; set; }
    [Required]
    public bool isReadable { get; set; }
    [Required]
    public bool isWritable { get; set; }
    [Required]
    public bool isDeletable { get; set; }
}
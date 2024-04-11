using System.ComponentModel.DataAnnotations;

namespace AssignmentAPI.Models.DTO.Users
{
    public class UpdateUserRequestDto
    {
        [Required]
        public string userName { get; set; }
        [Required]
        public string firstName { get; set; }
        [Required]
        public string lastName { get; set; }
        [Required,EmailAddress]
        public string email { get; set; }
        [Required]
        public string password { get; set; }
        [Required]
        public AddPermission[] permissions { get; set; }
        [Required]
        public string roleId { get; set; }

        public string? phone { get; set; }
    }
}

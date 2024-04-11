using AssignmentAPI.Models.Domain;
using AssignmentAPI.Models.DTO.Permissions;
using System.ComponentModel.DataAnnotations;

namespace AssignmentAPI.Models.DTO
{
    public class CreateUserRequestDto
    {
        [Required]
        public string id { get; set; }
        [Required]

        public string userName { get; set; }
        [Required]

        public string firstName { get; set; }
        [Required]

        public string lastName { get; set; }
        [EmailAddress,Required]
        public string email { get; set; }
        public string password { get; set; }
        [Required]

        public string[] Permissions { get; set; }
        [Required]

        public string roleId { get; set; }
        [Phone]
        public string phone { get; set; }

    }
}

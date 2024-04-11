using AssignmentAPI.Models.Domain;
using AssignmentAPI.Models.DTO.Permissions;

namespace AssignmentAPI.Models.DTO.Users
{
    public class UserDto
    {
        public string id { get; set; }
        public string userName { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string roleId { get; set; }
        public string phone { get; set; }

        public DateTime createdDate { get; set; }
        public List<ResponsePermissionAllDto> Permissions { get; set; } = new List<ResponsePermissionAllDto>();




    }
}

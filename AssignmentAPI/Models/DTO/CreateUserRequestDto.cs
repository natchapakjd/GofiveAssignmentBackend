using AssignmentAPI.Models.Domain;

namespace AssignmentAPI.Models.DTO
{
    public class CreateUserRequestDto
    {
        public string id { get; set; }
        public string userName { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string email { get; set; }
        public string password { get; set; }

        public string[] Permissions { get; set; }
        public string roleId { get; set; }

        public string phone { get; set; }

    }
}

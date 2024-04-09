namespace AssignmentAPI.Models.DTO
{
    public class UpdateUserRequestDto
    {
        public string id { get; set; }
        public string userName { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string email { get; set; }
        public string password { get; set; }

        public List<string> Permissions { get; set; } = new List<string>();
        public string roleId { get; set; }

        public string phone { get; set; }
    }
}

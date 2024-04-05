namespace AssignmentAPI.Models.DTO
{
    public class UpdateUserRequestDto
    {
        public string userName { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string email { get; set; }
        public string password { get; set; }

        public string phone { get; set; }

    }
}

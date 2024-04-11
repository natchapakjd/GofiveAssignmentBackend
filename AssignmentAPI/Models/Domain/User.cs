namespace AssignmentAPI.Models.Domain
{
    public class User
    {
        public string id { get; set; }
        public string userName { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string phone { get; set; }
        public string roleId { get; set; }
        public Role Role { get; set; }
        public DateTime createdDate { get; set; }
        public ICollection<Permission> Permissions { get; set; } 
    }
}

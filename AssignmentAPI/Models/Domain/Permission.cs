namespace AssignmentAPI.Models.Domain
{
    public class Permission
    {
        public string permissionId { get; set; }
        public string? permissionName { get; set; }
        public bool? isReadable { get; set; }
        public bool? isWritable { get; set; }
        public bool? isDeletable { get; set; }
        public ICollection<User> Users { get; set; }

    }
}

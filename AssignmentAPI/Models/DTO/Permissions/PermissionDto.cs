namespace AssignmentAPI.Models.DTO.Permissions
{
    public class PermissionDto
    {
        public string permissionId { get; set; } = string.Empty;
        public string permissionName { get; set; } = string.Empty;

        public bool? isReadable { get; set; }
        public bool? isWritable { get; set; }
        public bool? isDeletable { get; set; }
    }
}

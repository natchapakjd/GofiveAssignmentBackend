namespace AssignmentAPI.Models.DTO.Permissions
{
    public class ResponsePermissionAllDto
    {
        public string permissionId { get; set; } = string.Empty;
        public bool? isReadable { get; set; }
        public bool? isWritable { get; set; }
        public bool? isDeletable { get; set; }
    }
}

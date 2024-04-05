namespace AssignmentAPI.Repositories.Interface
{
    public interface IRoleRepository
    {
        Task<IEnumerable<Role>> GetAllAsync();

    }
}

namespace SiteLanches.Services
{
    public interface ISeedUserRoleInitial
    {

        void SeedRoles();
        void SeedUsers();

        Task SeedRolesAsync();

    }
}

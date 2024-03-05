using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks; // Don't forget to include this namespace

namespace SiteLanches.Services
{
    public class SeedUserRoleInitial : ISeedUserRoleInitial
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager; // Corrected variable name

        public SeedUserRoleInitial(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        // Explicit interface implementation

        /*
        async Task ISeedUserRoleInitial.SeedRolesAsync()
        {
            if (!await _roleManager.RoleExistsAsync("Member"))
            {
                var role = new IdentityRole("Member");
                IdentityResult roleResult = await _roleManager.CreateAsync(role);
                if (!roleResult.Succeeded)
                {
                    role.Name = "Member";
                    role.NormalizedName = "MEMBER";
                    // Handle role creation failure
                }
            }

            if (!await _roleManager.RoleExistsAsync("Admin"))
            {
                var role = new IdentityRole("Admin");
                IdentityResult roleResult = await _roleManager.CreateAsync(role);
                if (!roleResult.Succeeded)
                {
                    role.Name = "Admin";
                    role.NormalizedName = "ADMIN";
                }
            }
        }*/

        public void SeedRoles()
        {
            if (!_roleManager.RoleExistsAsync("Member").Result)
            {
                IdentityRole role = new IdentityRole();
                role.Name = "Member";
                role.NormalizedName = "MEMBER";
                IdentityResult roleResult = _roleManager.CreateAsync(role).Result;

            }

            if (!_roleManager.RoleExistsAsync("Admin").Result)
            {
                IdentityRole role = new IdentityRole();
                role.Name = "Admin";
                role.NormalizedName = "ADMIN";
                IdentityResult roleResult = _roleManager.CreateAsync(role).Result;

            }
        }
        


        public async Task SeedRolesAsync()
        {
            if (!await _roleManager.RoleExistsAsync("Member"))
            {
                var role = new IdentityRole("Member");
                IdentityResult roleResult = await _roleManager.CreateAsync(role);
                if (!roleResult.Succeeded)
                {
                    role.Name = "Member";
                    role.NormalizedName = "MEMBER";
                    // Handle role creation failure
                }
            }

            if (!await _roleManager.RoleExistsAsync("Admin"))
            {
                var role = new IdentityRole("Admin");
                IdentityResult roleResult = await _roleManager.CreateAsync(role);
                if (!roleResult.Succeeded)
                {
                    role.Name = "Admin";
                    role.NormalizedName = "ADMIN"; role.Name = "Admin";
                    role.NormalizedName = "ADMIN";
                }
            }
        }
        public void SeedUsers()
        {
            if (_userManager.FindByEmailAsync("usuario@localhost").Result == null)
            {
                IdentityUser user = new IdentityUser();
                user.UserName = "usuario@localhost";
                user.Email = "usuario@localhost";
                user.NormalizedUserName = "USUARIO@LOCALHOST";
                user.NormalizedEmail = "USUARIO@LOCALHOST";
                user.EmailConfirmed = true;
                user.LockoutEnabled = false;
                user.SecurityStamp = Guid.NewGuid().ToString();

                IdentityResult result = _userManager.CreateAsync(user, "Numsay#2022").Result;

                if (result.Succeeded)
                {

                    _userManager.AddToRoleAsync(user, "Member").Wait();
                }

            }

            if (_userManager.FindByEmailAsync("admin@localhost").Result == null)
            {
                IdentityUser user = new IdentityUser();
                user.UserName = "admin@localhost";
                user.Email = "admin@localhost";
                user.NormalizedUserName = "ADMIN@LOCALHOST";
                user.NormalizedEmail = "ADMIN@LOCALHOST";
                user.EmailConfirmed = true;
                user.LockoutEnabled = false;
                user.SecurityStamp = Guid.NewGuid().ToString();

                IdentityResult result = _userManager.CreateAsync(user, "Numsay#2022").Result;

                if (result.Succeeded)
                {

                    _userManager.AddToRoleAsync(user, "Admin").Wait();
                }

            }


            

        }
    }
}

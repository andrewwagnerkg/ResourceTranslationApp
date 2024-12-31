using System.Security.Claims;
using Core.Entities.Identity;
using Infrastructure.Enums;
using Microsoft.AspNetCore.Identity;

namespace Persistence.Seeders
{
    public class ClaimsSeeder : ISeeder
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<Role> _roleManager;

        public ClaimsSeeder(UserManager<User> userManager, RoleManager<Role> roleManager)
        {
            _userManager = userManager ?? throw new ArgumentException(nameof(userManager));
            _roleManager = roleManager ?? throw new ArgumentException(nameof(roleManager));
        }

        public async Task Seed()
        {
            var user = await _userManager.FindByNameAsync(Roles.SA.ToString());
            if (user == null) throw new Exception("User not created");
            if ((await _userManager.GetClaimsAsync(user)).Any()) return;
            await _userManager.AddClaimAsync(user, new Claim(nameof(user.UserName), user.UserName));
            await _userManager.AddClaimAsync(user, new Claim("Role", Roles.SA.ToString()));
            await _userManager.AddClaimAsync(user, new Claim(nameof(user.Email), user.Email));
        }
    }
}

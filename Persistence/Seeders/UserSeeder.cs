using System.Collections.Specialized;
using System.Security.Claims;
using Core.Entities.Identity;
using Infrastructure.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Persistence.Seeders
{
    public class UserSeeder : ISeeder
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<Role> _roleManager;
        private readonly IConfiguration _configuration;

        public UserSeeder(UserManager<User> userManager, RoleManager<Role> roleManager, IConfiguration configuration)
        {
            _userManager = userManager ?? throw new ArgumentException(nameof(userManager));
            _roleManager = roleManager ?? throw new ArgumentException(nameof(roleManager));
            _configuration = configuration ?? throw new ArgumentException(nameof(configuration));
        }

        public async Task Seed()
        {
            var sa = new User
            {
                Email = "sa@resources.com",
                EmailConfirmed = true,
                NormalizedEmail = "sa@resources.com".Normalize(),
                UserName = Roles.SA.ToString(),
                NormalizedUserName = Roles.SA.ToString().Normalize(),
                SecurityStamp = DateTime.UtcNow.ToString(),
            };
            var saPassword = _configuration.GetRequiredSection("SAPassword").Value;
            if (string.IsNullOrEmpty(saPassword)) throw new ArgumentNullException("SAPassword");
            var loginClaim = new Claim("UserName", Roles.SA.ToString());
            var userRoleClaim = new Claim(ClaimTypes.Role, Roles.SA.ToString());
            if (await _userManager.Users.AnyAsync(x => x.UserName == Roles.SA.ToString())) return;
            var superAdminRole = await _roleManager.FindByNameAsync(Roles.SA.ToString());
            await _userManager.CreateAsync(sa, saPassword);
            await _userManager.SetLockoutEnabledAsync(sa, false);
            await _userManager.AddToRoleAsync(sa, superAdminRole.Name);
        }
    }
}

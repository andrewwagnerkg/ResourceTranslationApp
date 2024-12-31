using Core.Entities.Identity;
using Infrastructure.Enums;
using Infrastructure.Extensions;
using Microsoft.AspNetCore.Identity;

namespace Persistence.Seeders
{
    public class RolesSeeder : ISeeder
    {
        private readonly RoleManager<Role> _roleManager;

        public RolesSeeder(RoleManager<Role> roleManager)
        {
            _roleManager = roleManager ?? throw new ArgumentException(nameof(roleManager));
        }

        public async Task Seed()
        {
            foreach (var item in EnumExtensions.ToEnumerable<Roles>())
            {
                await CreateIfNotExists(new Role { Name = item.ToString(), NormalizedName = item.ToString().Normalize() });
            }
        }

        private async Task CreateIfNotExists(Role role)
        {
            if (role == null) throw new ArgumentNullException(nameof(role));
            if (role.NormalizedName == null) throw new ArgumentNullException(nameof(role.NormalizedName));

            if (await _roleManager.RoleExistsAsync(role.NormalizedName ?? string.Empty)) return;
            await _roleManager.CreateAsync(role);
        }
    }
}

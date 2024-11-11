using Application.Exceptions;
using Application.Interfaces;
using Core.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Application.Services
{
    public class JWTAuthService : IJWTAuthService
    {
        private readonly IJWTService _jwtService;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<Role> _roleManager;

        public JWTAuthService(IJWTService jwtService, UserManager<User> userManager, RoleManager<Role> roleManager)
        {
            _jwtService = jwtService;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<string> Authentiticate(string username, string password)
        {
            var user = await GetUserByNameAsync(username, password);
            VerifyPassword(username, password, user);
            return _jwtService.GetTokenString(await _userManager.GetClaimsAsync(user));
        }

        private static void VerifyPassword(string username, string password, User? user)
        {
            PasswordHasher<User> haser = new();
            var verificationResult = haser.VerifyHashedPassword(user, user.PasswordHash, password);
            if (verificationResult == PasswordVerificationResult.Failed) throw new UserNotFoundException(username);
        }

        private async Task<User?> GetUserByNameAsync(string username, string password)
        {
            var user = await _userManager.Users.FirstOrDefaultAsync(x => x.UserName == username);
            if (user == null) throw new UserNotFoundException(username);
            return user;
        }
    }
}

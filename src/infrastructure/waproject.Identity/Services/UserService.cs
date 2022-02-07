using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

using System.IdentityModel.Tokens.Jwt;
using System.Text;

using waproject.Application.Common.Interfaces;
using waproject.Application.Dtos.Users;
using waproject.Application.Users.Commands;
using waproject.Identity.Helpers;

using SignInResult = Microsoft.AspNetCore.Identity.SignInResult;

namespace waproject.Identity.Services
{
    public class UserService : IUserService
    {
        private readonly AuthSettings _authSettings;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;

        public UserService(IOptions<AuthSettings> authSettings, SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager)
        {
            _authSettings = authSettings.Value;
            _signInManager = signInManager;
            _userManager = userManager;
        }

        public async Task<AuthenticateResponse> Authenticate(AuthenticateUserCommand request)
        {
            IdentityUser user = await _userManager.FindByEmailAsync(request.Email);

            if (user == null)
                return null!;

            SignInResult result = await _signInManager.CheckPasswordSignInAsync(user, request.Password, true);
            if (result.Succeeded)
                return new AuthenticateResponse(await GenerateJwtToken(user));

            return null!;
        }

        private async Task<string> GenerateJwtToken(IdentityUser user)
        {
            SecurityTokenDescriptor descriptor = new SecurityTokenDescriptor
            {
                Subject = (await _signInManager.CreateUserPrincipalAsync(user))
                        .Identities.First(),
                Expires = DateTime.Now.AddMinutes(_authSettings.ExpiryMinutes),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_authSettings.Secret)),
                    SecurityAlgorithms.HmacSha256Signature)
            };
            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
            SecurityToken securityToken = new JwtSecurityTokenHandler()
                .CreateToken(descriptor);

            return handler.WriteToken(securityToken);
        }
    }
}

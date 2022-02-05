using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

using System.IdentityModel.Tokens.Jwt;
using System.Text;

using SignInResult = Microsoft.AspNetCore.Identity.SignInResult;

namespace waproject.WebApi.Controllers
{
    public class AuthController : ApiController
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IConfiguration _config;

        public AuthController(SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager, IConfiguration config)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _config = config;
        }

        [HttpPost("signin")]
        public async Task<object> AuthSignIn([FromBody] SignInCredentials credentials)
        {
            IdentityUser user = await _userManager.FindByEmailAsync(credentials.Email);

            if (user == null)
                return NotFound();

            SignInResult result = await _signInManager.CheckPasswordSignInAsync(user, credentials.Password, true);
            if (result.Succeeded)
            {
                SecurityTokenDescriptor descriptor = new SecurityTokenDescriptor
                {
                    Subject = (await _signInManager.CreateUserPrincipalAsync(user))
                        .Identities.First(),
                    Expires = DateTime.Now.AddMinutes(int.Parse(_config["BearerTokens:ExpiryMins"])),
                    SigningCredentials = new SigningCredentials(
                        new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["BearerTokens:Key"])),
                        SecurityAlgorithms.HmacSha256Signature)
                };
                JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
                SecurityToken securityToken = new JwtSecurityTokenHandler()
                    .CreateToken(descriptor);
                return new { success = true, token = handler.WriteToken(securityToken) };
            }
            return new { success = false };
        }
    }

    public class SignInCredentials
    {
        public string Email { get; set; } = default!;
        public string Password { get; set; } = default!;
    }
}

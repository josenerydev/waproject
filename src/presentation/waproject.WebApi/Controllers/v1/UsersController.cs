using Microsoft.AspNetCore.Mvc;

using waproject.Application.Common.Interfaces;
using waproject.Application.Dtos.User;

namespace waproject.WebApi.Controllers.v1
{
    public class UsersController : ApiController
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService) => _userService = userService;

        [HttpPost("auth")]
        public async Task<IActionResult> Authenticate(AuthenticateRequest request)
        {
            var response = await _userService.Authenticate(request);

            if (response == null)
                return BadRequest(new { message = "Email or password is incorrect" });

            return Ok(response);
        }
    }
}

using Microsoft.AspNetCore.Mvc;

using waproject.Application.Users.Commands;

namespace waproject.WebApi.Controllers.v1
{
    public class UsersController : ApiController
    {
        [HttpPost("auth")]
        public async Task<IActionResult> Authenticate([FromBody] AuthenticateUserCommand command)
        {
            var response = await Mediator.Send(command);

            if (response == null)
                return BadRequest(new { message = "Email or password is incorrect" });

            return Ok(response);
        }
    }
}

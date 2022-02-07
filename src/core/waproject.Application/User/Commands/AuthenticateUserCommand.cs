using MediatR;

using waproject.Application.Common.Interfaces;
using waproject.Application.Dtos.Users;

namespace waproject.Application.User.Commands
{
    public class AuthenticateUserCommand : IRequest<AuthenticateDto>
    {
        public string Email { get; set; } = default!;
        public string Password { get; set; } = default!;
    }

    public class AuthenticateUserCommandHandler : IRequestHandler<AuthenticateUserCommand, AuthenticateDto>
    {
        private readonly IUserService _userService;
        public AuthenticateUserCommandHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<AuthenticateDto> Handle(AuthenticateUserCommand request, CancellationToken cancellationToken)
        {
            return await _userService.Authenticate(request);
        }
    }
}

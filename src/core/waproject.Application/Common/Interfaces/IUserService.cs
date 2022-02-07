using waproject.Application.Dtos.Users;
using waproject.Application.User.Commands;

namespace waproject.Application.Common.Interfaces
{
    public interface IUserService
    {
        Task<AuthenticateDto> Authenticate(AuthenticateUserCommand request);
    }
}

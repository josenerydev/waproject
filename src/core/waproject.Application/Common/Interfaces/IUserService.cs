using waproject.Application.Dtos.Users;
using waproject.Application.Users.Commands;

namespace waproject.Application.Common.Interfaces
{
    public interface IUserService
    {
        Task<AuthenticateResponse> Authenticate(AuthenticateUserCommand request);
    }
}

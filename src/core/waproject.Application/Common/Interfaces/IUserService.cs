using waproject.Application.Dtos.User;

namespace waproject.Application.Common.Interfaces
{
    public interface IUserService
    {
        Task<AuthenticateResponse> Authenticate(AuthenticateRequest request);
    }
}

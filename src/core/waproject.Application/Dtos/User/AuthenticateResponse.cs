namespace waproject.Application.Dtos.User
{
    public class AuthenticateResponse
    {
        public string Token { get; }

        public AuthenticateResponse(string token)
        {
            Token = token;
        }
    }
}

namespace waproject.Application.Dtos.Users
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

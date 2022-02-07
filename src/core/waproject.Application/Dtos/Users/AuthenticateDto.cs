namespace waproject.Application.Dtos.Users
{
    public class AuthenticateDto
    {
        public string Token { get; }

        public AuthenticateDto(string token)
        {
            Token = token;
        }
    }
}

namespace waproject.Application.Dtos.User
{
    public class AuthenticateRequest
    {
        public string Email { get; set; } = default!;
        public string Password { get; set; } = default!;
    }
}

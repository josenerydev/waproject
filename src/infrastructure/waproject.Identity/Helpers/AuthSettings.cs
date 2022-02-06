namespace waproject.Identity.Helpers
{
    public class AuthSettings
    {
        public int ExpiryMinutes { get; set; }
        public string Secret { get; set; } = default!;
    }
}

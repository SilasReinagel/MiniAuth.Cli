
namespace MiniAuth.Cli.Auth
{
    public sealed class AppLoginResponse
    {
        public string ExpiresAtUtc { get; set; }
        public string Token { get; set; }
    }
}

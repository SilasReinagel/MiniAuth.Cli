
namespace MiniAuth.Cli
{
    public sealed class AppLoginRequest
    {
        public string AppName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public AppLoginResponse GetResponse()
        {
            return new JsonPostRequest<AppLoginResponse>($"https://miniauth.azurewebsites.net/api/account/applogin", this).GetResponse();
        }
    }
}

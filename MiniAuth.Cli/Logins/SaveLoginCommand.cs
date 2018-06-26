using MiniAuth.Cli.Common;

namespace MiniAuth.Cli.Logins
{
    public sealed class SaveLoginCommand : ICliCommand
    {
        public string Name => "save";
        public string HelpText => "usage: save username password";

        public void Execute(string[] args)
        {
            var username = args[0];
            var password = args[1];

            new AppDataIo("MiniAuth")
                .Put("login", new Login(username, password).ToString());       
        }
    }
}

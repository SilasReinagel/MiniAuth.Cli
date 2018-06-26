using System;

namespace MiniAuth.Cli
{
    public sealed class AppLoginCommand : ICliCommand
    {
        public string Name => "login";
        public string HelpText => "usage: login appname [username] [password]";

        public void Execute(string[] args)
        {
            var req = new AppLoginRequest { AppName = args[0], Username = args[1], Password = args[2] };
            var token = req.GetResponse().Token;
            Clipboard.Copy(token);
            Console.WriteLine(token);
        }
    }
}

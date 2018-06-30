using MiniAuth.Cli.Common;

namespace MiniAuth.Cli.Auth
{
    public sealed class AppLoginCommand : ICliCommand
    {
        private readonly IConsumer<string> _output;

        public string Name => "login";
        public string HelpText => "usage: login appname [username] [password]";

        public AppLoginCommand() : this(Output.Current) { }
        public AppLoginCommand(IConsumer<string> output) => _output = output;

        public void Execute(string[] args)
        {
            var req = new AppLoginRequest { AppName = args[0], Username = args[1], Password = args[2] };
            var token = req.GetResponse().Token;
            _output.Put($"Bearer {token}");
        }
    }
}

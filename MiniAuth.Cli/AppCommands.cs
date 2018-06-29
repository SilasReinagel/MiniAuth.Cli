using MiniAuth.Cli.Common;
using MiniAuth.Cli.Logins;

namespace MiniAuth.Cli
{
    public sealed class AppCommands : ICliCommands
    {
        private readonly ICliCommands _allAppcommands;

        public AppCommands() : this(new AppLoginCommand(), new SaveLoginCommand()) { }
        public AppCommands(IConsumer<string> output, IO io) : this(new AppLoginCommand(output), new SaveLoginCommand(io)) { }
        public AppCommands(AppLoginCommand appLogin, SaveLoginCommand saveLogin) : this(new ICliCommand[] { appLogin, saveLogin }) { }
        private AppCommands(params ICliCommand[] commands) => _allAppcommands = new CliCommands(commands);

        public void Execute(string name, params string[] args) => _allAppcommands.Execute(name, args);
    }
}

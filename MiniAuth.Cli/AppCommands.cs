using MiniAuth.Cli.Auth;
using MiniAuth.Cli.Common;
using MiniAuth.Cli.Logins;

namespace MiniAuth.Cli
{
    public sealed class AppCommands : ICliCommands
    {
        private readonly ICliCommands _allCommands;

        public AppCommands() 
            : this(Output.Current, new UsingStoredLogin(new AppDataIo("MiniAuth"), new AppLoginCommand()), new SaveLoginCommand()) { }

        public AppCommands(IConsumer<string> output, IO io) 
            : this(output, new UsingStoredLogin(io, new AppLoginCommand(output)), new SaveLoginCommand(io)) { }

        private AppCommands(IConsumer<string> output, params ICliCommand[] commands) 
            => _allCommands = new CommandsWithHelp(output, commands);

        public void Execute(string name, params string[] args) => _allCommands.Execute(name, args);
    }
}

using MiniAuth.Cli.Logins;

namespace MiniAuth.Cli
{
    public sealed class AppCommands : ICliCommands
    {
        private readonly ICliCommands _allAppcommands;

        public AppCommands() => _allAppcommands = new Commands(new AppLoginCommand(),new SaveLoginCommand());

        public void Execute(string name, string[] args) => _allAppcommands.Execute(name, args);
    }
}

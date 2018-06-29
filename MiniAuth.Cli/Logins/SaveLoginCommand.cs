using MiniAuth.Cli.Common;

namespace MiniAuth.Cli.Logins
{
    public sealed class SaveLoginCommand : ICliCommand
    {
        private readonly IO _io;

        public string Name => "save";
        public string HelpText => "usage: save username password";

        public SaveLoginCommand() : this(new AppDataIo("MiniAuth")) { }
        public SaveLoginCommand(IO io) => _io = io;

        public void Execute(string[] args)
        {
            var username = args[0];
            var password = args[1];

            _io.Put("login", new Login(username, password).ToString());


        }
    }
}

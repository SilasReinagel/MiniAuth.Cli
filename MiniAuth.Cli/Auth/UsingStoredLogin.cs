using MiniAuth.Cli.Common;
using MiniAuth.Cli.Logins;

namespace MiniAuth.Cli.Auth
{
    public sealed class UsingStoredLogin : ICliCommand
    {
        private readonly IO _io;
        private readonly AppLoginCommand _inner;

        public string Name => _inner.Name;
        public string HelpText => _inner.HelpText;
        
        public UsingStoredLogin(IO io, AppLoginCommand command)
        {
            _io = io;
            _inner = command;
        }

        public void Execute(string[] args)
        {
            var supplementedArgs = (args.Length < 3 && _io.Exists("login"))
                ? WithStoredLogin(args)
                : args;            
            _inner.Execute(supplementedArgs);
        }

        private string[] WithStoredLogin(string[] args)
        {
            var login = new Login(_io.ReadText("login"));
            return new string[] { args[0], login.Username, login.Password };
        }
    }
}

using System;
using System.Linq;

namespace MiniAuth.Cli.Common
{
    public sealed class CommandsWithHelp : ICliCommand, ICliCommands
    {
        private readonly string _fullHelpText;
        private readonly ICliCommands _inner;
        private readonly IConsumer<string> _output;

        public string Name => "help";
        public string HelpText => "usage: help";

        public CommandsWithHelp(IConsumer<string> output, params ICliCommand[] commands)
        {
            var all = commands.Append(this).OrderBy(x => x.Name).ToArray();
            _fullHelpText = $"Commands: {Environment.NewLine}" + string.Join(Environment.NewLine, all.Select(x => new CliCommandHelpText(x)));
            _inner = new CliCommands(all);
            _output = output;
        }

        public void Execute(string[] args) => _output.Put(_fullHelpText);

        public void Execute(string name, string[] args) => _inner.Execute(name, args);
    }
}

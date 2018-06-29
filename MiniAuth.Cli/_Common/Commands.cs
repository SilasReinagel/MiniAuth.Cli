using System;
using System.Collections.Generic;
using System.Linq;

namespace MiniAuth.Cli
{
    public sealed class Commands : ICliCommands
    {
        private readonly Dictionary<string, Action<string[]>> _commands;

        public Commands(params ICliCommand[] commands)
            : this ((IEnumerable<ICliCommand>)commands) {}
        
        public Commands(IEnumerable<ICliCommand> commands)
            : this(commands.ToDictionary(x => x.Name.ToLowerInvariant(), k => (Action<string[]>)(k.Execute))) {}
        
        public Commands(Dictionary<string, Action<string[]>> commands)
        {
            _commands = commands;
        }

        public void Execute(string name, string[] args)
        {
            if (!_commands.ContainsKey(name))
                throw new KeyNotFoundException($"Unknown command '{name}'");
            _commands[name](args);
        }
    }
}

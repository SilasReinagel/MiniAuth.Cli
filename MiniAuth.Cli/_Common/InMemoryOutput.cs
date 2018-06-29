using System.Collections.Generic;

namespace MiniAuth.Cli.Common
{
    public sealed class InMemoryOutput : IConsumer<string>
    {
        public List<string> Outputs { get; } = new List<string>();

        public void Put(string value) => Outputs.Add(value);
    }
}

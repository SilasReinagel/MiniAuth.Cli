using System;
using System.Collections.Generic;

namespace MiniAuth.Cli.Common
{
    public sealed class InMemoryIo : IO
    {
        public Dictionary<string, byte[]> Files { get; } = new Dictionary<string, byte[]>(StringComparer.InvariantCultureIgnoreCase);

        public byte[] Get(string name)
        {
            return Files[name];
        }

        public void Put(string name, byte[] bytes)
        {
            Files[name] = bytes;
        }
    }
}

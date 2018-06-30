using System;
using System.Collections.Generic;

namespace MiniAuth.Cli.Common
{
    public sealed class InMemoryIo : IO
    {
        public Dictionary<string, byte[]> Files { get; } = new Dictionary<string, byte[]>(StringComparer.InvariantCultureIgnoreCase);

        public bool Exists(string name)
        {
            return Files.ContainsKey(name);
        }

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

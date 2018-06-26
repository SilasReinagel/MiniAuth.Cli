using System;

namespace MiniAuth.Cli
{
    public sealed class ConsoleOutput : IConsumer<string>
    {
        public void Put(string value) => Console.WriteLine(value);
    }
}

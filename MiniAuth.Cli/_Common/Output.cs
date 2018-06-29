
namespace MiniAuth.Cli.Common
{
    public static class Output
    {
        private static IConsumer<string> _out = new MultiConsumer<string>(new ClipboardOutput(), new ConsoleOutput());

        public static IConsumer<string> Current => _out;
        public static void Init(IConsumer<string> output) => _out = output;
        public static void Put(string value) => _out.Put(value);
    }
}

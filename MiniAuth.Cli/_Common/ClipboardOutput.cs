namespace MiniAuth.Cli
{
    public sealed class ClipboardOutput : IConsumer<string>
    {
        public void Put(string value) => Clipboard.Copy(value);
    }
}

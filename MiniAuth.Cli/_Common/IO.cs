
namespace MiniAuth.Cli.Common
{
    public interface IO
    {
        void Put(string name, byte[] bytes);
        byte[] Get(string name);
    }
}

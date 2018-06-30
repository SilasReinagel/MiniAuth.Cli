
namespace MiniAuth.Cli.Common
{
    public interface IO
    {
        bool Exists(string name);
        void Put(string name, byte[] bytes);
        byte[] Get(string name);
    }
}

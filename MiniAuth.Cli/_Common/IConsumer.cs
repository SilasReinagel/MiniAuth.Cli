namespace MiniAuth.Cli
{
    public interface IConsumer<in T>
    {
        void Put(T value);
    }
}

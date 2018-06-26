using System;

namespace MiniAuth.Cli
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                new AppCommands().Execute(args);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error: {e.Message}");
            }
        }
    }
}

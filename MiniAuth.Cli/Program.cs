using System;

namespace MiniAuth.Cli
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var req = new AppLoginRequest { AppName = args[0], Username = args[1], Password = args[2] };
                var token = req.GetResponse().Token;
                Clipboard.Copy(token);
                Console.WriteLine(token);
            }
            catch(Exception e)
            {
                Console.WriteLine($"Error: {e.Message}");
            }
        }
    }
}

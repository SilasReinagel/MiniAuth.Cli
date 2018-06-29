using System;
using System.IO;
using System.Text;

namespace MiniAuth.Cli.Common
{
    public sealed class AppDataIo : IO
    {
        private readonly string _appDataFolder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        private readonly string _appName;
        private string DirName => Path.Combine(_appDataFolder, _appName);

        public AppDataIo(string appName)
        {
            _appName = appName;
        }

        public void Put(string name, byte[] bytes)
        {
            if (!Directory.Exists(DirName))
                Directory.CreateDirectory(DirName);
            File.WriteAllBytes(GetPath(name), bytes);
        }

        public byte[] Get(string name) => File.ReadAllBytes(GetPath(name));

        private string GetPath(string name) => Path.Combine(DirName, $"{name}.io");
    }

    public static class IoExtensions
    {
        public static void Put(this IO io, string name, string value) => io.Put(name, Encoding.UTF8.GetBytes(value));
        public static string ReadText(this IO io, string name) => Encoding.UTF8.GetString(io.Get(name));
    }
}

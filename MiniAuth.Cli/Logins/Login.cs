namespace MiniAuth.Cli.Logins
{
    public sealed class Login
    {
        private const string _separator = "╬";
        
        public string Username { get; set; }
        public string Password { get; set; }

        public Login(string login)
            : this(login.Split(_separator)[0], login.Split(_separator)[1]) { }
        
        public Login(string username, string password)
        {
            Username = username;
            Password = password;
        }

        public override string ToString()
        {
            return $"{Username}{_separator}{Password}";
        }
    }
}

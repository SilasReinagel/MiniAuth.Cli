using Microsoft.VisualStudio.TestTools.UnitTesting;
using MiniAuth.Cli.Common;
using System.Linq;

namespace MiniAuth.Cli.Tests
{
    [TestClass]
    public class AppCommandsTests
    {

        private readonly InMemoryOutput _console;
        private readonly InMemoryIo _io;
        private readonly AppCommands _commands;

        public AppCommandsTests()
        {
            _console = new InMemoryOutput();
            _io = new InMemoryIo();
            _commands = new AppCommands(_console, _io);
        }

        [TestMethod]
        public void AppCommands_Login_CanLogin()
        {
            const int MinimumReasonableJwtLength = 80;

            Execute("login TestApp integrationtest 123");

            var output = _console.Outputs.Single();
            Assert.IsTrue(output.Contains("Bearer"));
            Assert.IsTrue(output.Length > MinimumReasonableJwtLength);
        }

        [TestMethod]
        public void AppCommands_Save_LoginSaved()
        {
            Execute("save integrationtest 123");

            Assert.IsTrue(_io.Files.ContainsKey("login"));
        }

        private void Execute(string rawText)
        {
            _commands.Execute(rawText.Split(' '));
        }
    }
}

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
            Execute("login TestApp integrationtest 123");

            AssertLoginSucceeded();
        }

        [TestMethod]
        public void AppCommands_Save_LoginSaved()
        {
            Execute("save integrationtest 123");

            Assert.IsTrue(_io.Files.ContainsKey("login"));
        }

        [TestMethod]
        public void AppCommands_LoginUsingStoredLogin_CanLogin()
        {
            Execute("save integrationtest 123");

            Execute("login TestApp");

            AssertLoginSucceeded();
        }

        [TestMethod]
        public void AppCommands_Help_HelpTextDisplayed()
        {
            Execute("help");

            var output = _console.Outputs.Single();
            Assert.IsTrue(output.Contains("login"));
            Assert.IsTrue(output.Contains("help"));
            Assert.IsTrue(output.Contains("save"));
        }

        private void AssertLoginSucceeded()
        {
            const int MinimumReasonableJwtLength = 80;

            var output = _console.Outputs.Single();
            Assert.IsTrue(output.Contains("Bearer"));
            Assert.IsTrue(output.Length > MinimumReasonableJwtLength);
        }

        private void Execute(string rawText)
        {
            _commands.Execute(rawText.Split(' '));
        }
    }
}

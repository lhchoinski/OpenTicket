using NUnit.Framework;
using OpenTicket.Infra.Test.AppConfigurations.Base;
using OpenTicket.Domain.Commands.Input.Employee;
using OpenTicket.Infra.Test.AppConfigurations.Settings;

namespace OpenTicket.Domain.Test.Commands.Input.Employee
{
    public class DeleteEmployeeCommandTest : BaseTest
    {
        private DeleteEmployeeCommand command;

        [SetUp]
        public void Setup() => command = new MockDadosTest().DeleteEmployeeCommand;

        [Test]
        public void ValidateDeleteCommand_Valid()
        {
            var valido = command.EhValido();
            var notificacoes = command.Notifications.Count;

            Assert.True(valido);
            Assert.AreEqual(0, notificacoes);
        }

        [Test]
        [TestCase(0)]
        [TestCase(-1)]
        public void ValidateDeleteCommand_IdInValid(int Id)
        {
            //arrange
            command.Id = Id;

            //act
            var valido = command.EhValido();
            var notificacoes = command.Notifications.Count;

            //assert
            Assert.IsFalse(valido);
            Assert.AreNotEqual(0, notificacoes);
        }

        [TearDown]
        public void TearDown() => command = null;
    }
}

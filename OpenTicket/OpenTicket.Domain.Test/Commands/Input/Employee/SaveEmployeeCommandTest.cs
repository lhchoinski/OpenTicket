using NUnit.Framework;
using Hotelaria.Domain.Enums;
using Hotelaria.Domain.Commands.Input.Funcionario;
using Hotelaria.Infra.Test.AppConfigurations.Settings;

namespace Hotelaria.Domain.Test.Commands.Input.Funcionario
{
    public class SalvarFuncionarioCommandTest
    {
        private SalvarFuncionarioCommand command;

        [SetUp]
        public void Setup() => command = new MockDadosTest().SalvarFuncionarioCommand;

        [Test]
        public void ValidarSalvarCommand_Valido()
        {
            var valido = command.EhValido();
            var notificacoes = command.Notifications.Count;

            Assert.True(valido);
            Assert.AreEqual(0, notificacoes);
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void ValidarSalvarCommand_NomeInvalido(string nome)
        {
            //arrange
            command.Nome = nome;

            //act
            var valido = command.EhValido();
            var notificacoes = command.Notifications.Count;

            //assert
            Assert.IsFalse(valido);
            Assert.AreNotEqual(0, notificacoes);
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void ValidarSalvarCommand_EmailInvalido(string email)
        {
            //arrange
            command.Email = email;

            //act
            var valido = command.EhValido();
            var notificacoes = command.Notifications.Count;

            //assert
            Assert.IsFalse(valido);
            Assert.AreNotEqual(0, notificacoes);
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void ValidarSalvarCommand_RGInvalido(string rg)
        {
            //arrange
            command.RG = rg;

            //act
            var valido = command.EhValido();
            var notificacoes = command.Notifications.Count;

            //assert
            Assert.IsFalse(valido);
            Assert.AreNotEqual(0, notificacoes);
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void ValidarSalvarCommand_TelefoneInvalido(string telefone)
        {
            //arrange
            command.Telefone = telefone;

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

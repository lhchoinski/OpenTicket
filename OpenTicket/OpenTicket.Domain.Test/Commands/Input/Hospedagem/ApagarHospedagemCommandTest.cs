using NUnit.Framework;
using Hotelaria.Domain.Commands.Input.Hospedagem;
using Hotelaria.Infra.Test.AppConfigurations.Base;
using Hotelaria.Infra.Test.AppConfigurations.Settings;

namespace Hotelaria.Domain.Test.Commands.Input.Hospedagem
{
    class ApagarHospedagemCommandTest : BaseTest
    {
        private ApagarHospedagemCommand command;

        [SetUp]
        public void Setup() => command = new MockDadosTest().ApagarHospedagemCommand;

        [Test]
        public void ValidarApagarCommand_Valido()
        {
            var valido = command.EhValido();
            var notificacoes = command.Notifications.Count;

            Assert.True(valido);
            Assert.AreEqual(0, notificacoes);
        }

        [Test]
        [TestCase(0)]
        [TestCase(-1)]
        public void ValidarApagarCommand_IdInvalido(int Id)
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

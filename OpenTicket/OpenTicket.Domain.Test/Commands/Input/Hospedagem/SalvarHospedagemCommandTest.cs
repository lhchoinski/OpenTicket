using System;
using NUnit.Framework;
using Hotelaria.Domain.Commands.Input.Hospedagem;
using Hotelaria.Infra.Test.AppConfigurations.Base;
using Hotelaria.Infra.Test.AppConfigurations.Settings;

namespace Hotelaria.Domain.Test.Commands.Input.Hospedagem
{
    class SalvarHospedagemCommandTest : BaseTest
    {
        private SalvarHospedagemCommand command;

        [SetUp]
        public void Setup() => command = new MockDadosTest().SalvarHospedagemCommand;

        [Test]
        public void ValidarSalvarCommand_Valido()
        {
            var valido = command.EhValido();
            var notificacoes = command.Notifications.Count;

            Assert.True(valido);
            Assert.AreEqual(0, notificacoes);
        }

        [Test]
        [TestCase(0)]
        [TestCase(-1)]
        public void ValidarSalvarCommand_HospedeIdInvalido(int hospedeId)
        {
            //arrange
            command.HospedeId = hospedeId;

            //act
            var valido = command.EhValido();
            var notificacoes = command.Notifications.Count;

            //assert
            Assert.IsFalse(valido);
            Assert.AreNotEqual(0, notificacoes);
        }

        [Test]
        [TestCase(0)]
        [TestCase(-1)]
        public void ValidarSalvarCommand_QuartoIdInvalido(int quartoId)
        {
            //arrange
            command.QuartoId = quartoId;

            //act
            var valido = command.EhValido();
            var notificacoes = command.Notifications.Count;

            //assert
            Assert.IsFalse(valido);
            Assert.AreNotEqual(0, notificacoes);
        }

        [Test]
        public void ValidarSalvarCommand_DataInvalido()
        {
            //arrange
            command.DataSaida = DateTime.Now;
            command.DataEntrada = DateTime.Now.AddDays(10);

            //act
            var valido = command.EhValido();
            var notificacoes = command.Notifications.Count;

            //assert
            Assert.IsFalse(valido);
            Assert.AreNotEqual(0, notificacoes);
        }

        [Test]
        [TestCase(0)]
        [TestCase(-1)]
        public void ValidarSalvarrCommand_ValorHospedagemInvalido(double valorHospedagem)
        {
            //arrange
            command.ValorHospedagem = valorHospedagem;

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

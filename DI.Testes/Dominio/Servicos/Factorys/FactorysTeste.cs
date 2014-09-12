using System;
using DI.Dominio.Entidades;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace DI.Testes.Dominio.Servicos.Factorys
{
    using DI.Dominio.Servicos.ProcessamentoDeDocumentos;
    using DI.Dominio.Servicos.ProcessamentoDeDocumentos.Fabricas;
    using DI.Dominio.Servicos.ProcessamentoDeDocumentos.Notificadores;
    using DI.Dominio.Servicos.ProcessamentoDeDocumentos.Validadores;

    [TestClass]
    public class FactorysTeste
    {
        [TestMethod]
        public void ValidaXmlFactoryTeste()
        {
            var validador = new Mock<ValidadorDeXml>();
            validador.Setup(e => e.AplicarQuando(TipoDocumento.NFe)).Returns(true);
            FabricaDeValidadorDeXml factory = new FabricaDeValidadorDeXmlImpl(new[] { validador.Object });
            Assert.IsTrue(factory.ObterValidador(TipoDocumento.NFe) != null);
        }

        [TestMethod]
        public void ProcessaDocumentoFactoryTeste()
        {
            var validador = new Mock<ProcessadorDeDocumento>();
            validador.Setup(e => e.AplicarQuando(TipoDocumento.NFe)).Returns(true);
            FabricaDeProcessadorDeDocumento factory = new FabricaDeProcessadorDeDocumentoImpl(new[] { validador.Object });
            Assert.IsTrue(factory.ObterProcessaDocumento(TipoDocumento.NFe) != null);
        }

        [TestMethod]
        public void NotificacaoFactoryTeste()
        {
            var validador = new Mock<Notificador>();
            validador.Setup(e => e.AplicarQuando(TipoDocumento.NFe)).Returns(true);
            FabricaDeNotificador factory = new FabricaDeNotificadorImpl(new[] { validador.Object });
            Assert.IsTrue(factory.ObterNotificador(TipoDocumento.NFe) != null);
        }
    }
}

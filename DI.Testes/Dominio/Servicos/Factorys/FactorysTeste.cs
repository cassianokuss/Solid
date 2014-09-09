using System;
using DI.Dominio.Entidades;
using DI.Dominio.Servicos.Documentos;
using DI.Dominio.Servicos.Documentos.Factorys;
using DI.Dominio.Servicos.Documentos.Validacoes;
using DI.Infra.Notificaoes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace DI.Testes.Dominio.Servicos.Factorys
{
    [TestClass]
    public class FactorysTeste
    {
        [TestMethod]
        public void ValidaXmlFactoryTeste()
        {
            var validador = new Mock<ValidadorDeXml>();
            validador.Setup(e => e.AplicavelQuando(TipoDocumento.NFe)).Returns(true);
            FabricaDeValidadorDeXml factory = new FabricaDeValidadorDeXmlImpl(new[] { validador.Object });
            Assert.IsTrue(factory.ObterValidador(TipoDocumento.NFe) != null);
        }

        [TestMethod]
        public void ProcessaDocumentoFactoryTeste()
        {
            var validador = new Mock<ProcessadorDeDocumento>();
            validador.Setup(e => e.AplicavelQuando(TipoDocumento.NFe)).Returns(true);
            IProcessadorDeDocumentoFactory factory = new FabricaDeProcessadorDeDocumentoImpl(new[] { validador.Object });
            Assert.IsTrue(factory.ObterProcessaDocumento(TipoDocumento.NFe) != null);
        }

        [TestMethod]
        public void NotificacaoFactoryTeste()
        {
            var validador = new Mock<INotificacao>();
            validador.Setup(e => e.AplicavelQuando(TipoDocumento.NFe)).Returns(true);
            FabricaDeNotificador factory = new FabricaDeNotificadorImpl(new[] { validador.Object });
            Assert.IsTrue(factory.ObterNotificacao(TipoDocumento.NFe) != null);
        }
    }
}

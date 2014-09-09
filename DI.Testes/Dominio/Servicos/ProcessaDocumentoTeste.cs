using DI.Dominio.Entidades;
using DI.Dominio.Repositorios;
using DI.Dominio.Servicos.Documentos;
using DI.Dominio.Servicos.Documentos.Factorys;
using DI.Dominio.Servicos.Documentos.Validacoes;
using DI.Infra.Notificaoes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace DI.Testes.Dominio.Servicos
{
    [TestClass]
    public class ProcessaDocumentoTeste
    {
        [TestMethod]
        public void ProcessaCte()
        {
            var rep = new Mock<Repositorio<Cte>>();
            rep.Setup(e => e.Armazenar(new Cte()));

            var validaXmlCte = new Mock<ValidadorDeXml>();
            validaXmlCte.Setup(e => e.Validar(""));

            var validaXmlFactory = new Mock<FabricaDeValidadorDeXml>();
            validaXmlFactory.Setup(e => e.ObterValidador(TipoDocumento.CTe)).Returns(validaXmlCte.Object);

            var notificacao = new Mock<Notificacao>();
            notificacao.Setup(e => e.Enviar(""));

            var notificacaoFactory = new Mock<FabricaDeNotificador>();
            notificacaoFactory.Setup(e => e.ObterNotificacao(TipoDocumento.CTe)).Returns(notificacao.Object);

            ProcessadorDeDocumento processa = new ProcessadorDeCte(rep.Object, validaXmlFactory.Object, notificacaoFactory.Object);
            processa.Processar("");
            Assert.IsTrue(processa.AplicarQuando(TipoDocumento.CTe));
        }

        [TestMethod]
        public void ProcessaNfe()
        {
            var rep = new Mock<Repositorio<Nfe>>();
            rep.Setup(e => e.Armazenar(new Nfe()));

            var validaXmlNfe = new Mock<ValidadorDeXml>();
            validaXmlNfe.Setup(e => e.Validar(""));

            var validaXmlFactory = new Mock<FabricaDeValidadorDeXml>();
            validaXmlFactory.Setup(e => e.ObterValidador(TipoDocumento.NFe)).Returns(validaXmlNfe.Object);

            var notificacao = new Mock<Notificacao>();
            notificacao.Setup(e => e.Enviar(""));

            var notificacaoFactory = new Mock<FabricaDeNotificador>();
            notificacaoFactory.Setup(e => e.ObterNotificacao(TipoDocumento.NFe)).Returns(notificacao.Object);

            ProcessadorDeDocumento processa = new ProcessadorDeNfe(rep.Object, validaXmlFactory.Object, notificacaoFactory.Object);
            processa.Processar("");
            Assert.IsTrue(processa.AplicarQuando(TipoDocumento.NFe));
        }

        [TestMethod]
        public void ProcessaNfce()
        {
            var rep = new Mock<Repositorio<Nfce>>();
            rep.Setup(e => e.Armazenar(new Nfce()));

            var validaXmlNfce = new Mock<ValidadorDeXml>();
            validaXmlNfce.Setup(e => e.Validar(""));

            var validaXmlFactory = new Mock<FabricaDeValidadorDeXml>();
            validaXmlFactory.Setup(e => e.ObterValidador(TipoDocumento.NFCe)).Returns(validaXmlNfce.Object);

            var notificacao = new Mock<Notificacao>();
            notificacao.Setup(e => e.Enviar(""));

            var notificacaoFactory = new Mock<FabricaDeNotificador>();
            notificacaoFactory.Setup(e => e.ObterNotificacao(TipoDocumento.NFCe)).Returns(notificacao.Object);

            ProcessadorDeDocumento processa = new ProcessadorDeNfce(rep.Object, validaXmlFactory.Object, notificacaoFactory.Object);
            processa.Processar("");
            Assert.IsTrue(processa.AplicarQuando(TipoDocumento.NFCe));
        }
    }
}

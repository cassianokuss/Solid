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
            var rep = new Mock<IRepositorioBase<Cte>>();
            rep.Setup(e => e.Armazenar(new Cte()));

            var validaXmlCte = new Mock<IValidaXml>();
            validaXmlCte.Setup(e => e.Validar(""));

            var validaXmlFactory = new Mock<IValidaXmlFactory>();
            validaXmlFactory.Setup(e => e.ObterValidador(TipoDocumento.CTe)).Returns(validaXmlCte.Object);

            var notificacao = new Mock<INotificacao>();
            notificacao.Setup(e => e.Enviar(""));

            var notificacaoFactory = new Mock<INotificacaoFactory>();
            notificacaoFactory.Setup(e => e.ObterNotificacao(TipoDocumento.CTe)).Returns(notificacao.Object);

            IProcessaDocumento processa = new ProcessaCte(rep.Object, validaXmlFactory.Object, notificacaoFactory.Object);
            processa.Processar("");
            Assert.IsTrue(processa.AplicavelQuando(TipoDocumento.CTe));
        }

        [TestMethod]
        public void ProcessaNfe()
        {
            var rep = new Mock<IRepositorioBase<Nfe>>();
            rep.Setup(e => e.Armazenar(new Nfe()));

            var validaXmlNfe = new Mock<IValidaXml>();
            validaXmlNfe.Setup(e => e.Validar(""));

            var validaXmlFactory = new Mock<IValidaXmlFactory>();
            validaXmlFactory.Setup(e => e.ObterValidador(TipoDocumento.NFe)).Returns(validaXmlNfe.Object);

            var notificacao = new Mock<INotificacao>();
            notificacao.Setup(e => e.Enviar(""));

            var notificacaoFactory = new Mock<INotificacaoFactory>();
            notificacaoFactory.Setup(e => e.ObterNotificacao(TipoDocumento.NFe)).Returns(notificacao.Object);

            IProcessaDocumento processa = new ProcessaNfe(rep.Object, validaXmlFactory.Object, notificacaoFactory.Object);
            processa.Processar("");
            Assert.IsTrue(processa.AplicavelQuando(TipoDocumento.NFe));
        }

        [TestMethod]
        public void ProcessaNfce()
        {
            var rep = new Mock<IRepositorioBase<Nfce>>();
            rep.Setup(e => e.Armazenar(new Nfce()));

            var validaXmlNfce = new Mock<IValidaXml>();
            validaXmlNfce.Setup(e => e.Validar(""));

            var validaXmlFactory = new Mock<IValidaXmlFactory>();
            validaXmlFactory.Setup(e => e.ObterValidador(TipoDocumento.NFCe)).Returns(validaXmlNfce.Object);

            var notificacao = new Mock<INotificacao>();
            notificacao.Setup(e => e.Enviar(""));

            var notificacaoFactory = new Mock<INotificacaoFactory>();
            notificacaoFactory.Setup(e => e.ObterNotificacao(TipoDocumento.NFCe)).Returns(notificacao.Object);

            IProcessaDocumento processa = new ProcessaNfce(rep.Object, validaXmlFactory.Object, notificacaoFactory.Object);
            processa.Processar("");
            Assert.IsTrue(processa.AplicavelQuando(TipoDocumento.NFCe));
        }
    }
}

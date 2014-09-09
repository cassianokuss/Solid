using DI.Dominio.Entidades;
using DI.Dominio.Repositorios;
using DI.Dominio.Servicos;
using DI.Dominio.Servicos.Documentos;
using DI.Dominio.Servicos.Documentos.Fabricas;
using DI.Dominio.Servicos.Documentos.Validacoes;
using DI.Infra.Notificaoes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace DI.Testes.Dominio.Servicos
{
    [TestClass]
    public class ProcessaTeste
    {
        [TestMethod]
        public void Processa()
        {
            var processaDocumento = new Mock<ProcessadorDeDocumento>();
            processaDocumento.Setup(e => e.Processar(""));
            var processaDocumentoFactory = new Mock<FabricaDeProcessadorDeDocumento>();
            processaDocumentoFactory.Setup(e => e.ObterProcessaDocumento(TipoDocumento.NFe)).Returns(processaDocumento.Object);
            Processa processa = new ProcessaImpl(processaDocumentoFactory.Object);
            processa.ProcessarDocumento(new DocumentoXml() { Conteudo = "", Tipo = TipoDocumento.NFe });
            Assert.IsTrue(true);
        }
    }
}

using DI.Dominio.Entidades;
using DI.Dominio.Repositorios;
using DI.Dominio.Servicos;
using DI.Dominio.Servicos.Documentos;
using DI.Dominio.Servicos.Documentos.Factorys;
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
            var processaDocumento = new Mock<IProcessaDocumento>();
            processaDocumento.Setup(e => e.Processar(""));
            var processaDocumentoFactory = new Mock<IProcessaDocumentoFactory>();
            processaDocumentoFactory.Setup(e => e.ObterProcessaDocumento(TipoDocumento.NFe)).Returns(processaDocumento.Object);
            IProcessa processa = new Processa(processaDocumentoFactory.Object);
            processa.ProcessarDocumento(new DocumentoXml() { Conteudo = "", Tipo = TipoDocumento.NFe });
            Assert.IsTrue(true);
        }
    }
}

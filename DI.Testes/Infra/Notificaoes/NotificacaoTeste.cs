using DI.Dominio.Entidades;
using DI.Infra.Notificadores;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DI.Testes.Infra.Notificaoes
{
    [TestClass]
    public class NotificacaoTeste
    {
        [TestMethod]
        public void NotificarPorEmailNFe()
        {
            Notificador notificacao = new NotificadorPorEmail();
            notificacao.Enviar("Teste");
            Assert.IsTrue(notificacao.AplicarQuando(TipoDocumento.NFe));
        }

        [TestMethod]
        public void NotificarPorEmailNFCe()
        {
            Notificador notificacao = new NotificadorPorEmail();
            notificacao.Enviar("Teste");
            Assert.IsTrue(notificacao.AplicarQuando(TipoDocumento.NFCe));
        }

        [TestMethod]
        public void NotificarPorSms()
        {
            Notificador notificacao = new NotificadorPorSms();
            notificacao.Enviar("Teste");
            Assert.IsTrue(notificacao.AplicarQuando(TipoDocumento.CTe));
        }
    }
}
